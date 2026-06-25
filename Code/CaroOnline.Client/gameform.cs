namespace CaroOnline.Client
{
    public partial class GameForm : Form
    {
        private BoardUI _boardUI;

        public GameForm()
        {
            InitializeComponent();

            _boardUI = new BoardUI(panelBoard);
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
             
        }
    }
}