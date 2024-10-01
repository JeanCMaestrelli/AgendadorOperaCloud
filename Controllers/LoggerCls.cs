using AgendadorOperaCloud.Context;
using AgendadorOperaCloud.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendadorOperaCloud.Controllers
{
    public class LoggerCls
    {
        private BD conexao = new BD();
        private OracleCommand cmd = new OracleCommand();

        public string mensagem = "";

        public DataTable carregarCmbJobsLogs()
        {
            DataTable dtJobs = new DataTable();
            cmd.CommandText = "select ID, TIPO_AGENDAMENTO || ' - ' || ID as TIPO from JOBS order by TIPO_AGENDAMENTO";
            try
            {
                cmd.Connection = conexao.conectarBd();
                OracleDataReader reader = cmd.ExecuteReader();
                dtJobs.Load(reader);
                DataRow dr = dtJobs.NewRow();
                dr["ID"] = 0;
                dr["TIPO"] = "";
                dtJobs.Rows.InsertAt(dr, 0);
                reader.Close();
                reader.Dispose();
                conexao.desconectarBD();
            }
            catch (OracleException e)
            {
                mensagem = "Erro ao carregar a caixa combo JOBS LOGS: " + e.Message;
            }

            return dtJobs;
        }

        public DataTable GetLogs(string ID_JOB, string datainicial,string dataFinal,string erros = "0")
        {
            DataTable dtJobs = new DataTable();
            try 
            {
                cmd.CommandText = $"select ID,ID_JOB,TIPOARQUIVO,ERRO,DATA_EXECUCAO,HORA_EXECUCAO,TEMPO_INTEGRACAO,LOG " +
                $"from JOBSLOGS " +
                $"where ID_JOB = '{ID_JOB}' and " +
                $"(DATA_EXECUCAO >= '{datainicial}' and DATA_EXECUCAO <= '{dataFinal}') and ERRO = '{erros}'";

                cmd.Connection = conexao.conectarBd();
                OracleDataReader reader = cmd.ExecuteReader();
                dtJobs.Load(reader);
                reader.Close();
                reader.Dispose();
                conexao.desconectarBD();
            }
            catch (OracleException e)
            {
                mensagem = "Erro ao Consultar JOB LOG: " + e.Message;
            }

            return dtJobs;
        }

        public bool deleteJobsLogs(string id)
        {
            cmd.CommandText = "delete JOBSLOGS where ID = :ID";
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.Add("ID", id);
                cmd.Connection = conexao.conectarBd();
                cmd.ExecuteNonQuery();
                conexao.desconectarBD();

                return true;
            }
            catch (OracleException e)
            {
                mensagem = "Erro ao Excluir JOB LOG: " + e.Message;
                return false;
            }
        }
    }
}
