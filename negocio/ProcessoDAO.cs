using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoBancoDados;
using System.Data;

namespace Negocio
{
    public class ProcessoDAO : IProcesso
    {
        AcessaBancoDados acessaBancoDados = new AcessaBancoDados(Definicoes.banco, Definicoes.server, Definicoes.usuario, Definicoes.senha);

        public object cadastroProcesso(Processo processo)
        {
            object id;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 0);
                acessaBancoDados.AdicionaParametros("VAR_PROC_ID", processo.PROC_ID);
                acessaBancoDados.AdicionaParametros("VAR_funcionario_fun_id", processo.funcionario_fun_id);
                acessaBancoDados.AdicionaParametros("VAR_PROC_PALAVRACHAVE", processo.PROC_PALAVRACHAVE);
                acessaBancoDados.AdicionaParametros("VAR_PROC_NATUREZA", processo.PROC_NATUREZA);
                acessaBancoDados.AdicionaParametros("VAR_PROC_NUMEROPROCESSO",processo.PROC_NUMEROPROCESSO.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PROC_CLASSEPROCEDIMENTO", processo.PROC_CLASSEPROCEDIMENTO.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PROC_AREA", processo.PROC_AREA.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PROC_COMPETENCIA", processo.PROC_COMPETENCIA.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PROC_FORUM", processo.PROC_FORUM.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PROC_COMARCA", processo.PROC_COMARCA.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PROC_VARA", processo.PROC_VARA.ToUpper());                
                acessaBancoDados.AdicionaParametros("VAR_PROC_INSTANCIA", processo.PROC_INSTANCIA.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PROC_VALORDACAUSA", processo.PROC_VALORDACAUSA.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PROC_ASSUNTO", processo.PROC_ASSUNTO.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PROC_DTCADASTRO", processo.PROC_DTCADASTRO.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspProcesso");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;
        }        
        public List<Processo> buscaProcesso()
        {
            List<Processo> listaProcesso = new List<Processo>();
            DataTable dtProcesso;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 3);
                acessaBancoDados.AdicionaParametros("VAR_PROC_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_funcionario_fun_id", null);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_NUMEROPROCESSO", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_CLASSEPROCEDIMENTO", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_AREA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_COMPETENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_FORUM", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_COMARCA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_VARA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_REU", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_INSTANCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_VALORDACAUSA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_ASSUNTO",  null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_DTCADASTRO", null);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtProcesso = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspProcesso");

                foreach (DataRow linha in dtProcesso.Rows)
                {
                    Processo proc = new Processo();

                    proc.PROC_ID = Convert.ToInt32(linha["PROC_ID"].ToString());
                    proc.funcionario_fun_id = Convert.ToInt32(linha["funcionario_fun_id"].ToString());
                    
                    proc.PROC_NUMEROPROCESSO = linha["PROC_NUMEROPROCESSO"].ToString();
                    proc.PROC_CLASSEPROCEDIMENTO = linha["PROC_CLASSEPROCEDIMENTO"].ToString();
                    proc.PROC_AREA = linha["PROC_AREA"].ToString();
                    proc.PROC_COMPETENCIA = linha["PROC_COMPETENCIA"].ToString();
                    proc.PROC_FORUM = linha["PROC_FORUM"].ToString();
                    proc.PROC_COMARCA = linha["PROC_COMARCA"].ToString();
                    proc.PROC_VARA = linha["PROC_VARA"].ToString();
                    
                    proc.PROC_INSTANCIA = linha["PROC_INSTANCIA"].ToString();
                    proc.PROC_VALORDACAUSA = linha["PROC_VALORDACAUSA"].ToString();
                    proc.PROC_ASSUNTO = linha["PROC_ASSUNTO"].ToString();
                    proc.PROC_DTCADASTRO = linha["PROC_DTCADASTRO"].ToString();
                    listaProcesso.Add(proc);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaProcesso;
        }
        public List<Processo> buscaProcesso(string id)
        {
            List<Processo> listaProcesso = new List<Processo>();
            DataTable dtProcesso;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 1);
                acessaBancoDados.AdicionaParametros("VAR_PROC_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_funcionario_fun_id", null);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Convert.ToInt32(id));
                acessaBancoDados.AdicionaParametros("VAR_PROC_NUMEROPROCESSO", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_CLASSEPROCEDIMENTO", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_AREA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_COMPETENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_FORUM", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_COMARCA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_VARA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_REU", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_INSTANCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_VALORDACAUSA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_ASSUNTO", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_DTCADASTRO", null);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtProcesso = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspProcesso");

                foreach (DataRow linha in dtProcesso.Rows)
                {
                    Processo proc = new Processo();

                    proc.PROC_ID = Convert.ToInt32(linha["PROC_ID"].ToString());
                    proc.funcionario_fun_id = Convert.ToInt32(linha["funcionario_fun_id"].ToString());
                    
                    proc.PROC_NUMEROPROCESSO = linha["PROC_NUMEROPROCESSO"].ToString();
                    proc.PROC_CLASSEPROCEDIMENTO = linha["PROC_CLASSEPROCEDIMENTO"].ToString();
                    proc.PROC_AREA = linha["PROC_AREA"].ToString();
                    proc.PROC_COMPETENCIA = linha["PROC_COMPETENCIA"].ToString();
                    proc.PROC_FORUM = linha["PROC_FORUM"].ToString();
                    proc.PROC_COMARCA = linha["PROC_COMARCA"].ToString();
                    proc.PROC_VARA = linha["PROC_VARA"].ToString();
                    
                    proc.PROC_INSTANCIA = linha["PROC_INSTANCIA"].ToString();
                    proc.PROC_VALORDACAUSA = linha["PROC_VALORDACAUSA"].ToString();
                    proc.PROC_ASSUNTO = linha["PROC_ASSUNTO"].ToString();
                    proc.PROC_DTCADASTRO = linha["PROC_DTCADASTRO"].ToString();
                    listaProcesso.Add(proc);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaProcesso;
        }
        public List<Processo> buscaProcesso(string id = "", string descricao = "")
        {
            List<Processo> listaProcesso = new List<Processo>();
            DataTable dtProcesso;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 2);
                acessaBancoDados.AdicionaParametros("VAR_PROC_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_funcionario_fun_id",Convert.ToInt32(descricao));
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Convert.ToInt32(id));
                acessaBancoDados.AdicionaParametros("VAR_PROC_NUMEROPROCESSO", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_CLASSEPROCEDIMENTO", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_AREA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_COMPETENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_FORUM", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_COMARCA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_VARA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_REU", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_INSTANCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_VALORDACAUSA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_ASSUNTO", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_DTCADASTRO", null);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtProcesso = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspProcesso");

                foreach (DataRow linha in dtProcesso.Rows)
                {
                    Processo proc = new Processo();

                    proc.PROC_ID = Convert.ToInt32(linha["PROC_ID"].ToString());
                    proc.funcionario_fun_id = Convert.ToInt32(linha["funcionario_fun_id"].ToString());
                    
                    proc.PROC_NUMEROPROCESSO = linha["PROC_NUMEROPROCESSO"].ToString();
                    proc.PROC_CLASSEPROCEDIMENTO = linha["PROC_CLASSEPROCEDIMENTO"].ToString();
                    proc.PROC_AREA = linha["PROC_AREA"].ToString();
                    proc.PROC_COMPETENCIA = linha["PROC_COMPETENCIA"].ToString();
                    proc.PROC_FORUM = linha["PROC_FORUM"].ToString();
                    proc.PROC_COMARCA = linha["PROC_COMARCA"].ToString();
                    proc.PROC_VARA = linha["PROC_VARA"].ToString();
                    
                    proc.PROC_INSTANCIA = linha["PROC_INSTANCIA"].ToString();
                    proc.PROC_VALORDACAUSA = linha["PROC_VALORDACAUSA"].ToString();
                    proc.PROC_ASSUNTO = linha["PROC_ASSUNTO"].ToString();
                    proc.PROC_DTCADASTRO = linha["PROC_DTCADASTRO"].ToString();
                    listaProcesso.Add(proc);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaProcesso;
        }
        public Processo buscaProcessoPro(string id)
        {
            Processo proc = new Processo();
            DataTable dtProcesso;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 5);
                acessaBancoDados.AdicionaParametros("VAR_PROC_ID", Convert.ToInt32(id));
                acessaBancoDados.AdicionaParametros("VAR_funcionario_fun_id",null);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_NUMEROPROCESSO", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_CLASSEPROCEDIMENTO", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_AREA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_COMPETENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_FORUM", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_COMARCA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_VARA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_REU", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_INSTANCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_VALORDACAUSA", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_ASSUNTO", null);
                acessaBancoDados.AdicionaParametros("VAR_PROC_DTCADASTRO", null);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtProcesso = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspProcesso");

                foreach (DataRow linha in dtProcesso.Rows)
                {
                    proc.PROC_ID = Convert.ToInt32(linha["PROC_ID"].ToString());
                    proc.funcionario_fun_id = Convert.ToInt32(linha["funcionario_fun_id"].ToString());
                    
                    proc.PROC_NUMEROPROCESSO = linha["PROC_NUMEROPROCESSO"].ToString();
                    proc.PROC_CLASSEPROCEDIMENTO = linha["PROC_CLASSEPROCEDIMENTO"].ToString();
                    proc.PROC_AREA = linha["PROC_AREA"].ToString();
                    proc.PROC_COMPETENCIA = linha["PROC_COMPETENCIA"].ToString();
                    proc.PROC_FORUM = linha["PROC_FORUM"].ToString();
                    proc.PROC_COMARCA = linha["PROC_COMARCA"].ToString();
                    proc.PROC_VARA = linha["PROC_VARA"].ToString();
                    
                    proc.PROC_INSTANCIA = linha["PROC_INSTANCIA"].ToString();
                    proc.PROC_VALORDACAUSA = linha["PROC_VALORDACAUSA"].ToString();
                    proc.PROC_ASSUNTO = linha["PROC_ASSUNTO"].ToString();
                    proc.PROC_DTCADASTRO = linha["PROC_DTCADASTRO"].ToString();                    
                }
            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return proc;
        }
        public object atualizaProcesso(Processo processo)
        {
            object id;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 4);
                acessaBancoDados.AdicionaParametros("VAR_PROC_ID", processo.PROC_ID);
                acessaBancoDados.AdicionaParametros("VAR_funcionario_fun_id", processo.funcionario_fun_id);
                
                acessaBancoDados.AdicionaParametros("VAR_PROC_NUMEROPROCESSO", processo.PROC_NUMEROPROCESSO.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PROC_CLASSEPROCEDIMENTO", processo.PROC_CLASSEPROCEDIMENTO.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PROC_AREA", processo.PROC_AREA.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PROC_COMPETENCIA", processo.PROC_COMPETENCIA.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PROC_FORUM", processo.PROC_FORUM.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PROC_COMARCA", processo.PROC_COMARCA.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PROC_VARA", processo.PROC_VARA.ToUpper());
                
                acessaBancoDados.AdicionaParametros("VAR_PROC_INSTANCIA", processo.PROC_INSTANCIA.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PROC_VALORDACAUSA", processo.PROC_VALORDACAUSA.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PROC_ASSUNTO", processo.PROC_ASSUNTO.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_PROC_DTCADASTRO", processo.PROC_DTCADASTRO.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);

                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspProcesso");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return id;
        }
        public bool deletaProcesso(string id)
        {
            throw new NotImplementedException();
        }
        public bool equals(Processo cliente)
        {
            throw new NotImplementedException();
        }
    }
}

