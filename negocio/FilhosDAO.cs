using AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class FilhosDAO : IFilhos
    {

        AcessaBancoDados acessaBancoDados = new AcessaBancoDados(Definicoes.banco, Definicoes.server, Definicoes.usuario, Definicoes.senha);
        //Função Funcionando 20/01
        public object cadastroFilhos(Filhos filhos)
        {
            object id;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 0);
                acessaBancoDados.AdicionaParametros("VAR_FIL_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_NOME", filhos.nome);
                acessaBancoDados.AdicionaParametros("VAR_FIL_CPFCNPJ", filhos.cpf);
                acessaBancoDados.AdicionaParametros("VAR_FIL_RGIE", filhos.rg.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_FIL_DTNASCIMENTO", filhos.dtnascimento.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_FIL_SEXO", filhos.sexo.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_FIL_OBS", filhos.obs.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_FIL_DELELTE", false.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspFilho");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;
        }

        //Função Funcioando 25/01
        public object atualizaFilhos(Filhos filhos)
        {
            object id;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 2);
                acessaBancoDados.AdicionaParametros("VAR_FIL_ID", filhos.id);
                acessaBancoDados.AdicionaParametros("VAR_FIL_NOME", filhos.nome);
                acessaBancoDados.AdicionaParametros("VAR_FIL_CPFCNPJ", filhos.cpf);
                acessaBancoDados.AdicionaParametros("VAR_FIL_RGIE", filhos.rg.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_FIL_DTNASCIMENTO", filhos.dtnascimento.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_FIL_SEXO", filhos.sexo.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_FIL_OBS", filhos.obs.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_FIL_DELELTE", false.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);

                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspFilho");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return id;
        }

        //Função Funcionando 20/01
        public List<Filhos> buscaFilhos()
        {
            List<Filhos> listaFilhos = new List<Filhos>();
            DataTable dtFilhos;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 1);
                acessaBancoDados.AdicionaParametros("VAR_FIL_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_NOME", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_CPFCNPJ", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_RGIE", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_DTNASCIMENTO", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_SEXO", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_OBS", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_DELELTE", false.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtFilhos = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspFilho");

                foreach (DataRow linha in dtFilhos.Rows)
                {
                    Filhos filhos = new Filhos();

                    filhos.id = Convert.ToInt32(linha["FIL_ID"].ToString());
                    filhos.nome = linha["FIL_NOME"].ToString();
                    filhos.cpf = linha["FIL_CPFCNPJ"].ToString();
                    filhos.rg = linha["FIL_RGIE"].ToString();
                    filhos.dtnascimento = Convert.ToDateTime(linha["FIL_DTNASCIMENTO"].ToString());
                    filhos.sexo = linha["FIL_SEXO"].ToString();
                    filhos.obs = linha["FIL_OBS"].ToString();
                    filhos.delete = linha["FIL_DELELTE"].ToString();
                    listaFilhos.Add(filhos);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaFilhos;
        }

        public Filhos buscaFilhosDGV(string id)
        {
            Filhos filhos = new Filhos();
            DataTable dtFilhos;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 4);
                acessaBancoDados.AdicionaParametros("VAR_FIL_ID", id );
                acessaBancoDados.AdicionaParametros("VAR_FIL_NOME", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_CPFCNPJ", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_RGIE", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_DTNASCIMENTO", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_SEXO", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_OBS", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_DELELTE", false.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtFilhos = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspFilho");

                foreach (DataRow linha in dtFilhos.Rows)
                {
                    

                    filhos.id = Convert.ToInt32(linha["FIL_ID"].ToString());
                    filhos.nome = linha["FIL_NOME"].ToString();
                    filhos.cpf = linha["FIL_CPFCNPJ"].ToString();
                    filhos.rg = linha["FIL_RGIE"].ToString();
                    filhos.dtnascimento = Convert.ToDateTime(linha["FIL_DTNASCIMENTO"].ToString());
                    filhos.sexo = linha["FIL_SEXO"].ToString();
                    filhos.obs = linha["FIL_OBS"].ToString();
                    filhos.delete = linha["FIL_DELELTE"].ToString();
                    
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return filhos;
        }



        public bool deletaFilhos(string id)
        {
            bool lRetorn = false;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 3);
                acessaBancoDados.AdicionaParametros("VAR_FIL_ID", id);
                acessaBancoDados.AdicionaParametros("VAR_FIL_NOME", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_CPFCNPJ", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_RGIE", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_DTNASCIMENTO", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_SEXO", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_OBS", null);
                acessaBancoDados.AdicionaParametros("VAR_FIL_DELELTE", true.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspFilho");

                lRetorn = true;
            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return lRetorn;
        }

        public bool equals(Filhos filhos)
        {
            throw new NotImplementedException();
        }


    }
}
