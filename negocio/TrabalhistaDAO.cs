using AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class TrabalhistaDAO : ITrabalhista
    {
        AcessaBancoDados acessaBancoDados = new AcessaBancoDados(Definicoes.banco, Definicoes.server, Definicoes.usuario, Definicoes.senha);
        //Função Funcionando 20/01
        public object cadastroTrabalhista(Trabalhista trabalhista)
        {
            object id;
            try
            {
                
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 0);
                acessaBancoDados.AdicionaParametros("VAR_TRAB_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_TRAB_NUMEROPIS", trabalhista.PIS);
                acessaBancoDados.AdicionaParametros("VAR_TRAB_REGISTROCTPS", trabalhista.CTPS);
                acessaBancoDados.AdicionaParametros("VAR_TRAB_FGTS", trabalhista.FGTS.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_TRAB_SEGURODESEMPREGO", trabalhista.seguroDesemprego.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_TRAB_AVISOPREVIO", trabalhista.avisoPrevio.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_TRAB_LINCENCAS", trabalhista.licencaMaternidade.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_TRAB_ADVERTENCIAS", trabalhista.advertencia.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_TRAB_OBS", trabalhista.obs.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspTrabalhista");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;
        }

        //Função Funcioando 25/01
        public object atualizaTrabalhista(Trabalhista trabalhista)
        {
            object id;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 2);
                acessaBancoDados.AdicionaParametros("VAR_TRAB_ID", trabalhista.id);
                acessaBancoDados.AdicionaParametros("VAR_TRAB_NUMEROPIS", trabalhista.PIS);
                acessaBancoDados.AdicionaParametros("VAR_TRAB_REGISTROCTPS", trabalhista.CTPS);
                acessaBancoDados.AdicionaParametros("VAR_TRAB_FGTS", trabalhista.FGTS.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_TRAB_SEGURODESEMPREGO", trabalhista.seguroDesemprego.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_TRAB_AVISOPREVIO", trabalhista.avisoPrevio.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_TRAB_LINCENCAS", trabalhista.licencaMaternidade.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_TRAB_ADVERTENCIAS", trabalhista.advertencia.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_TRAB_OBS", trabalhista.obs.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);

                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspTrabalhista");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return id;
        }

        //Função Funcionando 20/01
        public List<Trabalhista> buscaTrabalhista()
        {
            List<Trabalhista> listaTrabalhista = new List<Trabalhista>();
            DataTable dtTrabalhista;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 2);
                acessaBancoDados.AdicionaParametros("VAR_TRAB_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_TRAB_NUMEROPIS", null);
                acessaBancoDados.AdicionaParametros("VAR_TRAB_REGISTROCTPS", null);
                acessaBancoDados.AdicionaParametros("VAR_TRAB_FGTS", null);
                acessaBancoDados.AdicionaParametros("VAR_TRAB_SEGURODESEMPREGO", null);
                acessaBancoDados.AdicionaParametros("VAR_TRAB_AVISOPREVIO", null);
                acessaBancoDados.AdicionaParametros("VAR_TRAB_LINCENCAS", null);
                acessaBancoDados.AdicionaParametros("VAR_TRAB_ADVERTENCIAS", null);
                acessaBancoDados.AdicionaParametros("VAR_TRAB_OBS", null);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtTrabalhista = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspTrabalhista");

                foreach (DataRow linha in dtTrabalhista.Rows)
                {
                    Trabalhista trabalhista = new Trabalhista();

                    trabalhista.id = Convert.ToInt32(linha["TRAB_ID"].ToString());
                    trabalhista.PIS  = linha["TRAB_NUMEROPIS"].ToString();
                    trabalhista.CTPS = linha["TRAB_REGISTROCTPS"].ToString();
                    trabalhista.FGTS = linha["TRAB_FGTS"].ToString();
                    trabalhista.seguroDesemprego = linha["TRAB_SEGURODESEMPREGO"].ToString();
                    trabalhista.avisoPrevio = linha["TRAB_AVISOPREVIO"].ToString();
                    trabalhista.licencaMaternidade = linha["TRAB_LINCENCAS"].ToString();
                    trabalhista.advertencia = linha["TRAB_ADVERTENCIAS"].ToString();
                    trabalhista.obs = linha["TRAB_OBS"].ToString();
                    listaTrabalhista.Add(trabalhista);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaTrabalhista;
        }
        
               

        public bool equals(Trabalhista trabalhista)
        {
            throw new NotImplementedException();
        }


    }
}
