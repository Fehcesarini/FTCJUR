using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Net;

namespace AcessoBancoDados
{
    class AcessaBancoProviderFactory : DbProviderFactory
    {

        // Criar os Objetos de conexão
        private static string connectionSatring;
        private static DbConnection connUnica = null;

        // Define os tipos de conexão
        private static readonly int SqlServer = 0;
        private static readonly int MySql = 1;
        private static readonly int MySqlSerialKey = 2;

        // Usado para fazer a denifição do Driver de conexão
        private static DbProviderFactory factory;

        // Banco de Dados Selecionado
        private static int bancoDados;

        public static void getSelecionaFactory(int banco)
        {

            bancoDados = banco;
            factory = new AcessaBancoProviderFactory();
            
            switch (banco)
            {
                case 0: // SqlServer
                    factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                    break;

                case 1: // MySql 
                    factory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
                    break;
                case 2: // MySql 
                    factory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
                    break;

                default:
                    throw new Exception("Banco de Dados não configurado");

            }
        }

        public static DbConnection getConexao(string server = "", string usuario = "", string senha = "")
        {
            // factory = new AcessaBancoProviderFactory();
            if(bancoDados == SqlServer)
            {
                try
                {
                    connectionSatring = @"Data Source="+server+";Initial Catalog=dbGames;Integrated Security=True";
                    connUnica = factory.CreateConnection();
                    connUnica.ConnectionString = connectionSatring;
                    connUnica.Open();

                }
                catch(DbException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else if(bancoDados == MySql)
            {


                try
                {
                    connectionSatring = @"Persist Security Info=False;" +
                                          "server=" + server + ";database=dbjuridico;server=" + server + ";" +
                                          "uid=" + usuario + ";pwd=" + senha + ";";
                   

                    connUnica = factory.CreateConnection();
                    connUnica.ConnectionString = connectionSatring;
                    connUnica.Open();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            else if (bancoDados == MySqlSerialKey)
            {
                try
                {
                    connectionSatring = @"server=" + server +
                                         ";port=41890;" +
                                         "database=serialkey;" +
                                         "uid=" + usuario + ";pwd=" + senha + ";";


                    connUnica = factory.CreateConnection();
                    connUnica.ConnectionString = connectionSatring;
                    connUnica.Open();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            return connUnica;
        }

        public static void getCloseConnection()
        {
            connUnica.Close();
        }

        // Recupera Driver
        public static DbProviderFactory getFactory()
        {
            return factory;
        }
              
    }
}
