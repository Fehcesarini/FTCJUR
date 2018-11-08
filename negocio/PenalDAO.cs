using AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class PenalDAO : IPenal
    {
        AcessaBancoDados acessaBancoDados = new AcessaBancoDados(Definicoes.banco, Definicoes.server, Definicoes.usuario, Definicoes.senha);
        //Função Funcionando 20/01
        public object cadastroPenal(Penal penal)
        {
            object id;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 0);
                acessaBancoDados.AdicionaParametros("VAR_PEN_ID", penal.id);
                acessaBancoDados.AdicionaParametros("VAR_PEN_CRIME", penal.crime.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_ACAOPENAL", penal.acao_penal.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_RITOPROCESSUAL", penal.rito_processual.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_SUSPENCAOCONDICIONAL", penal.suspensao_condicional_processo.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_LIVRAMENTOCONDICIONAL", penal.livramento_condicional.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_REINCIDENTE", penal.reincidente.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_REGIMEPRISIONAL", penal.regime_prisional.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_ATENUANTES", penal.atenuantes.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_AGRAVANTES", penal.agravantes.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_MAJORANTES", penal.majorantes.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_MINORANTES", penal.minorantes.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_QUALIFICADORAS", penal.qualificadoras.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspPenal");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;
        }

        //Função Funcioando 25/01
        public object atualizaPenal(Penal penal)
        {
            object id;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 2);
                acessaBancoDados.AdicionaParametros("VAR_PEN_ID", penal.id);
                acessaBancoDados.AdicionaParametros("VAR_PEN_CRIME", penal.crime.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_ACAOPENAL", penal.acao_penal.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_RITOPROCESSUAL", penal.rito_processual.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_SUSPENCAOCONDICIONAL", penal.suspensao_condicional_processo.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_LIVRAMENTOCONDICIONAL", penal.livramento_condicional.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_REINCIDENTE", penal.reincidente.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_REGIMEPRISIONAL", penal.regime_prisional.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_ATENUANTES", penal.atenuantes.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_AGRAVANTES", penal.agravantes.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_MAJORANTES", penal.majorantes.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_MINORANTES", penal.minorantes.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PEN_QUALIFICADORAS", penal.qualificadoras.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);

                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspPenal");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return id;
        }

        //Função Funcionando 20/01
        public List<Penal> buscaPenal()
        {
            List<Penal> listaPenal = new List<Penal>();
            DataTable dtPenal;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 1);
                acessaBancoDados.AdicionaParametros("VAR_PEN_ID",null);
                acessaBancoDados.AdicionaParametros("VAR_PEN_CRIME", null);
                acessaBancoDados.AdicionaParametros("VAR_PEN_ACAOPENAL", null);
                acessaBancoDados.AdicionaParametros("VAR_PEN_RITOPROCESSUAL", null);
                acessaBancoDados.AdicionaParametros("VAR_PEN_SUSPENCAOCONDICIONAL", null);
                acessaBancoDados.AdicionaParametros("VAR_PEN_LIVRAMENTOCONDICIONAL", null);
                acessaBancoDados.AdicionaParametros("VAR_PEN_REINCIDENTE", null);
                acessaBancoDados.AdicionaParametros("VAR_PEN_REGIMEPRISIONAL", null);
                acessaBancoDados.AdicionaParametros("VAR_PEN_ATENUANTES", null);
                acessaBancoDados.AdicionaParametros("VAR_PEN_AGRAVANTES", null);
                acessaBancoDados.AdicionaParametros("VAR_PEN_MAJORANTES", null);
                acessaBancoDados.AdicionaParametros("VAR_PEN_MINORANTES", null);
                acessaBancoDados.AdicionaParametros("VAR_PEN_QUALIFICADORAS", null);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtPenal = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspPenal");

                foreach (DataRow linha in dtPenal.Rows)
                {
                    Penal penal = new Penal();

                    penal.id = Convert.ToInt32(linha["PEN_ID"].ToString());
                    penal.crime = linha["PEN_CRIME"].ToString();
                    penal.acao_penal = linha["PEN_ACAOPENAL"].ToString();
                    penal.rito_processual = linha["PEN_RITOPROCESSUAL"].ToString();
                    penal.suspensao_condicional_processo = linha["PEN_SUSPENCAOCONDICIONAL"].ToString();
                    penal.livramento_condicional = linha["PEN_LIVRAMENTOCONDICIONAL"].ToString();
                    penal.reincidente = linha["PEN_REINCIDENTE"].ToString();
                    penal.regime_prisional = linha["PEN_REGIMEPRISIONAL"].ToString();
                    penal.atenuantes = linha["PEN_ATENUANTES"].ToString();
                    penal.agravantes = linha["PEN_AGRAVANTES"].ToString();
                    penal.majorantes = linha["PEN_MAJORANTES"].ToString();
                    penal.minorantes = linha["PEN_MINORANTES"].ToString();
                    penal.qualificadoras = linha["PEN_QUALIFICADORAS"].ToString();
                    listaPenal.Add(penal);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaPenal;
        }



        public bool  equals(Penal penal)
        {
            throw new NotImplementedException();
        }

    }
}
