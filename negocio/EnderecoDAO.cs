using System;
using System.Collections.Generic;
using AcessoBancoDados;
using System.Data;

namespace Negocio
{
    public class EnderecoDAO : IEndereco
    {

        AcessaBancoSqlServer acassoBancoSqlServer = new AcessaBancoSqlServer();

        public List<Cidade> buscaCidade()
        {
            List<Cidade> ListCidade = new List<Cidade>();
            DataTable drCidade;

            try
            {
                acassoBancoSqlServer.LimpaParametros();
                acassoBancoSqlServer.AdicionaParametros("@acao", 2);
                drCidade = acassoBancoSqlServer.ExecultarConsulta(CommandType.StoredProcedure, "uspEndereco");

                foreach (DataRow linha in drCidade.Rows)
                {
                    Cidade cidade = new Cidade();
                    cidade.cidade_id = Convert.ToInt32(linha["CID_ID"].ToString());
                    cidade.cidade = linha["CID_DESCRICAO"].ToString();
                    cidade.estado_id = Convert.ToInt32(linha["EST_ID"].ToString());
                    ListCidade.Add(cidade);
                }
            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return ListCidade;
        }

        public List<Estado> buscaEstado()
        {
            List<Estado> ListEstado = new List<Estado>();
            DataTable drEstado;

            try
            {
                acassoBancoSqlServer.LimpaParametros();
                acassoBancoSqlServer.AdicionaParametros("@acao", 1);
                drEstado = acassoBancoSqlServer.ExecultarConsulta(CommandType.StoredProcedure, "uspEndereco");

                foreach (DataRow linha in drEstado.Rows)
                {
                    Estado estado = new Estado();
                    estado.estado_id = Convert.ToInt32(linha["EST_ID"].ToString());
                    estado.estado_sigla = linha["EST_SIGLA"].ToString();
                    estado.estado_descricao = linha["EST_DESCRICAO"].ToString();
                    estado.pai_id = Convert.ToInt32(linha["PAI_ID"].ToString());
                    ListEstado.Add(estado);
                }
            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return ListEstado;
        }

        public List<Pais> buscaPais()
        {
            List<Pais> ListPais = new List<Pais>();
            DataTable drPais;

            try
            {
                acassoBancoSqlServer.LimpaParametros();
                acassoBancoSqlServer.AdicionaParametros("@acao", 3);
                drPais = acassoBancoSqlServer.ExecultarConsulta(CommandType.StoredProcedure, "uspEndereco");

                foreach (DataRow linha in drPais.Rows)
                {
                    Pais pais = new Pais();
                    pais.pais_id = Convert.ToInt32(linha["PAI_ID"].ToString());
                    pais.pais_sigla = linha["PAI_SIGLA"].ToString();
                    pais.pais_descricao = linha["PAI_DESCRICAO"].ToString();
                    ListPais.Add(pais);
                }
            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return ListPais;
        }

        public DataTable buscaCepWeb( string cep )
        {

            DataTable dt = new DataTable();
            
            try
            {
                dt = buscaCEP(cep);
               
            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return dt;
        }

        private DataTable buscaCEP(string cep)
        {
            //Cria um DataSet  baseado no retorno do XML  
            DataSet ds = new DataSet();

            try
            {
                ds.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + cep.Replace("-", "").Trim() + "&formato=xml");
            }
            catch (Exception erro)
            {
                throw new Exception(GravaLogErr.MensagemErro(erro.Message.ToString(), erro));
            }

            return ds.Tables[0];
        }

    }
}
