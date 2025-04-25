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
    }
}
