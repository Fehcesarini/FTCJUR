using AcessoBancoDados;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
   public class ArquivoAnexoDAO : IArquivoAnexo
    {
        AcessaBancoDados acessaBancoDados = new AcessaBancoDados(Definicoes.banco, Definicoes.server, Definicoes.usuario, Definicoes.senha);
        
        public object deletaAnexo(string deleta)
        {
            object id;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 3);
                acessaBancoDados.AdicionaParametros("VAR_ANE_ID", deleta);
                acessaBancoDados.AdicionaParametros("VAR_ANE_ANEXO", null);
                acessaBancoDados.AdicionaParametros("VAR_ANE_CAMINHO", null);
                acessaBancoDados.AdicionaParametros("VAR_ANE_NOME", null);
                acessaBancoDados.AdicionaParametros("VAR_ANE_TIPO", null);
                acessaBancoDados.AdicionaParametros("VAR_ANE_TIPOANEXO", null);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspAnexo");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;
        }
        public object cadastroAnexo(ArquivoAnexo arquivoanexo)
        {

            object id;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 0);
                acessaBancoDados.AdicionaParametros("VAR_ANE_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_ANE_ANEXO", File.ReadAllBytes(arquivoanexo.caminho));
                acessaBancoDados.AdicionaParametros("VAR_ANE_CAMINHO", arquivoanexo.caminho.ToString());
                acessaBancoDados.AdicionaParametros("VAR_ANE_NOME", arquivoanexo.nome.ToString());
                acessaBancoDados.AdicionaParametros("VAR_ANE_TIPO", arquivoanexo.tipoprocesso.ToString());
                acessaBancoDados.AdicionaParametros("VAR_ANE_TIPOANEXO", arquivoanexo.tipoanexo.ToString());
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);

                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspAnexo");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;

        }            
        public List<ArquivoAnexo> buscaAnexo(string id ,string tipoprocesso)
        {
            List<ArquivoAnexo> listaArquivoAnexo = new List<ArquivoAnexo>();
            DataTable dtArquivoAnexo;
            try
            {
               
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 1);
                acessaBancoDados.AdicionaParametros("VAR_ANE_ID", id);
                acessaBancoDados.AdicionaParametros("VAR_ANE_ANEXO", null);
                acessaBancoDados.AdicionaParametros("VAR_ANE_CAMINHO", null);
                acessaBancoDados.AdicionaParametros("VAR_ANE_NOME", null);
                acessaBancoDados.AdicionaParametros("VAR_ANE_TIPO", tipoprocesso);
                acessaBancoDados.AdicionaParametros("VAR_ANE_TIPOANEXO", null);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtArquivoAnexo = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspAnexo");

                foreach (DataRow linha in dtArquivoAnexo.Rows)
                {
                    ArquivoAnexo arquivoanexo = new ArquivoAnexo();
                    arquivoanexo.id = linha["ANE_ID"].ToString();
                    if(id != null) { arquivoanexo.nomereturn = (byte[])linha["ANE_ANEXO"]; }
                    arquivoanexo.nome = linha["ANE_NOME"].ToString();
                    arquivoanexo.caminho = linha["ANE_CAMINHO"].ToString();
                    arquivoanexo.tipoprocesso = linha["ANE_TIPO"].ToString();
                    arquivoanexo.tipoanexo = linha["ANE_TIPOANEXO"].ToString();
                    listaArquivoAnexo.Add(arquivoanexo);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaArquivoAnexo;


        }

        public ArquivoAnexo buscaAnexoRetornoDGV(string id, string tipoprocesso)
        {
            ArquivoAnexo arquivoanexo = new ArquivoAnexo();
            DataTable dtArquivoAnexo;
            try
            {
                
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 1);
                acessaBancoDados.AdicionaParametros("VAR_ANE_ID", id);
                acessaBancoDados.AdicionaParametros("VAR_ANE_ANEXO", null);
                acessaBancoDados.AdicionaParametros("VAR_ANE_CAMINHO", null);
                acessaBancoDados.AdicionaParametros("VAR_ANE_NOME", null);
                acessaBancoDados.AdicionaParametros("VAR_ANE_TIPO", tipoprocesso);
                acessaBancoDados.AdicionaParametros("VAR_ANE_TIPOANEXO", null);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtArquivoAnexo = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspAnexo");

                foreach (DataRow linha in dtArquivoAnexo.Rows)
                {
                    
                    arquivoanexo.id = linha["ANE_ID"].ToString();
                    if (id != null) { arquivoanexo.nomereturn = (byte[])linha["ANE_ANEXO"]; }
                    arquivoanexo.nome = linha["ANE_NOME"].ToString();
                    arquivoanexo.caminho = linha["ANE_CAMINHO"].ToString();
                    arquivoanexo.tipoprocesso = linha["ANE_TIPO"].ToString();
                    arquivoanexo.tipoanexo = linha["ANE_TIPOANEXO"].ToString();
                    
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return arquivoanexo;



        }



        public bool equals(ArquivoAnexo arquivoanexo)
        {
            throw new NotImplementedException();
        }
    }
}
