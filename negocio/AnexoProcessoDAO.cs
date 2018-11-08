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
  public  class AnexoProcessoDAO : IAnexoProcesso
    {
        AcessaBancoDados acessaBancoDados = new AcessaBancoDados(Definicoes.banco, Definicoes.server, Definicoes.usuario, Definicoes.senha);

        
        public object cadastroAnexoProc(AnexoProcesso anexoprocesso)
        {

            object id;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 0);
                acessaBancoDados.AdicionaParametros("VAR_AneProc_id", null);
                acessaBancoDados.AdicionaParametros("VAR_AneProc_documento", File.ReadAllBytes(anexoprocesso.AneProc_documento));
                acessaBancoDados.AdicionaParametros("VAR_AneProc_descricao", anexoprocesso.AneProc_descricao.ToString());
                acessaBancoDados.AdicionaParametros("VAR_AneProc_Obs", anexoprocesso.AneProc_Obs.ToString());
                acessaBancoDados.AdicionaParametros("VAR_AneProc_data", Convert.ToString(anexoprocesso.AneProc_data));
                acessaBancoDados.AdicionaParametros("VAR_processo_PROC_ID", anexoprocesso.processo_PROC_ID.ToString());
                acessaBancoDados.AdicionaParametros("VAR_AneProc_tipodoc", anexoprocesso.AneProc_tipodoc.ToString());
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);

                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspAnexoProcesso");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;

        }
        public List<AnexoProcesso> buscaAnexoProc(string id, string tipoprocesso)
        {
            List<AnexoProcesso> listaArquivoAnexo = new List<AnexoProcesso>();
            DataTable dtArquivoAnexo;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 1);
                acessaBancoDados.AdicionaParametros("VAR_AneProc_id", null);
                acessaBancoDados.AdicionaParametros("VAR_AneProc_documento", null);
                acessaBancoDados.AdicionaParametros("VAR_AneProc_descricao", null);
                acessaBancoDados.AdicionaParametros("VAR_AneProc_Obs", null);
                acessaBancoDados.AdicionaParametros("VAR_AneProc_tipodoc", null);
                acessaBancoDados.AdicionaParametros("VAR_AneProc_data", null);
                acessaBancoDados.AdicionaParametros("VAR_processo_PROC_ID", id);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtArquivoAnexo = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspAnexoProcesso");

                foreach (DataRow linha in dtArquivoAnexo.Rows)
                {
                    AnexoProcesso arquivoanexo = new AnexoProcesso();
                    arquivoanexo.AneProc_id = Convert.ToInt32(linha["AneProc_id"].ToString());
                    if (id != null) { arquivoanexo.documentoreturn = (byte[])linha["AneProc_documento"]; }
                    arquivoanexo.AneProc_Obs = linha["AneProc_Obs"].ToString();
                    arquivoanexo.AneProc_descricao = linha["AneProc_descricao"].ToString();
                    arquivoanexo.processo_PROC_ID = Convert.ToInt32(linha["processo_PROC_ID"].ToString());
                    arquivoanexo.AneProc_tipodoc = linha["AneProc_tipodoc"].ToString();
                    arquivoanexo.AneProc_data = Convert.ToDateTime(linha["AneProc_data"].ToString());
                    listaArquivoAnexo.Add(arquivoanexo);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaArquivoAnexo;


        }
        public AnexoProcesso buscaAnexoRetornoDGV(string id, string tipoprocesso)
        {
            AnexoProcesso arquivoanexo = new AnexoProcesso();
            DataTable dtArquivoAnexo;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 1);
                acessaBancoDados.AdicionaParametros("VAR_AneProc_id", id);
                acessaBancoDados.AdicionaParametros("VAR_AneProc_documento", null);
                acessaBancoDados.AdicionaParametros("VAR_AneProc_descricao", null);
                acessaBancoDados.AdicionaParametros("VAR_AneProc_Obs", null);
                acessaBancoDados.AdicionaParametros("VAR_AneProc_tipodoc", tipoprocesso);
                acessaBancoDados.AdicionaParametros("VAR_AneProc_data", null);
                acessaBancoDados.AdicionaParametros("VAR_processo_PROC_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtArquivoAnexo = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspAnexoProcesso");

                foreach (DataRow linha in dtArquivoAnexo.Rows)
                {

                    arquivoanexo.AneProc_id = Convert.ToInt32(linha["AneProc_id"].ToString());
                    if (id != null) { arquivoanexo.documentoreturn = (byte[])linha["ANE_ANEXO"]; }
                    arquivoanexo.AneProc_Obs = linha["AneProc_Obs"].ToString();
                    arquivoanexo.AneProc_descricao = linha["AneProc_descricao"].ToString();
                    arquivoanexo.processo_PROC_ID = Convert.ToInt32(linha["processo_PROC_ID"].ToString());
                    arquivoanexo.AneProc_tipodoc = linha["AneProc_tipodoc"].ToString();
                    arquivoanexo.AneProc_data = Convert.ToDateTime(linha["AneProc_data"].ToString());

                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return arquivoanexo;



        }


        public object deletaAnexoProc(string deleta)
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
        public bool equals(AnexoProcesso anexoprocesso)
        {
            throw new NotImplementedException();
        }
    }
}