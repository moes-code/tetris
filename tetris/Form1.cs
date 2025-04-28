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

        private void TimeTetris_Tick(object sender, EventArgs e)
        {
            /* If the panel can fall no further */
            if (F[PR + 1, PC] != Empty)
            {
                /* Top row reached */
                if (PR == 1)
                {
                    TimeTetris.Enabled = false;
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
    }
}
