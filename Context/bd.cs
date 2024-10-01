using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace AgendadorOperaCloud.Context
{
    public class BD
    {
        OracleConnection conn = new OracleConnection();

        public BD()
        {
            if(Program._Configuration != null)
            {
                conn.ConnectionString = Program._Configuration.GetConnectionString("DbConnection");
            }
            else
            {
                MessageBox.Show("Arquivo de configuração appsettings.json não encontrado!","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public OracleConnection conectarBd()
        {
            if (conn.State == ConnectionState.Closed)
            {
                try 
                { 
                    conn.Open(); 
                } 
                catch (Exception ex)
                {
                    MessageBox.Show("A aplicação não conseguiu se conectar ao banco de dados!\n "+ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            return conn;
        }

        public void desconectarBD()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

    }
}
