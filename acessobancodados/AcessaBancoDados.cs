using System;
using System.Data;
using System.Data.Common;

namespace AcessoBancoDados
{
    public class AcessaBancoDados
    {

        // Informações para conexão com o banco de dados
        private int bandoDados;
        private string server;
        private string usuario;
        private string senha;
        private DbParameterCollection dbParameterCollection;
                
        public AcessaBancoDados(int bandoDados, string server = "", string usuario = "", string senha = "")
        {
            this.bandoDados = bandoDados;
            this.server = server;
            this.usuario = usuario;
            this.senha = senha;
            AcessaBancoProviderFactory.getSelecionaFactory(bandoDados);
            dbParameterCollection = AcessaBancoProviderFactory.getFactory().CreateCommand().Parameters;//.Parameters;
        }
       

        /// <sammary>
        /// Efetuar a limpeza da coleção de Paremetros para que não haja erro.
        /// </sammary>
        public void LimpaParametros()
        {
            // sqlParameterCollection.Clear();
            dbParameterCollection.Clear();
        }

        /// <sammary>
        /// Estou adiciondo novos paramestro a coleção, para ser usados
        /// </sammary>
        /// <param name="parametro">Nome do Parametro da Query ou Procedure</param>
        /// <param name="valor">Objeto com o calor do parametro</param>
        public void AdicionaParametros(string parametro, object valor)
        {
            DbParameter dbParameter = AcessaBancoProviderFactory.getFactory().CreateCommand().CreateParameter();
            dbParameter.ParameterName = parametro;
            dbParameter.Value = valor;
            dbParameterCollection.Add(dbParameter);
        }

        public void AdicionaParametrosType(string parametro, object valor, DbType type)
        {
            DbParameter dbParameter = AcessaBancoProviderFactory.getFactory().CreateCommand().CreateParameter();
            dbParameter.ParameterName = parametro;
            dbParameter.DbType = type;
            dbParameter.Value = valor;
            dbParameterCollection.Add(dbParameter);
        }

        /// <sammary>
        /// Metodo usado para efetuar as manipulações de 
        /// INSETR = Gravar informações no bando de dados
        /// UPDATE = Atualizar informações no bando de dados
        /// DELETE = Deletar informações no bando de dados
        /// </sammary>
        /// <param name="commandType">Tipo de comando que será usado no bando de dados</param>
        /// <param name="nomeProcedureOuTextoSql">Query ou nome da procedure que será usada.</param>
        /// 
        public object ExecultarManipulacao(CommandType commandType, string nomeProcedureOuTextoSql)
        {
            // Criando Conexão 
            DbConnection dbConnectio;
            dbConnectio = AcessaBancoProviderFactory.getConexao(server, usuario, senha);

            try
            {

                //Criando comandos
                DbCommand dbCommand = AcessaBancoProviderFactory.getFactory().CreateCommand();
                dbCommand.Connection = dbConnectio;

                dbCommand.CommandType = commandType;
                dbCommand.CommandText = nomeProcedureOuTextoSql;

                dbCommand.CommandTimeout = 7200; // Segundos = 2 Hs

                //Le os Paramentos.
                foreach (DbParameter parametro in dbParameterCollection)
                {
                    dbCommand.Parameters.Add(parametro);
                }

                // Execulta a Query.
                // E faz o retorno do valor para ser tratado.
                return dbCommand.ExecuteScalar();
            }
            catch(Exception e)
            {
                /*
                 * 
                 * Cria um novo tratamento de retorno para que a mensagem possa ser tratada 
                 * ou só aparesentada ao usuario.
                 * 
                 */
                throw new Exception(e.Message);
            }
            finally
            {
                dbConnectio.Close();
            }


        }

        /// <sammary>
        /// Metodo usado para efetuar as manipulações de 
        /// Select = Seleciona informações no bando de dados
        /// </sammary>
        /// <param name="commandType">Tipo de comando que será usado no bando de dados</param>
        /// <param name="nomeProcedureOuTextoSql">Query ou nome da procedure que será usada.</param>
        /// 

        public DataTable ExecultarConsulta(CommandType commandType, string nomeProcedureOuTextoSql)
        {
            //Cria DataTable
            DataTable dataTable = new DataTable();

            // Criando Conexão 
            DbConnection dbConnectio;
            dbConnectio = AcessaBancoProviderFactory.getConexao(server, usuario, senha);

            try
            {

                //Criando comandos
                DbCommand dbCommand = AcessaBancoProviderFactory.getFactory().CreateCommand();
                dbCommand.Connection = dbConnectio;

                dbCommand.CommandType = commandType;
                dbCommand.CommandText = nomeProcedureOuTextoSql;
                

                dbCommand.CommandTimeout = 7200; // Segundos = 2 Hs

                //Le os Paramentos.
                foreach (DbParameter parametro in dbParameterCollection)
                {
                    dbCommand.Parameters.Add(parametro);
                }

                // Cria Data Adapter
                DbDataAdapter dbDataAdapter = AcessaBancoProviderFactory.getFactory().CreateDataAdapter();
                dbDataAdapter.SelectCommand = dbCommand;
                //Exerculta Select
                dbDataAdapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                /*
                 * 
                 * Cria um novo tratamento de retorno para que a mensagem possa ser tratada 
                 * ou só aparesentada ao usuario.
                 * 
                 */
                throw new Exception(ex.Message);
            }
            finally
            {
                dbConnectio.Close();
            }

        }
    }
}
