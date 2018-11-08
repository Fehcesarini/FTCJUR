using AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class PrevidenciarioDAO : IPrevidenciario
    {
        AcessaBancoDados acessaBancoDados = new AcessaBancoDados(Definicoes.banco, Definicoes.server, Definicoes.usuario, Definicoes.senha);
        //Função Funcionando 20/01
        public object cadastroPrevidenciario(Previdenciario previdenciario)
        {
            object id;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 0);
                acessaBancoDados.AdicionaParametros("VAR_PREV_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_PREV_CTPS", previdenciario.carteiraTrabalho.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PREV_CNIS", previdenciario.CNIS.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PREV_BENEFICIOS", previdenciario.benificio.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PREV_APOSENTADORIA", previdenciario.aposentadoria.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PREV_PROCEDIMENTOADM", previdenciario.procedimentoADM.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PREV_OBS", null);                
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspPrevidenciario");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;
        }

        //Função Funcioando 25/01
        public object atualizaPrevidenciario(Previdenciario previdenciario)
        {
            object id;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 2);
                acessaBancoDados.AdicionaParametros("VAR_PREV_ID", previdenciario.id);
                acessaBancoDados.AdicionaParametros("VAR_PREV_CTPS", previdenciario.carteiraTrabalho.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PREV_CNIS", previdenciario.CNIS.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PREV_BENEFICIOS", previdenciario.benificio.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PREV_APOSENTADORIA", previdenciario.aposentadoria.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PREV_PROCEDIMENTOADM", previdenciario.procedimentoADM.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PREV_OBS", null);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspPrevidenciario");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return id;
        }

        //Função Funcionando 20/01
        public List<Previdenciario> buscaPrevidenciario()
        {
            List<Previdenciario> listaPrevidenciario = new List<Previdenciario>();
            DataTable dtPrevidenciario;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 0);
                acessaBancoDados.AdicionaParametros("VAR_PREV_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_PREV_CTPS", null);
                acessaBancoDados.AdicionaParametros("VAR_PREV_CNIS", null);
                acessaBancoDados.AdicionaParametros("VAR_PREV_BENEFICIOS", null);
                acessaBancoDados.AdicionaParametros("VAR_PREV_APOSENTADORIA", null);
                acessaBancoDados.AdicionaParametros("VAR_PREV_PROCEDIMENTOADM", null);
                acessaBancoDados.AdicionaParametros("VAR_PREV_OBS", null);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtPrevidenciario = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspPenal");

                foreach (DataRow linha in dtPrevidenciario.Rows)
                {
                    Previdenciario previdenciario = new Previdenciario();

                    previdenciario.id = Convert.ToInt32(linha["PREV_ID "].ToString());
                    previdenciario.carteiraTrabalho = linha["PREV_CTPS"].ToString();
                    previdenciario.CNIS = linha["PREV_CNIS"].ToString();
                    previdenciario.benificio = linha["PREV_BENEFICIOS"].ToString();
                    previdenciario.aposentadoria = linha["PREV_APOSENTADORIA"].ToString();
                    previdenciario.procedimentoADM = linha["PREV_PROCEDIMENTOADM"].ToString();
                    previdenciario.obs = linha["PREV_OBS"].ToString();                    
                    listaPrevidenciario.Add(previdenciario);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaPrevidenciario;
        }



        public bool equals(Previdenciario previdenciario)
        {
            throw new NotImplementedException();
        }

    }
}
