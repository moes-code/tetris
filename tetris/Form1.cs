namespace tetris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /* Index of current panel */
        private int PX;

        /* Pitch including edge fields */
        private readonly int[,] F = new int[15, 10];

        /* Row and column of current panel */
        private int PR, PC;

        /* Difficulty Level */
        private int Level;

        /* An initially empty list of game panels */
        private readonly List<Panel> PL = new();

        /* An array of colors for the panels */
        private readonly Color[] ColorField = { Color.Red, Color.Yellow, Color.Green, Color.Blue, Color.Cyan, Color.Magenta, Color.Black, Color.White };

        /* Constants for field point status */
        private const int Empty = -1;
        private const int Edge = -2;

        /* Generate and initialize random generator */
        private readonly Random r = new();

        private void Form1_Load(object sender, EventArgs e)
        {
            /* Occupy field */
            for (int R = 1; R < 14; R++)
            {
                F[R, 0] = Edge;
                for (int C = 1; C < 9; C++)
                    F[R, C] = Empty;
                F[R, 9] = Edge;
            }

            for (int C = 0; C < 10; C++)
                F[14, C] = Edge;

            /* Initialization */
            Level = 1;
            NextPanel();
        }

        private void NextPanel()
        {
            int Color;
            Panel p = new();

            /* Add new panel to the generic list */
            PL.Add(p);

            /* Place new panel */
            p.Location = new Point(105, 77);
            p.Size = new Size(20, 20);

            /* Color selection for new panel */
            Color = r.Next(0, 8);
            p.BackColor = ColorField[Color];

            /* Add new panel to form */
            Controls.Add(p);

            /* Determine index for later access */
            PX = PL.Count - 1;

            /* Current row, column */
            PR = 1;
            PC = 5;
        }

        private void TimTetris_Tick(object sender, EventArgs e)
        {
            /* If the panel can fall no further */
            if (F[PR + 1, PC] != Empty)
            {
                /* Top row reached */
                if (PR == 1)
                {
                    TimTetris.Enabled = false;
                    MessageBox.Show("Game Over");
                    return;
                }
                F[PR, PC] = PX;
                CheckAll();
                NextPanel();
            }
            else
            {
                /* If the panel can drop further */
                PL[PX].Location = new Point(
                    PL[PX].Location.X, PL[PX].Location.Y + 20);
                PR += 1;
            }
        }

        private void CheckAll()
        {
            bool besideFound, aboveFound;

            do
            {
                besideFound = false;
                aboveFound = false;

                /* Check for three identical panels next to each other */
                for (int R = 13; R > 0; R--)
                {
                    for (int C = 1; C < 7; C++)
                    {
                        if (CheckBeside(R, C))
                        {
                            besideFound = true;
                        }
                    }
                }

                /* Check for three identical panels on top of each other */
                for (int R = 13; R > 2; R--)
                {
                    for (int C = 1; C < 9; C++)
                    {
                        if (CheckAbove(R, C))
                        {
                            aboveFound = true;
                        }
                    }
                }

                /* If any matches were found, update the level and timer */
                if (besideFound || aboveFound)
                {
                    Level += 1;
                    TimTetris.Interval = Math.Max(1, 5000 / (Level + 9));
                }

            } while (besideFound || aboveFound); // Repeat until no more matches are found
        }

        /* If three fields next to each other are occupied */
        private bool CheckBeside(int R, int C)
        {
            bool result = false;

            if (F[R, C] != Empty && F[R, C + 1] != Empty && F[R, C + 2] != Empty)
            {
                /* If three colors are equal */
                if (PL[F[R, C]].BackColor == PL[F[R, C + 1]].BackColor && PL[F[R, C]].BackColor == PL[F[R, C + 2]].BackColor)
                {
                    for (int CX = C; CX < C + 3; CX++)
                    {
                        /* Delete Panel from the form */
                        Controls.Remove(PL[F[R, CX]]);

                        /* Clear field */
                        F[R, CX] = Empty;

                        /* Lower panels above the unloaded panel */
                        int RX = R - 1;
                        while (F[RX, CX] != Empty)
                        {
                            PL[F[RX, CX]].Location = new Point(
                                PL[F[RX, CX]].Location.X,
                                PL[F[RX, CX]].Location.Y + 20);

                            /* Field reoccupied */
                            F[RX + 1, CX] = F[RX, CX];
                            F[RX, CX] = Empty;
                            RX -= 1;
                        }
                    }
                    result = true;
                }
            }
            return result;
        }

        /* If three fields on top of each other are occupied */
        private bool CheckAbove(int R, int C)
        {
            bool result = false;

            if (F[R, C] != Empty && F[R - 1, C] != Empty && F[R - 2, C] != Empty)
            {
                /* If three colors are equal */
                if (PL[F[R, C]].BackColor == PL[F[R - 1, C]].BackColor && PL[F[R, C]].BackColor == PL[F[R - 2, C]].BackColor)
                {
                    /* Unload 3 panels */
                    for (int RX = R; RX > R - 3; RX--)
                    {
                        /* Delete Panel from the form */
                        Controls.Remove(PL[F[RX, C]]);

                        /* Clear field */
                        F[RX, C] = Empty;
                    }
                    result = true;
                }
            }
            return result;
        }

        private void CmdLeft_Click(object sender, EventArgs e)
        {
            if (F[PR, PC - 1] == Empty)
            {
                PL[PX].Location = new Point(
                    PL[PX].Location.X - 20, PL[PX].Location.Y);
                PC -= 1;
            }
        }

        private void CmdRight_Click(object sender, EventArgs e)
        {
            if (F[PR, PC + 1] == Empty)
            {
                PL[PX].Location = new Point(
                    PL[PX].Location.X + 20, PL[PX].Location.Y);
                PC += 1;
            }
        }

        private void CmdDown_Click(object sender, EventArgs e)
        {
            while (F[PR + 1, PC] == Empty)
            {
                PL[PX].Location = new Point(
                    PL[PX].Location.X, PL[PX].Location.Y + 20);
                PC += 1;
            }
            F[PR, PC] = PX;
            CheckAll();
            NextPanel();
        }

        private void CmdPause_Click(object sender, EventArgs e)
        {
            TimTetris.Enabled = !TimTetris.Enabled;
        }
    }
}