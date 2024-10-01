using AgendadorOperaCloud.Models;
using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AgendadorOperaCloud.Controllers
{
    public class Helper
    {
#pragma warning disable CS8604
#pragma warning disable CS8602
#pragma warning disable CS8603
        AgendadorCls agendador = new AgendadorCls();
        LoggerCls Logger = new LoggerCls();
        public string mensagem = "";

        public void popularComboJobsLogs(ComboBox cmb_JobsLogs)
        {
            cmb_JobsLogs.DataSource = Logger.carregarCmbJobsLogs();
            cmb_JobsLogs.DisplayMember = "TIPO";
            cmb_JobsLogs.ValueMember = "ID";
        }

        public void popularComboTables(ComboBox cmb_Tipo_agend)
        {
            cmb_Tipo_agend.DataSource = agendador.carregarCmbTables();
            cmb_Tipo_agend.DisplayMember = "TABLE_NAME";
            cmb_Tipo_agend.ValueMember = "TABLE_NAME";
        }

        public void popularGridLogs(DataGridView dgv_Logs, string ID_JOB, string datainicial, string dataFinal, string erros)
        {
            dgv_Logs.DataSource = Logger.GetLogs(ID_JOB, datainicial, dataFinal, erros);
            mensagem = Logger.mensagem;
            Logger.mensagem = "";
        }

        public bool InsertUpdateJob(bool editmode, GroupBox gpb_dias, TextBox txt_pasta, DateTimePicker dtpk_ExecutarEm_data,
            DateTimePicker dtpk_ExecutarEm_hora,   string radio, ComboBox cmb_Tipo_agend,
                    ComboBox cmb_resortAgenda, CheckBox chk_ativo, NumericUpDown dtpk_DiasMeses, DateTimePicker dtpk_intervalo)
        {
            bool result = false;
            if (consistirInsertUpdate( gpb_dias,  txt_pasta,  dtpk_ExecutarEm_data,dtpk_ExecutarEm_hora,  
                      radio,  cmb_Tipo_agend,cmb_resortAgenda,  chk_ativo,  dtpk_DiasMeses,  dtpk_intervalo))
            {
                var agenda = depara(gpb_dias, txt_pasta, dtpk_ExecutarEm_data, dtpk_ExecutarEm_hora, 
                 radio, cmb_Tipo_agend, cmb_resortAgenda, chk_ativo, dtpk_DiasMeses, dtpk_intervalo);

                
                if (editmode)
                {
                    result = agendador.updateJobsAgendados(agenda);
                }
                else
                {
                    result = agendador.insertJobsAgendados(agenda);
                }
               

                mensagem = agendador.mensagem;
                agendador.mensagem = "";
                return result;
            }
            else 
            {
                return false;
            }

        }
        public bool DeleteJob(string id)
        {
            var result = agendador.deleteJobsAgendados(id);
            var result2 = Logger.deleteJobsLogs(id);
            mensagem = " - " + agendador.mensagem;
            mensagem += " - " + Logger.mensagem;
            agendador.mensagem = "";
            Logger.mensagem = "";
            return result;
        }
        public bool DeleteLog(string id)
        {
            var result = Logger.deleteJobsLogs(id);
            mensagem = Logger.mensagem;
            Logger.mensagem = "";
            return result;
        }
        public void populaEdicao(AgendadorMdl agendador, GroupBox gpb_dias, TextBox txt_pasta, DateTimePicker dtpk_ExecutarEm_data, 
                                DateTimePicker dtpk_ExecutarEm_hora, ComboBox cmb_Tipo_agend,
                                ComboBox cmb_resortAgenda, CheckBox chk_ativo, NumericUpDown dtpk_DiasMeses, DateTimePicker dtpk_intervalo,
                                RadioButton rdb_NaoRepetir, RadioButton rdb_DiasSemana, RadioButton rdb_TodosMeses, RadioButton rdb_intervalo)
        {
            if(agendador.REPETIR_RB == "0"){ rdb_NaoRepetir.Checked = true; }
            else if (agendador.REPETIR_RB == "1"){ rdb_DiasSemana.Checked = true; }
            else if (agendador.REPETIR_RB == "2"){ rdb_TodosMeses.Checked = true; }
            else if (agendador.REPETIR_RB == "3"){ rdb_intervalo.Checked = true; }

            foreach(var i in agendador.DIAS_SEMANA.Split("-"))
            {
                if (agendador.DIAS_SEMANA == "")
                    break;
                var chk = gpb_dias.Controls.OfType<CheckBox>().Where(x => x.Tag.ToString() == i).FirstOrDefault();
                chk.Checked = true;
            }
            txt_pasta.Text = agendador.ARQUIVO_INTEGRACAO.ToString();
            dtpk_ExecutarEm_data.Text = agendador.EXECUTAR_EM;
            dtpk_ExecutarEm_hora.Text = agendador.EXECUTAR_EM_HORA.ToString();
            cmb_Tipo_agend.Text = agendador.TIPO_AGENDAMENTO.ToString();
            cmb_resortAgenda.Text = agendador.RESORT.ToString();
            chk_ativo.Checked = agendador.ATIVO == "0" ? false : true;
            dtpk_DiasMeses.Text = agendador.MESES_DIA.ToString();
            dtpk_intervalo.Text = agendador.REPETIR_CADA_HHMM == ""?"00:00" : agendador.REPETIR_CADA_HHMM;
        }

        public void checkNaoRepetir(DateTimePicker dtpk_ExecutarEm_data, DateTimePicker dtpk_ExecutarEm_hora, NumericUpDown dtpk_DiasMeses, DateTimePicker dtpk_intervalo, GroupBox gpb_dias, 
            ComboBox cmb_Tipo_agend, ComboBox cmb_resortAgenda, CheckBox chk_ativo,TextBox txt_pasta)
        {
            dtpk_ExecutarEm_data.Text = "";
            dtpk_ExecutarEm_hora.Text = "00:00";
            dtpk_DiasMeses.Enabled = false;
            dtpk_DiasMeses.Text = "0";
            dtpk_intervalo.Enabled = false;
            dtpk_intervalo.Text = "00:00";
            gpb_dias.Enabled = false;
            var chn = gpb_dias.Controls.OfType<CheckBox>();
            foreach(var chk in chn)
            {
                chk.Checked = false;
            }
            
            cmb_Tipo_agend.Text = "";
            cmb_resortAgenda.Text = "";
            chk_ativo.Checked = true;
            txt_pasta.Text = "";
        }
        private void checkDiasSemana(DateTimePicker dtpk_ExecutarEm_data, DateTimePicker dtpk_ExecutarEm_hora, 
             NumericUpDown dtpk_DiasMeses, DateTimePicker dtpk_intervalo, GroupBox gpb_dias, 
            ComboBox cmb_Tipo_agend, ComboBox cmb_resortAgenda, CheckBox chk_ativo, TextBox txt_pasta)
        {
            dtpk_ExecutarEm_data.Text = "";
            dtpk_ExecutarEm_hora.Text = "00:00";
            dtpk_DiasMeses.Enabled = false;
            dtpk_DiasMeses.Text = "0";
            dtpk_intervalo.Enabled = false;
            dtpk_intervalo.Text = "00:00";
            gpb_dias.Enabled = true;

            var chn = gpb_dias.Controls.OfType<CheckBox>();
            foreach (var chk in chn)
            {
                chk.Checked = false;
            }
            cmb_Tipo_agend.Text = "";
            cmb_resortAgenda.Text = "";
            chk_ativo.Checked = true;
            txt_pasta.Text = "";
        }
        private void checkMes(DateTimePicker dtpk_ExecutarEm_data, DateTimePicker dtpk_ExecutarEm_hora, 
            NumericUpDown dtpk_DiasMeses, DateTimePicker dtpk_intervalo, GroupBox gpb_dias,
            ComboBox cmb_Tipo_agend, ComboBox cmb_resortAgenda, CheckBox chk_ativo, TextBox txt_pasta)
        {
            dtpk_ExecutarEm_data.Text = "";
            dtpk_ExecutarEm_hora.Text = "00:00";
            dtpk_DiasMeses.Enabled = true;
            dtpk_DiasMeses.Text = "0";
            dtpk_intervalo.Enabled = false;
            dtpk_intervalo.Text = "00:00";
            gpb_dias.Enabled = false;
            var chn = gpb_dias.Controls.OfType<CheckBox>();
            foreach (var chk in chn)
            {
                chk.Checked = false;
            }
            cmb_Tipo_agend.Text = "";
            cmb_resortAgenda.Text = "";
            chk_ativo.Checked = true;
            txt_pasta.Text = "";
        }
        private void checkIntervalo(DateTimePicker dtpk_ExecutarEm_data, DateTimePicker dtpk_ExecutarEm_hora, 
            NumericUpDown dtpk_DiasMeses, DateTimePicker dtpk_intervalo, GroupBox gpb_dias,
            ComboBox cmb_Tipo_agend, ComboBox cmb_resortAgenda, CheckBox chk_ativo, TextBox txt_pasta)
        {
            dtpk_ExecutarEm_data.Text = "";
            dtpk_ExecutarEm_hora.Text = "00:00";
            dtpk_DiasMeses.Enabled = false;
            dtpk_DiasMeses.Text = "0";
            dtpk_intervalo.Enabled = true;
            dtpk_intervalo.Text = "00:00";
            gpb_dias.Enabled = false;
            var chn = gpb_dias.Controls.OfType<CheckBox>();
            foreach (var chk in chn)
            {
                chk.Checked = false;
            }
            cmb_Tipo_agend.Text = "";
            cmb_resortAgenda.Text = "";
            chk_ativo.Checked = true;
            txt_pasta.Text = "";
        }
        public void VerificarRadiosChecked(object sender, DateTimePicker dtpk_ExecutarEm_data, DateTimePicker dtpk_ExecutarEm_hora, 
           NumericUpDown dtpk_DiasMeses, DateTimePicker dtpk_intervalo, 
            GroupBox gpb_dias,ComboBox cmb_Tipo_agend, ComboBox cmb_resortAgenda, CheckBox chk_ativo, TextBox txt_pasta)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
            }
            else if (rb.Checked)
            {
                if (rb.Tag.ToString() == "0")
                {
                    checkNaoRepetir(dtpk_ExecutarEm_data, dtpk_ExecutarEm_hora,  dtpk_DiasMeses, dtpk_intervalo, gpb_dias, cmb_Tipo_agend, cmb_resortAgenda, chk_ativo, txt_pasta);
                }
                else if (rb.Tag.ToString() == "1")
                {
                    checkDiasSemana(dtpk_ExecutarEm_data, dtpk_ExecutarEm_hora, dtpk_DiasMeses, dtpk_intervalo, gpb_dias,  cmb_Tipo_agend, cmb_resortAgenda, chk_ativo, txt_pasta);
                }
                else if (rb.Tag.ToString() == "2")
                {
                    checkMes(dtpk_ExecutarEm_data, dtpk_ExecutarEm_hora,  dtpk_DiasMeses, dtpk_intervalo, gpb_dias,  cmb_Tipo_agend, cmb_resortAgenda, chk_ativo, txt_pasta);
                }
                else if (rb.Tag.ToString() == "3")
                {
                    checkIntervalo(dtpk_ExecutarEm_data, dtpk_ExecutarEm_hora,  dtpk_DiasMeses, dtpk_intervalo, gpb_dias,  cmb_Tipo_agend, cmb_resortAgenda, chk_ativo, txt_pasta);
                }
            }

        }
        public string VerificarRadiosChecked(GroupBox gbx_repetir)
        {

            var chn = gbx_repetir.Controls
                             .OfType<RadioButton>()
                             .FirstOrDefault(r => r.Checked);
            return chn.Tag.ToString();
        }

        public List<string> VerificarCheckboxChecked(GroupBox gpb_dias)
        {
            List<string> list = new List<string>();
            foreach (var check in gpb_dias.Controls.OfType<CheckBox>())
            {
                if (check.Checked == true && check.Tag.ToString() != null)
                {
                    if (check.Tag != null)
                    {
                        list.Add(check.Tag.ToString());
                    }
                    else
                    {
                        list.Clear();
                        MessageBox.Show("Problemas com a Tag do checkbox!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return list;
        }

        public void populaGridAgendados(DataGridView dgv_agendados)
        {
            DataTable dtAgendados = new DataTable();
            dtAgendados = agendador.GetJobsAgendados();

            dgv_agendados.DataSource = dtAgendados;
        }

        public AgendadorMdl depara(GroupBox gpb_dias, TextBox txt_pasta, DateTimePicker dtpk_ExecutarEm_data,
            DateTimePicker dtpk_ExecutarEm_hora, string radio, ComboBox cmb_Tipo_agend,
                    ComboBox cmb_resortAgenda, CheckBox chk_ativo, NumericUpDown dtpk_DiasMeses, DateTimePicker dtpk_intervalo)
        {
            
            AgendadorMdl agendador = new AgendadorMdl();
            //agendador.ID = new Guid();
            agendador.RESORT = cmb_resortAgenda.Text.Trim();
            agendador.TIPOARQUIVO = "";
            agendador.ATIVO = chk_ativo.Checked ? "1" : "0";
            agendador.TIPO_AGENDAMENTO = cmb_Tipo_agend.Text.Trim();
            agendador.EXECUTAR_EM = dtpk_ExecutarEm_data.Text.Trim();
            agendador.EXECUTAR_EM_HORA = dtpk_ExecutarEm_hora.Text.Trim();

            var dias = VerificarCheckboxChecked(gpb_dias);
            string aux = "";
            for (var i = (dias.Count-1); i >= 0 ;i--)
            {
                if (i == 0)
                {
                    aux += dias[i];
                }
                else 
                {
                    aux += dias[i] + "-";
                }
            }
            agendador.DIAS_SEMANA = radio == "1" ? aux : null;
            agendador.ARQUIVO_INTEGRACAO= txt_pasta.Text.Trim();
            agendador.REPETIR_RB = radio;
            agendador.MESES_DIA = radio == "2" ? dtpk_DiasMeses.Text.Trim() : null;
            agendador.REPETIR_CADA_HHMM = radio == "3" ? dtpk_intervalo.Text.Trim() : null;

            return agendador;
        }

        //tipo 1 dias da semana
        public bool consistirInsertUpdate(GroupBox gpb_dias,TextBox txt_pasta,DateTimePicker dtpk_ExecutarEm_data,
            DateTimePicker dtpk_ExecutarEm_hora, string radio,ComboBox cmb_Tipo_agend,
                    ComboBox cmb_resortAgenda, CheckBox chk_ativo, NumericUpDown dtpk_DiasMeses, DateTimePicker dtpk_intervalo)
        {
            if (cmb_Tipo_agend.Text == "" || cmb_Tipo_agend.Text == null)
            {
                mensagem = "Selecione um tipo de agendamento!";
                return false;
            }
            else if (cmb_resortAgenda.Text == "" || cmb_resortAgenda.Text == null)
            {
                mensagem = "Selecione um resort!";
                return false;
            }

            var ExpiraEm = Convert.ToDateTime(dtpk_ExecutarEm_data.Text.Trim() + " " + dtpk_ExecutarEm_hora.Text.Trim());
            var agora = Convert.ToDateTime(DateTime.Now);
            int res = DateTime.Compare(agora, ExpiraEm);

            if (res == 0)
            {
                mensagem = $"Informe uma data de execução maior que a data de agora ( {DateTime.Now.ToString()} )!";
                return false;
            }
            else if (res > 0)
            {
                mensagem = $"Informe uma data de execução maior que a data de agora ( {DateTime.Now.ToString()} )!";
                return false;
            }

            if (radio == "0")
            {
                
            }
            else if(radio == "1")
            {
                var dias = VerificarCheckboxChecked(gpb_dias);

                if(dias == null || dias.Count == 0) 
                {
                    mensagem = "Selecione ao menos um dia para agendar o job!";
                    return false;
                }
               
            }
            else if (radio == "2")
            {
                
            }
            else if (radio == "3")
            {
                if(dtpk_intervalo.Text == "00:00")
                {
                    mensagem = "O intervalo de execução nao pode ser 00:00!";
                    return false;
                }
            }
            if (txt_pasta.Text == "")
            {
                mensagem = "Informe o caminho do arquivo a ser importado!";
                return false;
            }

            return true;

        }

        public DataTable CheckJobsExecute()
        {
            DataTable dt = new DataTable();
            dt = agendador.GetJobsExecute();
            return dt;
        }
    }
}
