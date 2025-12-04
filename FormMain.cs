namespace vConMpeg
{
    public partial class FormMain : Form
    {
        private FFmpegRunner _ffmpegRunner;
        public FormMain()
        {
            InitializeComponent();
            _ffmpegRunner = new FFmpegRunner();
            button1.Click += button1_Click;
            btn_ISPicker.Click += btn_ISPicker_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ffmpegRunner.Start();
        }

        private void btn_ISPicker_Click(object? sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select the folder containing image sequence files";
                fbd.UseDescriptionForTitle = true;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    tb_ISPath.Text = fbd.SelectedPath;
                }
            }
        }
    }
}
