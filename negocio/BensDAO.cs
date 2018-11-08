using AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BensDAO : IBens
    {
        AcessaBancoDados acessaBancoDados = new AcessaBancoDados(Definicoes.banco, Definicoes.server, Definicoes.usuario, Definicoes.senha);
        //Função Funcionando 20/01
        public object cadastroBens(Bens bens)
        {
            object id;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 0);
                acessaBancoDados.AdicionaParametros("VAR_BEN_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_BEN_DESCRICAO", bens.descricaodoben.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_BEN_VALOR", bens.valorBens.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_BEN_TIPO", bens.tipoImovel.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_BEN_OBS", bens.obs.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_BEN_DELETE", false.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);                
                acessaBancoDados.AdicionaParametros("@VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);

                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspBens");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;
        }

        //Função Funcioando 25/01
        public object atualizaBens(Bens bens)
        {
            object id;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 2);
                acessaBancoDados.AdicionaParametros("VAR_BEN_ID", bens.id);
                acessaBancoDados.AdicionaParametros("VAR_BEN_DESCRICAO", bens.descricaodoben);
                acessaBancoDados.AdicionaParametros("VAR_BEN_VALOR", bens.valorBens.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_BEN_TIPO", bens.tipoImovel.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_BEN_OBS", bens.obs.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_BEN_DELETE", false.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);

                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspBens");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return id;
        }

        //Função Funcionando 20/01
        public List<Bens> buscaBens()
        {
            List<Bens> listaBens = new List<Bens>();
            DataTable dtBens;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 1);
                acessaBancoDados.AdicionaParametros("VAR_BEN_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_BEN_DESCRICAO", null);
                acessaBancoDados.AdicionaParametros("VAR_BEN_VALOR", null);
                acessaBancoDados.AdicionaParametros("VAR_BEN_TIPO", null);
                acessaBancoDados.AdicionaParametros("VAR_BEN_OBS", null);
                acessaBancoDados.AdicionaParametros("VAR_BEN_DELETE", null);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtBens = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspBens");

                foreach (DataRow linha in dtBens.Rows)
                {
                    Bens bens = new Bens();

                    bens.id = Convert.ToInt32(linha["BEN_ID"].ToString());
                    bens.descricaodoben = linha["BEN_DESCRICAO"].ToString();
                    bens.valorBens = linha["BEN_VALOR"].ToString();
                    bens.tipoImovel = linha["BEN_TIPO"].ToString();
                    bens.obs = linha["BEN_OBS"].ToString();
                    bens.delete = linha["BEN_DELETE"].ToString();
                    listaBens.Add(bens);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaBens;
        }
        public Bens buscaBensDGV(string id)
        {
            Bens bensreturn = new Bens();
            DataTable dtBens;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 4);
                acessaBancoDados.AdicionaParametros("VAR_BEN_ID", id);
                acessaBancoDados.AdicionaParametros("VAR_BEN_DESCRICAO", null);
                acessaBancoDados.AdicionaParametros("VAR_BEN_VALOR", null);
                acessaBancoDados.AdicionaParametros("VAR_BEN_TIPO", null);
                acessaBancoDados.AdicionaParametros("VAR_BEN_OBS", null);
                acessaBancoDados.AdicionaParametros("VAR_BEN_DELETE", null);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtBens = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspBens");

                foreach (DataRow linha in dtBens.Rows)
                {


                    bensreturn.id = Convert.ToInt32(linha["BEN_ID"].ToString());
                    bensreturn.descricaodoben = linha["BEN_DESCRICAO"].ToString();
                    bensreturn.valorBens = linha["BEN_VALOR"].ToString();
                    bensreturn.tipoImovel = linha["BEN_TIPO"].ToString();
                    bensreturn.obs = linha["BEN_OBS"].ToString();
                    bensreturn.delete = linha["BEN_DELETE"].ToString();
                    
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return bensreturn;
        }

        public bool deletaBens(string id)
        {
            bool lRetorn = false;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 3);
                acessaBancoDados.AdicionaParametros("VAR_BEN_ID", id);
                acessaBancoDados.AdicionaParametros("VAR_BEN_DESCRICAO", null);
                acessaBancoDados.AdicionaParametros("VAR_BEN_VALOR", null);
                acessaBancoDados.AdicionaParametros("VAR_BEN_TIPO", null);
                acessaBancoDados.AdicionaParametros("VAR_BEN_OBS", null);
                acessaBancoDados.AdicionaParametros("VAR_BEN_DELETE", true.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspBens");

                lRetorn = true;
            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return lRetorn;
        }

        public bool equals(Bens bens)
        {
            throw new NotImplementedException();
        }
    }
}
