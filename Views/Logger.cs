using AgendadorOperaCloud.Models;
using System.Windows.Forms;

namespace AgendadorOperaCloud.Views
{
    public partial class Logger : Form
    {
        LogsMdl _Log;
        public Logger(LogsMdl Log)
        {
            _Log = Log;
            InitializeComponent();
        }

        private void Logger_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = _Log.LOG;
        }

        private void btn_ExportarLog_Click(object sender, EventArgs e)
        {

            SaveFileDialog pasta = new();
            pasta.Title = "Selecione a Pasta para Salvar o Log.";
            pasta.CheckPathExists = true;
            pasta.RestoreDirectory = true;
            pasta.Filter = "*.txt|*.txt";
            pasta.Title = "Selecione a Pasta para Salvar o Log.";
            pasta.DefaultExt = ".txt";
            pasta.FileName = _Log.TIPOARQUIVO + "_LOG" + "_" + _Log.DATA_EXECUCAO.Trim().Split(" ")[0].Replace("/","")+"_"+_Log.HORA_EXECUCAO.Replace(":","");

            if (pasta.ShowDialog() == DialogResult.OK)
            {
                File.Create(pasta.FileName).Dispose();
                File.AppendAllText(pasta.FileName,_Log.LOG);
                MessageBox.Show("Log Exportado com Sucesso na Pasta \n" + pasta.FileName,"Exportar Logs",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            
            pasta.Dispose();
        }
    }
}
