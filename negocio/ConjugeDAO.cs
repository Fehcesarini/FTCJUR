using AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ConjugeDAO : IConjuge
    {

        AcessaBancoDados acessaBancoDados = new AcessaBancoDados(Definicoes.banco, Definicoes.server, Definicoes.usuario, Definicoes.senha);

        public object cadastroConjuge(Conjuge conjuge)
        {
            object id;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("acao", 0);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_CON_ID", conjuge.id.ToString());
                acessaBancoDados.AdicionaParametros("VAR_CON_NOME", conjuge.nome.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_CPFCNPJ", conjuge.cpf_cnpj.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_RGIE", conjuge.rg_ie.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_DTNASCIMENTO", conjuge.data_nascimento.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_NACIONALIDADE", conjuge.nacionalidade.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_ESTADOCIVIL", conjuge.estado_civil.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_DOMICILIO", conjuge.Domicilio.logradouro.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_CEPDOMICILIO", conjuge.Domicilio.cep.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_RESIDENCIA", conjuge.endereco.logradouro.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_CEPRESIDENCIA", conjuge.endereco.cep.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_TELEFONE", conjuge.telefone.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_CELULAR", conjuge.celular.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_EMAIL", conjuge.email.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_SEXO", conjuge.sexo.ToString().ToUpper());                
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia.ToString());
                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspConjuge");
            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;
        }

        public List<Conjuge> buscaConjuge()
        {
            List<Conjuge> listaConjuge = new List<Conjuge>();
            DataTable DtConjuge;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("acao", 1);
                acessaBancoDados.AdicionaParametros("VAR_CLI_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_NOME", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_CPFCNPJ", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_RGIE", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_DTNASCIMENTO", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_NACIONALIDADE", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_ESTADOCIVIL", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_DOMICILIO", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_CEPDOMICILIO", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_RESIDENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_CEPRESIDENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_TELEFONE", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_CELULAR", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_EMAIL", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_SEXO", null);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia.ToString());
                DtConjuge = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspConjuge");

                foreach (DataRow linha in DtConjuge.Rows)
                {
                    Conjuge conjuge = new Conjuge();

                    conjuge.id = Convert.ToInt32(linha["CON_ID"].ToString());
                    conjuge.nome = linha["CON_NOME"].ToString();
                    conjuge.cpf_cnpj = linha["CON_CPFCNPJ"].ToString();
                    conjuge.rg_ie = linha["CON_RGIE"].ToString();
                    conjuge.data_nascimento = Convert.ToDateTime(linha["CON_DTNASCIMENTO"].ToString());
                    conjuge.nacionalidade = linha["CON_NACIONALIDADE"].ToString();
                    conjuge.estado_civil = linha["CON_ESTADOCIVIL"].ToString();
                    conjuge.telefone = linha["CON_TELEFONE"].ToString();
                    conjuge.celular = linha["CON_CELULAR"].ToString();
                    conjuge.email = linha["CON_EMAIL"].ToString();
                    conjuge.sexo = linha["CON_SEXO"].ToString();
                    


                    conjuge.endereco = new Endereco();
                    conjuge.endereco.logradouro = linha["CON_RESIDENCIA"].ToString();
                    conjuge.endereco.cep = linha["CON_CEPRESIDENCIA"].ToString();

                    conjuge.Domicilio = new Domicilio();
                    conjuge.Domicilio.logradouro = linha["CON_DOMICILIO"].ToString();
                    conjuge.Domicilio.cep = linha["CON_CEPDOMICILIO"].ToString();

                    listaConjuge.Add(conjuge);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaConjuge;
        }


        public object atualizaConjuge(Conjuge conjuge)
        {
            object id;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("acao", 2);
                acessaBancoDados.AdicionaParametros("VAR_cliente_CLI_ID", Negocio.Definicoes.idClienteSelecionado);
                acessaBancoDados.AdicionaParametros("VAR_CON_ID", conjuge.id.ToString());
                acessaBancoDados.AdicionaParametros("VAR_CON_NOME", conjuge.nome.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_CPFCNPJ", conjuge.cpf_cnpj.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_RGIE", conjuge.rg_ie.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_DTNASCIMENTO", conjuge.data_nascimento.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_NACIONALIDADE", conjuge.nacionalidade.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_ESTADOCIVIL", conjuge.estado_civil.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_DOMICILIO", conjuge.Domicilio.logradouro.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_CEPDOMICILIO", conjuge.Domicilio.cep.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_RESIDENCIA", conjuge.endereco.logradouro.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_CEPRESIDENCIA", conjuge.endereco.cep.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_TELEFONE", conjuge.telefone.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_CELULAR", conjuge.celular.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_EMAIL", conjuge.email.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CON_SEXO", conjuge.sexo.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia.ToString());
                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspConjuge");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;
        }



        public List<Conjuge> buscaConjuge(string id)
        {
            List<Conjuge> listaConjuge = new List<Conjuge>();
            DataTable dtConjuge;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("acao", 1);
                acessaBancoDados.AdicionaParametros("VAR_CLI_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_ID", id);
                acessaBancoDados.AdicionaParametros("VAR_CON_NOME", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_CPFCNPJ", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_RGIE", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_DTNASCIMENTO", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_NACIONALIDADE", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_ESTADOCIVIL", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_DOMICILIO", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_CEPDOMICILIO", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_RESIDENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_CEPRESIDENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_TELEFONE", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_CELULAR", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_EMAIL", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_SEXO", null);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia.ToString());
                dtConjuge = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspConjuge");

                foreach (DataRow linha in dtConjuge.Rows)
                {
                    Conjuge conjuge = new Conjuge();

                    conjuge.id = Convert.ToInt32(linha["CON_ID"].ToString());
                    conjuge.nome = linha["CON_NOME"].ToString();
                    conjuge.cpf_cnpj = linha["CON_CPFCNPJ"].ToString();
                    conjuge.rg_ie = linha["CON_RGIE"].ToString();
                    conjuge.data_nascimento = Convert.ToDateTime(linha["CON_DTNASCIMENTO"].ToString());
                    conjuge.nacionalidade = linha["CON_NACIONALIDADE"].ToString();
                    conjuge.estado_civil = linha["CON_ESTADOCIVIL"].ToString();
                    conjuge.telefone = linha["CON_TELEFONE"].ToString();
                    conjuge.celular = linha["CON_CELULAR"].ToString();
                    conjuge.email = linha["CON_EMAIL"].ToString();
                    conjuge.sexo = linha["CON_SEXO"].ToString();



                    conjuge.endereco = new Endereco();
                    conjuge.endereco.logradouro = linha["CON_RESIDENCIA"].ToString();
                    conjuge.endereco.cep = linha["CON_CEPRESIDENCIA"].ToString();

                    conjuge.Domicilio = new Domicilio();
                    conjuge.Domicilio.logradouro = linha["CON_DOMICILIO"].ToString();
                    conjuge.Domicilio.cep = linha["CON_CEPDOMICILIO"].ToString();

                    listaConjuge.Add(conjuge);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaConjuge;
        }

        List<Conjuge> IConjuge.buscaConjuge(string id, string nome)
        {
            List<Conjuge> listaConjuge = new List<Conjuge>();
            DataTable dtConjuge;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("acao", 1);
                acessaBancoDados.AdicionaParametros("VAR_CLI_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_ID", id);
                acessaBancoDados.AdicionaParametros("VAR_CON_NOME", nome);
                acessaBancoDados.AdicionaParametros("VAR_CON_CPFCNPJ", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_RGIE", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_DTNASCIMENTO", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_NACIONALIDADE", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_ESTADOCIVIL", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_DOMICILIO", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_CEPDOMICILIO", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_RESIDENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_CEPRESIDENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_TELEFONE", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_CELULAR", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_EMAIL", null);
                acessaBancoDados.AdicionaParametros("VAR_CON_SEXO", null);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia.ToString());
                dtConjuge = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspConjuge");

                foreach (DataRow linha in dtConjuge.Rows)
                {
                    Conjuge conjuge = new Conjuge();

                    conjuge.id = Convert.ToInt32(linha["CON_ID"].ToString());
                    conjuge.nome = linha["CON_NOME"].ToString();
                    conjuge.cpf_cnpj = linha["CON_CPFCNPJ"].ToString();
                    conjuge.rg_ie = linha["CON_RGIE"].ToString();
                    conjuge.data_nascimento = Convert.ToDateTime(linha["CON_DTNASCIMENTO"].ToString());
                    conjuge.nacionalidade = linha["CON_NACIONALIDADE"].ToString();
                    conjuge.estado_civil = linha["CON_ESTADOCIVIL"].ToString();
                    conjuge.telefone = linha["CON_TELEFONE"].ToString();
                    conjuge.celular = linha["CON_CELULAR"].ToString();
                    conjuge.email = linha["CON_EMAIL"].ToString();
                    conjuge.sexo = linha["CON_SEXO"].ToString();



                    conjuge.endereco = new Endereco();
                    conjuge.endereco.logradouro = linha["CON_RESIDENCIA"].ToString();
                    conjuge.endereco.cep = linha["CON_CEPRESIDENCIA"].ToString();

                    conjuge.Domicilio = new Domicilio();
                    conjuge.Domicilio.logradouro = linha["CON_DOMICILIO"].ToString();
                    conjuge.Domicilio.cep = linha["CON_CEPDOMICILIO"].ToString();

                    listaConjuge.Add(conjuge);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaConjuge;
        }



        

        public bool equals(Conjuge conjuge)
        {
            throw new NotImplementedException();
        }

       
       
    }
}
