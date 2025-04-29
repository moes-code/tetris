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
            for (int Z = 1; Z < 14; Z++)
            {
                F[Z, 0] = Edge;
                for (int S = 1; S < 9; S++)
                    F[Z, S] = Empty;
                F[Z, 9] = Edge;
            }

            for (int S = 0; S < 10; S++)
                F[14, S] = Edge;

            /* Initialization */
            Level = 1;
            NextPanel();
        }

        private void NextPanel( )
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
                PL[PX].Location = new Point(PL[PX].Location.X, PL[PX].Location.Y + 20);
                PR += 1;
            }
        }

        private void CheckAll()
        {
            bool Beside = false, Above = false;

            /* Three identical panels next to each other ? */
            for (int Z = 13; Z > 0; Z--)
            {
                for (int S = 1; S < 7; S++)
                {
                    Beside = CheckBeside(Z, S);
                    if (Beside) break;
                }
                if (Beside) break;
            }

            /* Three identical panels on top of each other? */
            for (int Z = 13; Z > 2; Z--)
            {
                for (int S = 1; S < 9; S++)
                {
                    Above = CheckAbove(Z, S);
                    if (Above) break;
                }
                if (Above) break;
            }

            if (Beside || Above)
            {
                /* Faster */
                Level += 1;
                TimTetris.Interval = 5000 / (Level + 9);

                /* It may be possible to remove one more row now */
                CheckAll();
            }
        }

        /* If three fields next to each other are occupied */
        private bool CheckBeside(int Z, int S)
        {
            bool result = false;

            if (F[Z, S] != Empty && F[Z, S+1] != Empty && F[Z, S+2] != Empty)
            {
                /* If three colors are equal */
                if (PL[F[Z, S]].BackColor == PL[F[Z, S+1]].BackColor && PL[F[Z, S]].BackColor == PL[F[Z, S+2]].BackColor)
                {
                    for (int SX = S; SX < S + 3; SX++)
                    {
                        /* Delete Panel from the form */
                        Controls.Remove(PL[F[Z, SX]]);

                        /* Clear field */
                        F[Z, SX] = Empty;

                        /* Lower panels above the unloaded panel */
                        int ZX = Z - 1;
                        while (F[ZX, SX] != Empty)
                        {
                            PL[F[ZX, SX]].Location = new Point(
                                PL[F[ZX, SX]].Location.X,
                                PL[F[ZX, SX]].Location.Y + 20);

                            /* Field reoccupied */
                            F[ZX + 1, SX] = F[ZX, SX];
                            F[ZX, SX] = Empty;
                            ZX -= 1;
                        }
                    }
                    result = true;
                }
            }
            return result;
        }

        /* If three fields on top of each other are occupied */
        private bool CheckAbove(int Z, int S)
        {
            bool result = false;

            if (F[Z, S] != Empty && F[Z-1, S] != Empty && F[Z-2, S] != Empty)
            {
                /* If three colors are equal */
                if (PL[F[Z, S]].BackColor == PL[F[Z-1, S]].BackColor && PL[F[Z, S]].BackColor == PL[F[Z-2, S]].BackColor)
                {
                    /* Unload 3 panels */
                    for (int ZX = Z; ZX < Z - 3; ZX--)
                    {
                        /* Delete Panel from the form */
                        Controls.Remove(PL[F[ZX, S]]);

                        /* Clear field */
                        F[ZX, S] = Empty;
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
    }
}