using AgendadorOperaCloud.Context;
using AgendadorOperaCloud.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace AgendadorOperaCloud.Controllers
{
    public class AgendadorCls
    {
        private BD conexao = new BD();
        private OracleCommand cmd = new OracleCommand();

        public string mensagem = "";

        public DataTable GetJobsAgendados()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select ID,RESORT,TIPOARQUIVO,ATIVO,TIPO_AGENDAMENTO," +
                "EXECUTAR_EM,DIAS_SEMANA,ARQUIVO_INTEGRACAO," +
                "REPETIR_RB,REPETIR_CADA_HHMM,EXECUTAR_EM_HORA,MESES_DIA " +
                "from JOBS order by TIPO_AGENDAMENTO";
            try
            {

                cmd.Connection = conexao.conectarBd();
                OracleDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
                conexao.desconectarBD();

                return dt;

            }
            catch (OracleException e)
            {
                mensagem = "Erro ao Consultar JOBS: " + e.Message;
            }

            return dt;
        }

        public DataTable GetJobsExecute()
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select ID,ID_JOB,JOB,RESORT,INICIO from JOBS_EXEC";
            try
            {

                cmd.Connection = conexao.conectarBd();
                OracleDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
                conexao.desconectarBD();

                return dt;

            }
            catch (OracleException e)
            {
                mensagem = "Erro ao Consultar JOBS_EXEC: " + e.Message;
            }

            return dt;
        }

        public bool insertJobsAgendados(AgendadorMdl agendador)
        {
            cmd.CommandText = "insert into JOBS (ID,RESORT,TIPOARQUIVO,ATIVO,TIPO_AGENDAMENTO," +
               "EXECUTAR_EM,DIAS_SEMANA,ARQUIVO_INTEGRACAO," +
               "REPETIR_RB,REPETIR_CADA_HHMM,EXECUTAR_EM_HORA,MESES_DIA) " +
               "values (:ID,:RESORT,:TIPOARQUIVO,:ATIVO,:TIPO_AGENDAMENTO,:EXECUTAR_EM," +
               ":DIAS_SEMANA,:ARQUIVO_INTEGRACAO,:REPETIR_RB,:REPETIR_CADA_HHMM," +
               ":EXECUTAR_EM_HORA,:MESES_DIA)";
            try
            {
                Random randNum = new Random();
                string aux = "";
                for (int i = 0; i <= 10; i++)
                    aux += randNum.Next(0, 9).ToString();

                cmd.Parameters.Clear();
                cmd.Parameters.Add("ID", aux);
                cmd.Parameters.Add("RESORT", agendador.RESORT);
                cmd.Parameters.Add("TIPOARQUIVO", agendador.TIPOARQUIVO);
                cmd.Parameters.Add("ATIVO", agendador.ATIVO);
                cmd.Parameters.Add("TIPO_AGENDAMENTO", agendador.TIPO_AGENDAMENTO);
                cmd.Parameters.Add("EXECUTAR_EM", agendador.EXECUTAR_EM);
                cmd.Parameters.Add("DIAS_SEMANA", agendador.DIAS_SEMANA);
                cmd.Parameters.Add("ARQUIVO_INTEGRACAO", agendador.ARQUIVO_INTEGRACAO);
                cmd.Parameters.Add("REPETIR_RB", agendador.REPETIR_RB);
                cmd.Parameters.Add("REPETIR_CADA_HHMM", agendador.REPETIR_CADA_HHMM);
                cmd.Parameters.Add("EXECUTAR_EM_HORA", agendador.EXECUTAR_EM_HORA);
                cmd.Parameters.Add("MESES_DIA", agendador.MESES_DIA);
                cmd.Connection = conexao.conectarBd();
                cmd.ExecuteNonQuery();
                conexao.desconectarBD();

                return true;

            }
            catch (OracleException e)
            {
                mensagem = "Erro ao Inserir JOB: " + e.Message;
                return false;
            }
        }

        public bool updateJobsAgendados(AgendadorMdl agendador)
        {
            cmd.CommandText = "update JOBS set RESORT = :RESORT,TIPOARQUIVO = :TIPOARQUIVO ,ATIVO = :ATIVO,TIPO_AGENDAMENTO = :TIPO_AGENDAMENTO," +
               "EXECUTAR_EM = :EXECUTAR_EM ,DIAS_SEMANA = :DIAS_SEMANA,ARQUIVO_INTEGRACAO = :ARQUIVO_INTEGRACAO," + 
               "REPETIR_RB = :REPETIR_RB ,REPETIR_CADA_HHMM = :REPETIR_CADA_HHMM ,EXECUTAR_EM_HORA = :EXECUTAR_EM_HORA ,MESES_DIA = :MESES_DIA," +
               " PROXIMA_EXECUCAO = :PROXIMA_EXECUCAO, PROXIMA_EXECUCAO_HORA = :PROXIMA_EXECUCAO_HORA " +
               "where ID = '"+ Program.idEdit + "'";
            try
            {
                cmd.Parameters.Clear();
                //cmd.Parameters.Add("ID", );
                cmd.Parameters.Add("RESORT", agendador.RESORT);
                cmd.Parameters.Add("TIPOARQUIVO", agendador.TIPOARQUIVO);
                cmd.Parameters.Add("ATIVO", agendador.ATIVO);
                cmd.Parameters.Add("TIPO_AGENDAMENTO", agendador.TIPO_AGENDAMENTO);
                cmd.Parameters.Add("EXECUTAR_EM", agendador.EXECUTAR_EM);
                cmd.Parameters.Add("DIAS_SEMANA", agendador.DIAS_SEMANA);
                cmd.Parameters.Add("ARQUIVO_INTEGRACAO", agendador.ARQUIVO_INTEGRACAO);
                cmd.Parameters.Add("REPETIR_RB", agendador.REPETIR_RB);
                cmd.Parameters.Add("REPETIR_CADA_HHMM", agendador.REPETIR_CADA_HHMM);
                cmd.Parameters.Add("EXECUTAR_EM_HORA", agendador.EXECUTAR_EM_HORA);
                cmd.Parameters.Add("MESES_DIA", agendador.MESES_DIA);
                cmd.Parameters.Add("PROXIMA_EXECUCAO", null);
                cmd.Parameters.Add("PROXIMA_EXECUCAO_HORA", null);
                cmd.Connection = conexao.conectarBd();
                cmd.ExecuteNonQuery();
                conexao.desconectarBD();

                return true;

            }
            catch (OracleException e)
            {
                mensagem = "Erro ao Atualizar JOB: " + e.Message;
                return false;
            }
        }
        public bool deleteJobsAgendados(string id)
        {
            cmd.CommandText = "delete JOBS where ID = :ID";
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
                mensagem = "Erro ao Excluir JOB: " + e.Message;
                return false;
            }
        }
        public DataTable carregarCmbTables()
        {
            DataTable dtTableNames = new DataTable();
            cmd.CommandText = "SELECT rownum ID,TABLE_NAME FROM USER_TABLES " +
                "where TABLESPACE_NAME = 'DEVILLE_ORACLECLOUD_DADOS' " +
                "AND TABLE_NAME not in ('JOBS','JOBS_EXEC','JOBSLOGS') " +
                "order by TABLE_NAME";
            try
            {
                cmd.Connection = conexao.conectarBd();
                OracleDataReader reader = cmd.ExecuteReader();
                dtTableNames.Load(reader);
                DataRow dr = dtTableNames.NewRow();
                dr["TABLE_NAME"] = "";
                dtTableNames.Rows.InsertAt(dr, 0);
                reader.Close();
                reader.Dispose();
                conexao.desconectarBD();
            }
            catch (OracleException e)
            {
                mensagem = "Erro ao carregar a caixa combo de Agendamento: " + e.Message;
            }

            return dtTableNames;
        }
    }
}
