
using AgendadorOperaCloud.Context;
using AgendadorOperaCloud.Controllers;
using AgendadorOperaCloud.Models;
using AgendadorOperaCloud.Views;
using Newtonsoft.Json;
using System.Management;
using System.Diagnostics;
using System.ServiceProcess;
using Microsoft.VisualBasic.ApplicationServices;


using Microsoft.Extensions.Configuration;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Reflection;
using System.Xml.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;
using System.Data;

namespace AgendadorOperaCloud
{
    public partial class Agendador : Form
    {
        readonly Helper _helper = new();
        bool editmode = false;

        public Agendador()
        {
            InitializeComponent();
        }

        private void Agendador_Load(object sender, EventArgs e)
        {
            rdb_NaoRepetir.Tag = 0;
            rdb_DiasSemana.Tag = 1;
            rdb_TodosMeses.Tag = 2;
            rdb_intervalo.Tag = 3;

            chk_segunda.Tag = 1;
            chk_terca.Tag = 2;
            chk_quarta.Tag = 3;
            chk_quinta.Tag = 4;
            chk_sexta.Tag = 5;
            chk_sabado.Tag = 6;
            chk_domingo.Tag = 7;

            gpb_dias.Enabled = false;

            dtpk_DiasMeses.Enabled = false;
            dtpk_intervalo.Enabled = false;

            _helper.popularComboTables(cmb_Tipo_agend);
            _helper.populaGridAgendados(dgv_agendados);
            _helper.popularComboJobsLogs(cmb_JobsLogs);

            CheckServicos();
            timer1.Interval = 3000;
            timer1.Enabled = true;
        }


        private void btn_pasta_Click(object sender, EventArgs e)
        {
            OpenFileDialog pasta = new();
            pasta.Title = "Selecione a pasta para salvar.";
            pasta.RestoreDirectory = true;
            if (pasta.ShowDialog() == DialogResult.OK)
            {
                txt_pasta.Text = pasta.FileName;
            }
            else
            {
                txt_pasta.Text = "";
            }
            pasta.Dispose();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            _helper.VerificarRadiosChecked(sender, dtpk_ExecutarEm_data, dtpk_ExecutarEm_hora,
                dtpk_DiasMeses, dtpk_intervalo, gpb_dias, cmb_Tipo_agend, cmb_resortAgenda, chk_ativo, txt_pasta);
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            var radio = _helper.VerificarRadiosChecked(gbx_repetir);

            if (_helper.InsertUpdateJob(editmode, gpb_dias, txt_pasta, dtpk_ExecutarEm_data, dtpk_ExecutarEm_hora,
                     radio, cmb_Tipo_agend, cmb_resortAgenda, chk_ativo, dtpk_DiasMeses, dtpk_intervalo))
            {
                MessageBox.Show("Job registrada com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _helper.populaGridAgendados(dgv_agendados);
                _helper.popularComboJobsLogs(cmb_JobsLogs);

                rdb_NaoRepetir.Checked = true;
                _helper.checkNaoRepetir(dtpk_ExecutarEm_data, dtpk_ExecutarEm_hora,
                    dtpk_DiasMeses, dtpk_intervalo, gpb_dias, cmb_Tipo_agend, cmb_resortAgenda, chk_ativo, txt_pasta);
            }
            else
            {
                if (!string.IsNullOrEmpty(_helper.mensagem))
                {
                    MessageBox.Show(_helper.mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _helper.mensagem = "";
                }

            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (editmode)
            {
                btn_adicionar.Enabled = true;
                btn_excluir.Enabled = true;
                btn_salvarEdicao.Visible = false;
                btn_editar.Text = "Editar";
                editmode = false;
                rdb_NaoRepetir.Checked = false;
                rdb_NaoRepetir.Checked = true;
                chk_ativo.Checked = true;
            }
            else
            {
                btn_adicionar.Enabled = false;
                btn_excluir.Enabled = false;
                btn_salvarEdicao.Visible = true;
                btn_editar.Text = "Cancelar";
                editmode = true;
                rdb_intervalo.Checked = false;
                rdb_DiasSemana.Checked = false;
                rdb_NaoRepetir.Checked = false;
                rdb_TodosMeses.Checked = false;
                try
                {
                    var dict = new Dictionary<string, string>();
                    dgv_agendados.SelectedRows.OfType<DataGridViewRow>().ToList<DataGridViewRow>().ForEach(
                    row =>
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            dict.Add(cell.OwningColumn.Name, cell.Value.ToString());
                        }
                    });

                    var json = JsonConvert.SerializeObject(dict);
                    var job = JsonConvert.DeserializeObject<AgendadorMdl>(json);

                    if (job != null)
                    {
                        Program.idEdit = job.ID;
                        _helper.populaEdicao(job, gpb_dias, txt_pasta, dtpk_ExecutarEm_data, dtpk_ExecutarEm_hora,
                             cmb_Tipo_agend, cmb_resortAgenda, chk_ativo, dtpk_DiasMeses,
                            dtpk_intervalo, rdb_NaoRepetir, rdb_DiasSemana, rdb_TodosMeses, rdb_intervalo);
                    }
                    else
                    {
                        MessageBox.Show("Problemas para iniciar a edição!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        btn_adicionar.Enabled = true;
                        btn_excluir.Enabled = true;
                        btn_salvarEdicao.Visible = false;
                        btn_editar.Text = "Editar";
                        editmode = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btn_adicionar.Enabled = true;
                    btn_excluir.Enabled = true;
                    btn_salvarEdicao.Visible = false;
                    btn_editar.Text = "Editar";
                    editmode = false;
                    rdb_NaoRepetir.Checked = false;
                    rdb_NaoRepetir.Checked = true;
                }
            }
        }
        private void btn_salvarEdicao_Click(object sender, EventArgs e)
        {
            var radio = _helper.VerificarRadiosChecked(gbx_repetir);

            if (_helper.InsertUpdateJob(editmode, gpb_dias, txt_pasta, dtpk_ExecutarEm_data, dtpk_ExecutarEm_hora,
                     radio, cmb_Tipo_agend, cmb_resortAgenda, chk_ativo, dtpk_DiasMeses, dtpk_intervalo))
            {
                MessageBox.Show("Job atualizada com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _helper.populaGridAgendados(dgv_agendados);

                rdb_NaoRepetir.Checked = true;
                _helper.checkNaoRepetir(dtpk_ExecutarEm_data, dtpk_ExecutarEm_hora,
                    dtpk_DiasMeses, dtpk_intervalo, gpb_dias, cmb_Tipo_agend, cmb_resortAgenda, chk_ativo, txt_pasta);

                editmode = false;
                btn_adicionar.Enabled = true;
                btn_excluir.Enabled = true;
                btn_editar.Text = "Editar";
                btn_salvarEdicao.Visible = false;
            }
            else
            {
                if (!string.IsNullOrEmpty(_helper.mensagem))
                {
                    MessageBox.Show(_helper.mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _helper.mensagem = "";
                }

            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Tem certeza que deseja excluir esta Job?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                var dict = new Dictionary<string, string>();
                dgv_agendados.SelectedRows.OfType<DataGridViewRow>().ToList<DataGridViewRow>().ForEach(
                row =>
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dict.Add(cell.OwningColumn.Name, cell.Value.ToString());
                    }
                });

                var json = JsonConvert.SerializeObject(dict);
                var job = JsonConvert.DeserializeObject<AgendadorMdl>(json);

                if (job != null)
                {
                    if (_helper.DeleteJob(job.ID))
                    {
                        MessageBox.Show($"O Job {job.ID} - {job.TIPO_AGENDAMENTO} e seus Logs foram excluidos com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _helper.populaGridAgendados(dgv_agendados);

                        rdb_NaoRepetir.Checked = true;
                        _helper.checkNaoRepetir(dtpk_ExecutarEm_data, dtpk_ExecutarEm_hora,
                            dtpk_DiasMeses, dtpk_intervalo, gpb_dias, cmb_Tipo_agend, cmb_resortAgenda, chk_ativo, txt_pasta);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(_helper.mensagem))
                        {
                            MessageBox.Show(_helper.mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            _helper.mensagem = "";
                        }
                    }
                }
            }
        }

        private void btn_pesquisarLog_Click(object sender, EventArgs e)
        {
            var dt1 = Convert.ToDateTime(dtp_DataInicialLog.Text);
            var dt2 = Convert.ToDateTime(dtp_DataFinalLog.Text);
            var resExecutar = DateTime.Compare(dt1, dt2);
            var entrar = true;

            if (resExecutar > 0)
            {
                MessageBox.Show($"A data inicial da pesquisa ( {dtp_DataInicialLog.Text} ) " +
                    $"não pode ser maior que a data final ( {dtp_DataFinalLog.Text} )!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                entrar = false;
            }
            if (cmb_JobsLogs.SelectedValue == null || cmb_JobsLogs.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Selecione um job antes de pesquisar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                entrar = false;
            }

            if (entrar)
            {
                _helper.popularGridLogs(dgv_Logs, cmb_JobsLogs.SelectedValue.ToString(), dtp_DataInicialLog.Text,
                dtp_DataFinalLog.Text, chk_LogsErros.Checked ? "1" : "0");
                if (!string.IsNullOrEmpty(_helper.mensagem))
                {
                    MessageBox.Show(_helper.mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _helper.mensagem = "";
                }
                else if (dgv_Logs.Rows.Count == 0)
                {
                    MessageBox.Show($"Sem registros para a data informada ({dtp_DataInicialLog.Text} à {dtp_DataFinalLog.Text}) !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btn_visualizarlog_Click(object sender, EventArgs e)
        {
            var dict = new Dictionary<string, string>();
            dgv_Logs.SelectedRows.OfType<DataGridViewRow>().ToList<DataGridViewRow>().ForEach(
            row =>
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dict.Add(cell.OwningColumn.Name, cell.Value.ToString());
                }
            });

            var json = JsonConvert.SerializeObject(dict);
            var job = JsonConvert.DeserializeObject<LogsMdl>(json);

            if (job != null && job.ID != null)
            {
                Logger frm_Logger = new(job);
                frm_Logger.ShowDialog();
            }
            else
                MessageBox.Show("Selecione um Log na grid para visualizar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btn_excluirlog_Click(object sender, EventArgs e)
        {
            if (dgv_Logs.Rows.Count > 0 && dgv_Logs.CurrentRow != null)
            {
                var idlog = dgv_Logs.CurrentRow.Cells["ID"].Value.ToString();
                var res = MessageBox.Show($"Tem certeza que deseja excluir o log {idlog}!", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (_helper.DeleteLog(idlog))
                    {
                        MessageBox.Show("Log excluido com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _helper.popularGridLogs(dgv_Logs, cmb_JobsLogs.SelectedValue.ToString(), dtp_DataInicialLog.Text,
                        dtp_DataFinalLog.Text, chk_LogsErros.Checked ? "1" : "0");
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(_helper.mensagem))
                        {
                            MessageBox.Show(_helper.mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            _helper.mensagem = "";
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Não existe registro selecionado para exclusão!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void CheckServicos()
        {
            string procSearch = "WorkerOperaCloud";
            try
            {
                btn_serviceIniciar.Enabled = false;
                btn_serviceParar.Enabled = false;
                btn_serviceReiniciar.Enabled = false;

                string remoteSystem = Program._Configuration.GetSection("servico").GetSection("remoteSystem").Value;

                ServiceController svc = new(procSearch, remoteSystem);

                if (svc.Status.Equals(ServiceControllerStatus.Stopped))
                {
                    lbl_servicoPID.Text = "-";
                    lbl_servico.Text = "-";
                    lbl_servicoStatus.Text = "-";

                    btn_serviceIniciar.Enabled = true;
                    btn_serviceParar.Enabled = false;
                    btn_serviceReiniciar.Enabled = false;
                }
                if (svc.Status.Equals(ServiceControllerStatus.Running))
                {
                    Process[] proc = System.Diagnostics.Process.GetProcessesByName(procSearch, remoteSystem);
                    if (proc.Length > 0)
                    {
                        lbl_servicoPID.Text = proc[0].Id.ToString();
                        lbl_servico.Text = proc[0].ProcessName;
                        lbl_servicoStatus.Text = svc.Status.ToString();

                        btn_serviceIniciar.Enabled = false;
                        btn_serviceParar.Enabled = true;
                        btn_serviceReiniciar.Enabled = true;
                    }
                }

            }
            catch (Exception ex)
            {
                btn_serviceIniciar.Enabled = true;
                btn_serviceParar.Enabled = false;
                btn_serviceReiniciar.Enabled = false;
                MessageBox.Show($"Problemas para iniciar o serviço {procSearch} Exception: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_serviceIniciar_Click(object sender, EventArgs e)
        {
            string procSearch = "WorkerOperaCloud";
            try
            {
                string remoteSystem = Program._Configuration.GetSection("servico").GetSection("remoteSystem").Value;

                ServiceController svc = new(procSearch, remoteSystem);

                if (svc.Status.Equals(ServiceControllerStatus.Stopped) ||
                    svc.Status.Equals(ServiceControllerStatus.StopPending))
                {
                    btn_serviceIniciar.Enabled = false;
                    btn_serviceParar.Enabled = false;
                    btn_serviceReiniciar.Enabled = false;

                    svc.Start();
                    TimeSpan t = TimeSpan.FromSeconds(10);
                    svc.WaitForStatus(ServiceControllerStatus.Running, t);
                    Process[] proc = System.Diagnostics.Process.GetProcessesByName(procSearch, remoteSystem);
                    if (proc.Length > 0)
                    {
                        lbl_servicoPID.Text = proc[0].Id.ToString();
                        lbl_servico.Text = proc[0].ProcessName;
                        lbl_servicoStatus.Text = svc.Status.ToString();

                        btn_serviceIniciar.Enabled = false;
                        btn_serviceParar.Enabled = true;
                        btn_serviceReiniciar.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                btn_serviceIniciar.Enabled = true;
                btn_serviceParar.Enabled = false;
                btn_serviceReiniciar.Enabled = false;
                MessageBox.Show($"Problemas para iniciar o serviço {procSearch} Exception: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_serviceReiniciar_Click(object sender, EventArgs e)
        {
            string procSearch = "WorkerOperaCloud";
            try
            {
                string remoteSystem = Program._Configuration.GetSection("servico").GetSection("remoteSystem").Value;

                ServiceController svc = new(procSearch, remoteSystem);

                if (svc.Status.Equals(ServiceControllerStatus.Running))
                {
                    btn_serviceIniciar.Enabled = false;
                    btn_serviceParar.Enabled = false;
                    btn_serviceReiniciar.Enabled = false;
                    svc.Stop();
                    lbl_servicoStatus.Text = "Stopping";
                    TimeSpan t = TimeSpan.FromSeconds(10);
                    svc.WaitForStatus(ServiceControllerStatus.Stopped, t);
                    lbl_servicoStatus.Text = svc.Status.ToString();
                    svc.Start();
                    Process[] proc = System.Diagnostics.Process.GetProcessesByName(procSearch, remoteSystem);
                    if (proc.Length > 0)
                    {
                        lbl_servicoPID.Text = proc[0].Id.ToString();
                        lbl_servico.Text = proc[0].ProcessName;
                        lbl_servicoStatus.Text = "Running";

                        btn_serviceIniciar.Enabled = false;
                        btn_serviceParar.Enabled = true;
                        btn_serviceReiniciar.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                btn_serviceIniciar.Enabled = true;
                btn_serviceParar.Enabled = false;
                btn_serviceReiniciar.Enabled = false;
                MessageBox.Show($"Problemas para Reiniciar o serviço {procSearch} Exception: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_serviceParar_Click(object sender, EventArgs e)
        {
            string procSearch = "WorkerOperaCloud";
            try
            {
                string remoteSystem = Program._Configuration.GetSection("servico").GetSection("remoteSystem").Value;

                ServiceController svc = new(procSearch, remoteSystem);

                if (svc.Status.Equals(ServiceControllerStatus.Running))
                {
                    btn_serviceIniciar.Enabled = false;
                    btn_serviceParar.Enabled = false;
                    btn_serviceReiniciar.Enabled = false;
                    svc.Stop();
                    TimeSpan t = TimeSpan.FromSeconds(10);
                    svc.WaitForStatus(ServiceControllerStatus.Stopped, t);
                    Process[] proc = System.Diagnostics.Process.GetProcessesByName(procSearch, remoteSystem);
                    if (proc.Length > 0)
                    {
                        lbl_servicoPID.Text = proc[0].Id.ToString();
                        lbl_servico.Text = proc[0].ProcessName;
                        lbl_servicoStatus.Text = svc.Status.ToString();

                        btn_serviceIniciar.Enabled = true;
                        btn_serviceParar.Enabled = false;
                        btn_serviceReiniciar.Enabled = false;
                    }
                    else
                    {
                        lbl_servicoPID.Text = "-";
                        lbl_servico.Text = "-";
                        lbl_servicoStatus.Text = "-";
                        btn_serviceIniciar.Enabled = true;
                        btn_serviceParar.Enabled = false;
                        btn_serviceReiniciar.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                btn_serviceIniciar.Enabled = false;
                btn_serviceParar.Enabled = true;
                btn_serviceReiniciar.Enabled = true;
                MessageBox.Show($"Problemas para Stopar o serviço {procSearch} Exception: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //ConnectionOptions op = new ConnectionOptions();
            //op.Username = "grupo\administrator";
            //op.Password = "apSxP@589@#$";
            //ManagementScope scope = new ManagementScope(@"\\Servername.Domain\root\cimv2", op);
            //scope.Connect();
            //ManagementPath path = new ManagementPath("Win32_Service");
            //ManagementClass services;
            //services = new ManagementClass(scope, path, null);

            //foreach (ManagementObject service in services.GetInstances())
            //{

            //    if (service.GetPropertyValue("State").ToString().ToLower().Equals("running"))
            //    { // Do something }

            //    }

            //}

            //namelbl.Text = svc.Status.ToString();

            //try
            //{
            //    //1º connect to remote computer
            //    ConnectionOptions connection = new ConnectionOptions();
            //    connection.Username = "administrator";
            //    connection.Password = "apSxP@589@#$";
            //    connection.Authority = "NTLMDOMAIN:192.168.243.27";
            //    connection.EnablePrivileges = true;
            //    connection.Authentication = AuthenticationLevel.Default;
            //    connection.Impersonation = ImpersonationLevel.Impersonate;

            //    ManagementScope scope = new ManagementScope(
            //        "\\\\192.168.243.18\\root\\CIMV2", connection);

            //    scope.Connect();


            //// finsh connection

            //ManagementObjectSearcher moSearcher = new ManagementObjectSearcher();
            //moSearcher.Scope = scope;
            //moSearcher.Query = new ObjectQuery("SELECT * FROM win32_Service WHERE Name ='WorkerOperaCloud'");
            //ManagementObjectCollection mbCollection = moSearcher.Get();

            //foreach (ManagementObject oReturn in mbCollection)
            //{
            //    // invoke start
            //    ManagementBaseObject outParams = oReturn.InvokeMethod("StartService", null, null);

            //    //invoke stop
            //    ManagementBaseObject outParams2 = oReturn.InvokeMethod("StopService", null, null);

            //    //get result
            //    string a = outParams["ReturnValue"].ToString();

            //    // get service state
            //    string state = oReturn.Properties["State"].Value.ToString().Trim();

            //    MessageBox.Show(state);// TO DISPLAY STATOS FROM SERVICE IN REMOTE COMPUTER
            //}
            //}
            //catch(Exception ex )
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            OracleConnection conn = new();
            OracleCommand cmd = new();
            conn.ConnectionString = Program._Configuration.GetConnectionString("DbConnection");
            cmd.CommandText = "select ID_JOB,JOB,RESORT,INICIO from JOBS_EXEC";
            DataTable dt = new();
            try
            {
                conn.Open();
                cmd.Connection = conn;
                OracleDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
                conn.Close();
                dgv_jobsExec.DataSource = dt;

            }
            catch (OracleException ex)
            {
                var mensagem = "Erro ao Consultar JOBS_EXEC: " + ex.Message;
            }
        }
    }
}

