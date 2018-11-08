using AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class DadoBancarioDAO : IDadoBancario
    {
        AcessaBancoDados acessaBancoDados = new AcessaBancoDados(Definicoes.banco, Definicoes.server, Definicoes.usuario, Definicoes.senha);


        //Função Abaixo Completa 19/01
        public object atualizaDadoBancario(DadoBancario dadobancario)
        {
            object id;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 2);
                acessaBancoDados.AdicionaParametros("VAR_BAN_ID", dadobancario.id);
                acessaBancoDados.AdicionaParametros("VAR_BAN_BANCO", dadobancario.banco.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_BAN_AGENCIA", dadobancario.Agencia.ToString());
                acessaBancoDados.AdicionaParametros("VAR_BAN_CONTA", dadobancario.TipoConta.ToString());
                acessaBancoDados.AdicionaParametros("VAR_BAN_NUMERO", dadobancario.numero.ToString());
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspBanco");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;
        }


        //Função Abaixo Completa 19/01
        public List<DadoBancario> dadobancario()
        {

            List<DadoBancario> listadadobancario = new List<DadoBancario>();
            DataTable dtdadobancario;
            try
            {
                DadoBancario dadobancario = new DadoBancario();
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 1);
                acessaBancoDados.AdicionaParametros("VAR_BAN_ID", dadobancario.id);
                acessaBancoDados.AdicionaParametros("VAR_BAN_BANCO", dadobancario.banco.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_BAN_AGENCIA", dadobancario.Agencia.ToString());
                acessaBancoDados.AdicionaParametros("VAR_BAN_CONTA", dadobancario.TipoConta.ToString());
                acessaBancoDados.AdicionaParametros("VAR_BAN_NUMERO", dadobancario.numero.ToString());
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtdadobancario = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspBanco");

                foreach (DataRow linha in dtdadobancario.Rows)
                {

                    dadobancario.id = Convert.ToInt32(linha["BAN_ID"]);
                    dadobancario.banco = linha["BAN_BANCO"].ToString();
                    dadobancario.Agencia = linha["BAN_AGENCIA"].ToString();
                    dadobancario.TipoConta = linha["BAN_CONTA"].ToString();
                    dadobancario.numero = linha["BAN_NUMERO"].ToString();
                    listadadobancario.Add(dadobancario);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listadadobancario;

        }





        //Função Abaixo Completa 19/01
        public object cadastroDadoBancario(DadoBancario dadobancario)
        {

            object id;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 0);
                acessaBancoDados.AdicionaParametros("VAR_BAN_ID", dadobancario.id);
                acessaBancoDados.AdicionaParametros("VAR_BAN_BANCO", dadobancario.banco.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_BAN_AGENCIA", dadobancario.Agencia.ToString());
                acessaBancoDados.AdicionaParametros("VAR_BAN_CONTA", dadobancario.TipoConta.ToString());
                acessaBancoDados.AdicionaParametros("VAR_BAN_NUMERO", dadobancario.numero.ToString());
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspBanco");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;

        }


        public bool equals(DadoBancario dadobancario)
        {
            throw new NotImplementedException();
        }

    }
}
