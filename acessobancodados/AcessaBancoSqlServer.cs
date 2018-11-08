using System;
using System.Data;
using System.Data.SqlClient;

namespace AcessoBancoDados
{
    public class AcessaBancoSqlServer
    {

        #region Atributos e Propriedades
        /// <sammary>
        /// Para criar um objeto service é obrigatorio informar o nome da Stringconnection informada no Settings.settings
        /// </sammary>
        private SqlConnection CriaConexao()
        {
            return new SqlConnection("");
        }


        #endregion

        #region Atributos e Propriedades
        /// <sammary>
        /// Esta sendo criado a coleção de Parametros que iram existir dentro do QueryString ou que 
        /// devem ser passados para uma procedure.
        /// </sammary>
        private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;

        /// <sammary>
        /// Efetuar a limpeza da coleção de Paremetros para que não haja erro.
        /// </sammary>
        public void LimpaParametros()
        {
            sqlParameterCollection.Clear();
        }

        /// <sammary>
        /// Estou adiciondo novos paramestro a coleção, para ser usados
        /// </sammary>
        /// <param name="parametro">Nome do Parametro da Query ou Procedure</param>
        /// <param name="valor">Objeto com o calor do parametro</param>
        public void AdicionaParametros(string parametro, object valor)
        {
            sqlParameterCollection.Add(new SqlParameter(parametro, valor));
        }
        #endregion


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
            //Criando Conexão 
            SqlConnection sqlConnectio;
            sqlConnectio = CriaConexao();

            try
            {    
                sqlConnectio.Open();

                //Criando comandos
                SqlCommand sqlCommand = sqlConnectio.CreateCommand();
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeProcedureOuTextoSql;
                sqlCommand.CommandTimeout = 7200; // Segundos = 2 Hs

                //Le os Paramentos.
                foreach (SqlParameter parametro in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(parametro.ParameterName, parametro.Value));
                }

                // Execulta a Query.
                // E faz o retorno do valor para ser tratado.
                return sqlCommand.ExecuteScalar();
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
                sqlConnectio.Close();
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
            //Criando Conexão 
            SqlConnection sqlConnectio = CriaConexao();
            sqlConnectio.Open();

            try
            {
                
                //Criando comandos
                SqlCommand sqlCommand = sqlConnectio.CreateCommand();
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeProcedureOuTextoSql;
                sqlCommand.CommandTimeout = 7200; // Segundos = 2 Hs

                //Le os Paramentos.
                foreach (SqlParameter parametro in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(parametro.ParameterName, parametro.Value));
                }

                //Cria Adaptador
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                //Cria DataTable
                DataTable dataTable = new DataTable();

                //Exerculta Select
                sqlDataAdapter.Fill(dataTable);

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
                sqlConnectio.Close();
            }

        }

    }
}
