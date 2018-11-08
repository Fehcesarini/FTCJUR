using AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class ProcessoPessoaVincDAO: IProcessoPessoaVinc
    {
        AcessaBancoDados acessaBancoDados = new AcessaBancoDados(Definicoes.banco, Definicoes.server, Definicoes.usuario, Definicoes.senha);

        public object cadastroProcesso(ProcessoPessoaVinc processopessoavinc)
        {
            object id;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 0);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", processopessoavinc.cliente_CLI_ID);
                acessaBancoDados.AdicionaParametros("VAR_processo_PROC_ID", processopessoavinc.processo_PROC_ID);                
                acessaBancoDados.AdicionaParametros("VAR_CLI_PRO_TIPOCLIENTEPROC", processopessoavinc.CLI_PRO_TIPOCLIENTEPROC);
                acessaBancoDados.AdicionaParametros("VAR_CLI_PRO_CLIENTEESCRITORIO", processopessoavinc.CLI_PRO_CLIENTEESCRITORIO);
                acessaBancoDados.AdicionaParametros("VAR_BUSCACODIGO", null);
                acessaBancoDados.AdicionaParametros("VAR_BUSCATEXTO", null);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                
                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspProcessoClienteVinc");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;
        }
        public List<ProcessoPessoaVinc> buscaProcesso(string id = "", string descricao = "")
        {
            List<ProcessoPessoaVinc> listaProcesso = new List<ProcessoPessoaVinc>();
            DataTable dtProcesso;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 1);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_processo_PROC_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_PRO_TIPOCLIENTEPROC", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_PRO_CLIENTEESCRITORIO", null);
                acessaBancoDados.AdicionaParametros("VAR_BUSCACODIGO", id);
                acessaBancoDados.AdicionaParametros("VAR_BUSCATEXTO", descricao);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtProcesso = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspProcessoClienteVinc");

                foreach (DataRow linha in dtProcesso.Rows)
                {
                    ProcessoPessoaVinc proc = new ProcessoPessoaVinc();

                    proc.cliente_CLI_ID = Convert.ToInt32(linha["cliente_CLI_ID"].ToString());
                    proc.processo_PROC_ID = Convert.ToInt32(linha["processo_PROC_ID"].ToString());
                    proc.CLI_PRO_CLIENTEESCRITORIO = linha["CLI_PRO_CLIENTEESCRITORIO"].ToString();
                    proc.CLI_PRO_TIPOCLIENTEPROC = linha["CLI_PRO_TIPOCLIENTEPROC"].ToString();
                    proc.Cliente = new Cliente();
                    proc.Cliente.id = Convert.ToInt32(linha["CLI_ID"].ToString());
                    proc.Cliente.nome = linha["CLI_NOME"].ToString();
                    proc.Cliente.cpf_cnpj = linha["CLI_CPFCNPJ"].ToString();
                    proc.Cliente.rg_ie = linha["CLI_RGIE"].ToString();
                    proc.Cliente.data_nascimento = Convert.ToDateTime(linha["CLI_DTNASCIMENTO"].ToString());
                    proc.Cliente.nacionalidade = linha["CLI_NACIONALIDADE"].ToString();
                    proc.Cliente.estado_civil = linha["CLI_ESTADOCIVIL"].ToString();
                    proc.Cliente.Domicilio = new Domicilio();
                    proc.Cliente.Domicilio.logradouro = linha["CLI_DOMICILIO"].ToString();
                    proc.Cliente.Domicilio.cep = linha["CLI_CEPDOMICILIO"].ToString();
                    proc.Cliente.endereco = new Endereco();
                    proc.Cliente.endereco.logradouro = linha["CLI_RESIDENCIA"].ToString();
                    proc.Cliente.endereco.cep = linha["CLI_CEPRESIDENCIA"].ToString();
                    proc.Cliente.telefone = linha["CLI_TELEFONE"].ToString();
                    proc.Cliente.celular = linha["CLI_CELULAR"].ToString();
                    proc.Cliente.email = linha["CLI_EMAIL"].ToString();
                    proc.Cliente.excluido = Convert.ToBoolean(linha["CLI_DELETE"].ToString());
                    proc.Cliente.sexo = linha["CLI_SEXO"].ToString();
                    proc.Processo = new Processo();
                    proc.Processo.PROC_ID = Convert.ToInt32(linha["PROC_ID"].ToString());
                    proc.Processo.funcionario_fun_id = Convert.ToInt32(linha["funcionario_fun_id"].ToString());
                    proc.Processo.PROC_AREA = linha["PROC_AREA"].ToString();
                    proc.Processo.PROC_ASSUNTO = linha["PROC_ASSUNTO"].ToString();
                    proc.Processo.PROC_CLASSEPROCEDIMENTO = linha["PROC_CLASSEPROCEDIMENTO"].ToString();
                    proc.Processo.PROC_COMARCA = linha["PROC_COMARCA"].ToString();
                    proc.Processo.PROC_COMPETENCIA = linha["PROC_COMPETENCIA"].ToString();
                    proc.Processo.PROC_DTCADASTRO = linha["PROC_DTCADASTRO"].ToString();
                    proc.Processo.PROC_FORUM = linha["PROC_FORUM"].ToString();
                    proc.Processo.PROC_INSTANCIA = linha["PROC_INSTANCIA"].ToString();
                    proc.Processo.PROC_NATUREZA = linha["PROC_NATUREZA"].ToString();
                    proc.Processo.PROC_NUMEROPROCESSO = linha["PROC_NUMEROPROCESSO"].ToString();
                    proc.Processo.PROC_PALAVRACHAVE = linha["PROC_PALAVRACHAVE"].ToString();
                    proc.Processo.PROC_VALORDACAUSA = linha["PROC_VALORDACAUSA"].ToString();
                    proc.Processo.PROC_VARA = linha["PROC_VARA"].ToString();
                    proc.Processo.Funcionario = new Funcionario();
                    proc.Processo.Funcionario.id = Convert.ToInt32(linha["fun_id"].ToString());
                    proc.Processo.Funcionario.nome = linha["FUN_NOME"].ToString();
                    listaProcesso.Add(proc);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaProcesso;
        }
        public ProcessoPessoaVinc buscaProcessoPro(string id)
        {
            ProcessoPessoaVinc proc = new ProcessoPessoaVinc();
            DataTable dtProcesso;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 2);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_processo_PROC_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_PRO_TIPOCLIENTEPROC", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_PRO_CLIENTEESCRITORIO", null);
                acessaBancoDados.AdicionaParametros("VAR_BUSCACODIGO", id);
                acessaBancoDados.AdicionaParametros("VAR_BUSCATEXTO", null);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtProcesso = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspProcessoClienteVinc");

                foreach (DataRow linha in dtProcesso.Rows)
                {                    

                    proc.cliente_CLI_ID = Convert.ToInt32(linha["cliente_CLI_ID"].ToString());
                    proc.processo_PROC_ID = Convert.ToInt32(linha["processo_PROC_ID"].ToString());
                    proc.CLI_PRO_CLIENTEESCRITORIO = linha["CLI_PRO_CLIENTEESCRITORIO"].ToString();
                    proc.CLI_PRO_TIPOCLIENTEPROC = linha["CLI_PRO_TIPOCLIENTEPROC"].ToString();
                    proc.Cliente = new Cliente();
                    proc.Cliente.id = Convert.ToInt32(linha["CLI_ID"].ToString());
                    proc.Cliente.nome = linha["CLI_NOME"].ToString();
                    proc.Cliente.cpf_cnpj = linha["CLI_CPFCNPJ"].ToString();
                    proc.Cliente.rg_ie = linha["CLI_RGIE"].ToString();
                    proc.Cliente.data_nascimento = Convert.ToDateTime(linha["CLI_DTNASCIMENTO"].ToString());
                    proc.Cliente.nacionalidade = linha["CLI_NACIONALIDADE"].ToString();
                    proc.Cliente.estado_civil = linha["CLI_ESTADOCIVIL"].ToString();
                    proc.Cliente.Domicilio = new Domicilio();
                    proc.Cliente.Domicilio.logradouro = linha["CLI_DOMICILIO"].ToString();
                    proc.Cliente.Domicilio.cep = linha["CLI_CEPDOMICILIO"].ToString();
                    proc.Cliente.endereco = new Endereco();
                    proc.Cliente.endereco.logradouro = linha["CLI_RESIDENCIA"].ToString();
                    proc.Cliente.endereco.cep = linha["CLI_CEPRESIDENCIA"].ToString();
                    proc.Cliente.telefone = linha["CLI_TELEFONE"].ToString();
                    proc.Cliente.celular = linha["CLI_CELULAR"].ToString();
                    proc.Cliente.email = linha["CLI_EMAIL"].ToString();
                    proc.Cliente.excluido = Convert.ToBoolean(linha["CLI_DELETE"].ToString());
                    proc.Cliente.sexo = linha["CLI_SEXO"].ToString();
                    proc.Processo = new Processo();
                    proc.Processo.PROC_ID = Convert.ToInt32(linha["PROC_ID"].ToString());
                    proc.Processo.funcionario_fun_id = Convert.ToInt32(linha["funcionario_fun_id"].ToString());
                    proc.Processo.PROC_AREA = linha["PROC_AREA"].ToString();
                    proc.Processo.PROC_ASSUNTO = linha["PROC_ASSUNTO"].ToString();
                    proc.Processo.PROC_CLASSEPROCEDIMENTO = linha["PROC_CLASSEPROCEDIMENTO"].ToString();
                    proc.Processo.PROC_COMARCA = linha["PROC_COMARCA"].ToString();
                    proc.Processo.PROC_COMPETENCIA = linha["PROC_COMPETENCIA"].ToString();
                    proc.Processo.PROC_DTCADASTRO = linha["PROC_DTCADASTRO"].ToString();
                    proc.Processo.PROC_FORUM = linha["PROC_FORUM"].ToString();
                    proc.Processo.PROC_INSTANCIA = linha["PROC_INSTANCIA"].ToString();
                    proc.Processo.PROC_NATUREZA = linha["PROC_NATUREZA"].ToString();
                    proc.Processo.PROC_NUMEROPROCESSO = linha["PROC_NUMEROPROCESSO"].ToString();
                    proc.Processo.PROC_PALAVRACHAVE = linha["PROC_PALAVRACHAVE"].ToString();
                    proc.Processo.PROC_VALORDACAUSA = linha["PROC_VALORDACAUSA"].ToString();
                    proc.Processo.PROC_VARA = linha["PROC_VARA"].ToString();
                    proc.Processo.Funcionario = new Funcionario();
                    proc.Processo.Funcionario.id = Convert.ToInt32(linha["fun_id"].ToString());
                    proc.Processo.Funcionario.nome = linha["FUN_NOME"].ToString();
                    
                }
            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return proc;
        }
        public List<ProcessoPessoaVinc> buscaAutorReu(string id = "", string autorORreu = "")
        {
            List<ProcessoPessoaVinc> listaProcesso = new List<ProcessoPessoaVinc>();
            DataTable dtProcesso;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 3);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_processo_PROC_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_PRO_TIPOCLIENTEPROC", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_PRO_CLIENTEESCRITORIO", null);
                acessaBancoDados.AdicionaParametros("VAR_BUSCACODIGO", id);
                acessaBancoDados.AdicionaParametros("VAR_BUSCATEXTO", autorORreu);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtProcesso = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspProcessoClienteVinc");

                foreach (DataRow linha in dtProcesso.Rows)
                {
                    ProcessoPessoaVinc proc = new ProcessoPessoaVinc();

                    proc.cliente_CLI_ID = Convert.ToInt32(linha["cliente_CLI_ID"].ToString());
                    proc.processo_PROC_ID = Convert.ToInt32(linha["processo_PROC_ID"].ToString());
                    if(linha["CLI_PRO_CLIENTEESCRITORIO"].ToString() == "C") { proc.CLI_PRO_CLIENTEESCRITORIO = linha["CLI_PRO_CLIENTEESCRITORIO"].ToString(); }
                    else { proc.CLI_PRO_CLIENTEESCRITORIO = null; }
                    
                    proc.CLI_PRO_TIPOCLIENTEPROC = linha["CLI_PRO_TIPOCLIENTEPROC"].ToString();
                    proc.Cliente = new Cliente();
                    proc.Cliente.id = Convert.ToInt32(linha["CLI_ID"].ToString());
                    proc.Cliente.nome = linha["CLI_NOME"].ToString();
                    proc.Cliente.cpf_cnpj = linha["CLI_CPFCNPJ"].ToString();
                    proc.Cliente.rg_ie = linha["CLI_RGIE"].ToString();
                    proc.Cliente.data_nascimento = Convert.ToDateTime(linha["CLI_DTNASCIMENTO"].ToString());
                    proc.Cliente.nacionalidade = linha["CLI_NACIONALIDADE"].ToString();
                    proc.Cliente.estado_civil = linha["CLI_ESTADOCIVIL"].ToString();
                    proc.Cliente.Domicilio = new Domicilio();
                    proc.Cliente.Domicilio.logradouro = linha["CLI_DOMICILIO"].ToString();
                    proc.Cliente.Domicilio.cep = linha["CLI_CEPDOMICILIO"].ToString();
                    proc.Cliente.endereco = new Endereco();
                    proc.Cliente.endereco.logradouro = linha["CLI_RESIDENCIA"].ToString();
                    proc.Cliente.endereco.cep = linha["CLI_CEPRESIDENCIA"].ToString();
                    proc.Cliente.telefone = linha["CLI_TELEFONE"].ToString();
                    proc.Cliente.celular = linha["CLI_CELULAR"].ToString();
                    proc.Cliente.email = linha["CLI_EMAIL"].ToString();
                    proc.Cliente.excluido = Convert.ToBoolean(linha["CLI_DELETE"].ToString());
                    proc.Cliente.sexo = linha["CLI_SEXO"].ToString();
                    proc.Processo = new Processo();
                    proc.Processo.PROC_ID = Convert.ToInt32(linha["PROC_ID"].ToString());
                    proc.Processo.funcionario_fun_id = Convert.ToInt32(linha["funcionario_fun_id"].ToString());
                    proc.Processo.PROC_AREA = linha["PROC_AREA"].ToString();
                    proc.Processo.PROC_ASSUNTO = linha["PROC_ASSUNTO"].ToString();
                    proc.Processo.PROC_CLASSEPROCEDIMENTO = linha["PROC_CLASSEPROCEDIMENTO"].ToString();
                    proc.Processo.PROC_COMARCA = linha["PROC_COMARCA"].ToString();
                    proc.Processo.PROC_COMPETENCIA = linha["PROC_COMPETENCIA"].ToString();
                    proc.Processo.PROC_DTCADASTRO = linha["PROC_DTCADASTRO"].ToString();
                    proc.Processo.PROC_FORUM = linha["PROC_FORUM"].ToString();
                    proc.Processo.PROC_INSTANCIA = linha["PROC_INSTANCIA"].ToString();
                    proc.Processo.PROC_NATUREZA = linha["PROC_NATUREZA"].ToString();
                    proc.Processo.PROC_NUMEROPROCESSO = linha["PROC_NUMEROPROCESSO"].ToString();
                    proc.Processo.PROC_PALAVRACHAVE = linha["PROC_PALAVRACHAVE"].ToString();
                    proc.Processo.PROC_VALORDACAUSA = linha["PROC_VALORDACAUSA"].ToString();
                    proc.Processo.PROC_VARA = linha["PROC_VARA"].ToString();
                    proc.Processo.Funcionario = new Funcionario();
                    proc.Processo.Funcionario.id = Convert.ToInt32(linha["fun_id"].ToString());
                    proc.Processo.Funcionario.nome = linha["FUN_NOME"].ToString();
                    listaProcesso.Add(proc);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaProcesso;
        }
        public bool ValidaAutorReuDB(int idAutorRey, int idPasta)
        {
            bool retorno = false;
            DataTable dtProcesso;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 4);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", idAutorRey);
                acessaBancoDados.AdicionaParametros("VAR_processo_PROC_ID", idPasta);
                acessaBancoDados.AdicionaParametros("VAR_CLI_PRO_TIPOCLIENTEPROC", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_PRO_CLIENTEESCRITORIO", null);
                acessaBancoDados.AdicionaParametros("VAR_BUSCACODIGO", null);
                acessaBancoDados.AdicionaParametros("VAR_BUSCATEXTO", null);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtProcesso = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspProcessoClienteVinc");

                foreach (DataRow linha in dtProcesso.Rows)
                { retorno = true;  }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return retorno;
        }






        //Daqui para baixo não usado
        public List<ProcessoPessoaVinc> buscaProcesso()
        {
            List<ProcessoPessoaVinc> listaProcesso = new List<ProcessoPessoaVinc>();
            DataTable dtProcesso;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 0);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_processo_PROC_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_PRO_TIPOCLIENTEPROC", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_PRO_CLIENTEESCRITORIO", null);
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
                    //listaProcesso.Add(proc);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaProcesso;
        }        
        public List<ProcessoPessoaVinc> buscaProcesso(string id)
        {
            List<ProcessoPessoaVinc> listaProcesso = new List<ProcessoPessoaVinc>();
            DataTable dtProcesso;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 0);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_processo_PROC_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_PRO_TIPOCLIENTEPROC", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_PRO_CLIENTEESCRITORIO", null);                
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
                    //listaProcesso.Add(proc);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaProcesso;
        }
        
        public object atualizaProcesso(ProcessoPessoaVinc processopessoavinc)
        {
            object id;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 4);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", processopessoavinc.cliente_CLI_ID);
                acessaBancoDados.AdicionaParametros("VAR_processo_PROC_ID", processopessoavinc.processo_PROC_ID);
                acessaBancoDados.AdicionaParametros("VAR_CLI_PRO_TIPOCLIENTEPROC", processopessoavinc.CLI_PRO_TIPOCLIENTEPROC);
                acessaBancoDados.AdicionaParametros("VAR_CLI_PRO_CLIENTEESCRITORIO", processopessoavinc.CLI_PRO_CLIENTEESCRITORIO);
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
        public bool equals(ProcessoPessoaVinc processopessoavinc)
        {
            throw new NotImplementedException();
        }
    }
}
