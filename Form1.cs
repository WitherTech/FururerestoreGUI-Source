using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;



namespace tsschecker_gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string blobFilePath;
        private string signedIPSWFilePath;
        private string restoreToIPSWFilePath;
        private string basebandFilePath;
        private string buildmanifestFilePath;
        private string sepFilePath;

        public string BlobFilePath
        {
            get => blobFilePath;
            set => blobFilePath = value;
        }

        public string SignedIPSWFilePath
        {
            get => signedIPSWFilePath;
            set => signedIPSWFilePath = value;
        }

        public string RestoreToIPSWFilePath
        {
            get => restoreToIPSWFilePath;
            set => restoreToIPSWFilePath = value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                this.BlobFilePath = file.FileName;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                this.SignedIPSWFilePath = file.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                this.RestoreToIPSWFilePath = file.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] exeBytes = Properties.Resources.futurerestore;
            string exeToRun = Path.Combine(Path.GetTempPath(), "futurerestore.exe");
            if (File.Exists(exeToRun))
            {
                File.Delete(exeToRun);
            }
            using (FileStream exeFile = new FileStream(exeToRun, FileMode.CreateNew))
                exeFile.Write(exeBytes, 0, exeBytes.Length);
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = exeToRun,
                    Arguments = "-t " + this.blobFilePath +
                                " -i " + this.signedIPSWFilePath +
                                " -b " + this.basebandFilePath +
                                " -p " + this.buildmanifestFilePath +
                                " -s " + this.sepFilePath +
                                " -m " + this.buildmanifestFilePath +
                                " " + this.restoreToIPSWFilePath,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                richTextBox1.Text += proc.StandardOutput.ReadLine() + "\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] exeBytes = Properties.Resources.futurerestore;
            string exeToRun = Path.Combine(Path.GetTempPath(), "futurerestore.exe");
            if (File.Exists(exeToRun))
            {
                File.Delete(exeToRun);
            }
            using (FileStream exeFile = new FileStream(exeToRun, FileMode.CreateNew))
                exeFile.Write(exeBytes, 0, exeBytes.Length);
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = exeToRun,
                    Arguments = "-t " + this.blobFilePath +
                                " -i " + this.signedIPSWFilePath +
                                " -b " + this.basebandFilePath +
                                " -p " + this.buildmanifestFilePath +
                                " -s " + this.sepFilePath +
                                " -m " + this.buildmanifestFilePath +
                                " -w " + this.restoreToIPSWFilePath,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                richTextBox1.Text += proc.StandardOutput.ReadLine() + "\n";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                this.buildmanifestFilePath = file.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                this.basebandFilePath = file.FileName;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                this.sepFilePath = file.FileName;
            }
        }
    }
}