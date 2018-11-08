using AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class ClienteDAO : ICliente
    {
        
        AcessaBancoDados acessaBancoDados = new AcessaBancoDados(Definicoes.banco, Definicoes.server, Definicoes.usuario, Definicoes.senha);

        public object cadastroCliente(Cliente cliente)
        {
            object id;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("acao", 0);
                acessaBancoDados.AdicionaParametros("VAR_CLI_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_NOME", cliente.nome.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_CPFCNPJ", cliente.cpf_cnpj.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_RGIE", cliente.rg_ie.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_DTNASCIMENTO", cliente.data_nascimento.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_NACIONALIDADE", cliente.nacionalidade.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_ESTADOCIVIL", cliente.estado_civil.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_DOMICILIO", cliente.Domicilio.logradouro.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_CEPDOMICILIO", cliente.Domicilio.cep.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_RESIDENCIA", cliente.endereco.logradouro.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_CEPRESIDENCIA", cliente.endereco.cep.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_TELEFONE", cliente.telefone.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_CELULAR", cliente.celular.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_SEXO", cliente.sexo.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_EMAIL", cliente.email.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_DELETE", false.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia.ToString());
                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspCliente");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;
        }

        public List<Cliente> buscaCliente()
        {
            
            List<Cliente> listaCliente = new List<Cliente>();
            DataTable dtCliente;
           
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 1);
                acessaBancoDados.AdicionaParametros("VAR_CLI_ID", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_NOME", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CPFCNPJ", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_RGIE", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_DTNASCIMENTO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_NACIONALIDADE", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_ESTADOCIVIL", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_DOMICILIO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CEPDOMICILIO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_RESIDENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CEPRESIDENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_TELEFONE", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CELULAR", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_SEXO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_EMAIL", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_DELETE", false);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia.ToString());
                dtCliente = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspCliente");

                
                foreach (DataRow linha in dtCliente.Rows)
                {
                    
                      Cliente cliente = new Cliente();
                    
                    cliente.id = Convert.ToInt32(linha["CLI_ID"].ToString());
                    cliente.nome = linha["CLI_NOME"].ToString();
                    cliente.cpf_cnpj = linha["CLI_CPFCNPJ"].ToString();                    
                    cliente.rg_ie = linha["CLI_RGIE"].ToString();
                    cliente.data_nascimento = Convert.ToDateTime(linha["CLI_DTNASCIMENTO"].ToString());
                    cliente.nacionalidade = linha["CLI_NACIONALIDADE"].ToString();
                    cliente.estado_civil = linha["CLI_ESTADOCIVIL"].ToString();
                    cliente.telefone = linha["CLI_TELEFONE"].ToString();
                    cliente.celular = linha["CLI_CELULAR"].ToString();
                    cliente.email = linha["CLI_EMAIL"].ToString();
                    cliente.sexo = linha["CLI_SEXO"].ToString();
                    cliente.excluido = Convert.ToBoolean(linha["CLI_DELETE"].ToString());


                    cliente.endereco = new Endereco();
                    cliente.endereco.logradouro = linha["CLI_RESIDENCIA"].ToString();
                    cliente.endereco.cep = linha["CLI_CEPRESIDENCIA"].ToString();

                    cliente.Domicilio = new Domicilio();
                    cliente.Domicilio.logradouro = linha["CLI_DOMICILIO"].ToString();
                    cliente.Domicilio.cep = linha["CLI_CEPDOMICILIO"].ToString();

                    listaCliente.Add(cliente);
                }

          

            return listaCliente;
        }


        public Cliente buscaClienteCli(string id)
        {
            Cliente cliente = new Cliente();
            DataTable dtCliente;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 6);
                acessaBancoDados.AdicionaParametros("@VAR_CLI_ID", Convert.ToInt32(id));
                acessaBancoDados.AdicionaParametros("VAR_CLI_NOME", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CPFCNPJ", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_RGIE", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_DTNASCIMENTO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_NACIONALIDADE", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_ESTADOCIVIL", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_DOMICILIO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CEPDOMICILIO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_RESIDENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CEPRESIDENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_TELEFONE", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CELULAR", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_SEXO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_EMAIL", null);
                acessaBancoDados.AdicionaParametros("@VAR_CLI_DELETE", false);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia.ToString());
                dtCliente = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspCliente");

                foreach (DataRow linha in dtCliente.Rows)
                {
                   

                    cliente.id = Convert.ToInt32(linha["CLI_ID"].ToString());
                    cliente.nome = linha["CLI_NOME"].ToString();
                    cliente.cpf_cnpj = linha["CLI_CPFCNPJ"].ToString();
                    cliente.rg_ie = linha["CLI_RGIE"].ToString();
                    cliente.data_nascimento = Convert.ToDateTime(linha["CLI_DTNASCIMENTO"].ToString());
                    cliente.nacionalidade = linha["CLI_NACIONALIDADE"].ToString();
                    cliente.estado_civil = linha["CLI_ESTADOCIVIL"].ToString();
                    cliente.telefone = linha["CLI_TELEFONE"].ToString();
                    cliente.celular = linha["CLI_CELULAR"].ToString();
                    cliente.email = linha["CLI_EMAIL"].ToString();
                    cliente.sexo = linha["CLI_SEXO"].ToString();
                    cliente.excluido = Convert.ToBoolean(linha["CLI_DELETE"].ToString());


                    cliente.endereco = new Endereco();
                    cliente.endereco.logradouro = linha["CLI_RESIDENCIA"].ToString();
                    cliente.endereco.cep = linha["CLI_CEPRESIDENCIA"].ToString();

                    cliente.Domicilio = new Domicilio();
                    cliente.Domicilio.logradouro = linha["CLI_DOMICILIO"].ToString();
                    cliente.Domicilio.cep = linha["CLI_CEPDOMICILIO"].ToString();

                    
                    Definicoes.idConjuge = linha["CON_ID"].ToString();
                    if (Definicoes.idConjuge != "")
                    {
                        cliente.Conjuge = new Conjuge();
                        cliente.Conjuge.id = Convert.ToInt32(linha["CON_ID"].ToString());
                        cliente.Conjuge.nome = linha["CON_NOME"].ToString();
                        cliente.Conjuge.cpf_cnpj = linha["CON_CPFCNPJ"].ToString();
                        cliente.Conjuge.rg_ie = linha["CON_RGIE"].ToString();
                        cliente.Conjuge.data_nascimento = Convert.ToDateTime(linha["CON_DTNASCIMENTO"].ToString());
                        cliente.Conjuge.nacionalidade = linha["CON_NACIONALIDADE"].ToString();
                        cliente.Conjuge.estado_civil = linha["CON_ESTADOCIVIL"].ToString();
                        cliente.Conjuge.telefone = linha["CON_TELEFONE"].ToString();
                        cliente.Conjuge.celular = linha["CON_CELULAR"].ToString();
                        cliente.Conjuge.email = linha["CON_EMAIL"].ToString();
                        cliente.Conjuge.sexo = linha["CON_SEXO"].ToString();

                        cliente.Conjuge.Domicilio = new Domicilio();
                        cliente.Conjuge.Domicilio.logradouro = linha["CON_DOMICILIO"].ToString();
                        cliente.Conjuge.Domicilio.cep = linha["CON_CEPDOMICILIO"].ToString();

                        cliente.Conjuge.endereco = new Endereco();
                        cliente.Conjuge.endereco.logradouro = linha["CON_RESIDENCIA"].ToString();
                        cliente.Conjuge.endereco.cep = linha["CON_CEPRESIDENCIA"].ToString();
                    }
                    Definicoes.idBanco = linha["BAN_ID"].ToString();
                    if(Definicoes.idBanco != "")
                    {
                        cliente.DadoBancario = new DadoBancario();
                        cliente.DadoBancario.id = Convert.ToInt32(linha["BAN_ID"].ToString());
                        cliente.DadoBancario.banco = linha["BAN_BANCO"].ToString();
                        cliente.DadoBancario.Agencia = linha["BAN_AGENCIA"].ToString();
                        cliente.DadoBancario.TipoConta = linha["BAN_CONTA"].ToString();
                        cliente.DadoBancario.numero = linha["BAN_NUMERO"].ToString();
                    }
                    Definicoes.idPenal = linha["PEN_ID"].ToString();
                    if(Definicoes.idPenal != "")
                    {
                        cliente.Penal = new Penal();
                        cliente.Penal.id = Convert.ToInt32(linha["PEN_ID"].ToString());
                        cliente.Penal.crime = linha["PEN_CRIME"].ToString();
                        cliente.Penal.acao_penal = linha["PEN_ACAOPENAL"].ToString();
                        cliente.Penal.rito_processual = linha["PEN_RITOPROCESSUAL"].ToString();
                        cliente.Penal.suspensao_condicional_processo = linha["PEN_SUSPENCAOCONDICIONAL"].ToString();
                        cliente.Penal.livramento_condicional = linha["PEN_LIVRAMENTOCONDICIONAL"].ToString();
                        cliente.Penal.reincidente = linha["PEN_REINCIDENTE"].ToString();
                        cliente.Penal.regime_prisional = linha["PEN_REGIMEPRISIONAL"].ToString();
                        cliente.Penal.atenuantes = linha["PEN_ATENUANTES"].ToString();
                        cliente.Penal.agravantes = linha["PEN_AGRAVANTES"].ToString();
                        cliente.Penal.majorantes = linha["PEN_MAJORANTES"].ToString();
                        cliente.Penal.minorantes = linha["PEN_MINORANTES"].ToString();
                        cliente.Penal.qualificadoras = linha["PEN_QUALIFICADORAS"].ToString();             
                    }
                    Definicoes.idPrevidenciario = linha["PREV_ID"].ToString();
                    if (Definicoes.idPrevidenciario != "")
                    {
                        cliente.Previdenciario = new Previdenciario();
                        cliente.Previdenciario.id = Convert.ToInt32(linha["PREV_ID"].ToString());
                        cliente.Previdenciario.CNIS = linha["PREV_CNIS"].ToString();
                        cliente.Previdenciario.carteiraTrabalho = linha["PREV_CTPS"].ToString();
                        cliente.Previdenciario.benificio = linha["PREV_BENEFICIOS"].ToString();
                        cliente.Previdenciario.aposentadoria = linha["PREV_APOSENTADORIA"].ToString();
                        cliente.Previdenciario.procedimentoADM = linha["PREV_PROCEDIMENTOADM"].ToString();
                        cliente.Previdenciario.obs = linha["PREV_OBS"].ToString();
                    }
                    Definicoes.idTrabalhista = linha["TRAB_ID"].ToString();
                    if(Definicoes.idTrabalhista != "")
                    {
                        cliente.Trabalhista = new Trabalhista();
                        cliente.Trabalhista.id = Convert.ToInt32(linha["TRAB_ID"].ToString());
                        cliente.Trabalhista.CTPS = linha["TRAB_REGISTROCTPS"].ToString();
                        cliente.Trabalhista.FGTS = linha["TRAB_FGTS"].ToString();
                        cliente.Trabalhista.seguroDesemprego = linha["TRAB_SEGURODESEMPREGO"].ToString();
                        cliente.Trabalhista.avisoPrevio = linha["TRAB_AVISOPREVIO"].ToString();
                        cliente.Trabalhista.licencaMaternidade = linha["TRAB_LINCENCAS"].ToString();
                        cliente.Trabalhista.advertencia = linha["TRAB_ADVERTENCIAS"].ToString();
                        cliente.Trabalhista.obs = linha["TRAB_OBS"].ToString();
                    }



                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return cliente;
        }


        public object atualizaCliente(Cliente cliente)
        {
            object id;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("acao", 4);
                acessaBancoDados.AdicionaParametros("VAR_CLI_ID", cliente.id);
                acessaBancoDados.AdicionaParametros("VAR_CLI_NOME", cliente.nome.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_CPFCNPJ", cliente.cpf_cnpj.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_RGIE", cliente.rg_ie.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_DTNASCIMENTO", cliente.data_nascimento.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_NACIONALIDADE", cliente.nacionalidade.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_ESTADOCIVIL", cliente.estado_civil.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_DOMICILIO", cliente.Domicilio.logradouro.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_CEPDOMICILIO", cliente.Domicilio.cep.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_RESIDENCIA", cliente.endereco.logradouro.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_CEPRESIDENCIA", cliente.endereco.logradouro.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_TELEFONE", cliente.telefone.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_CELULAR", cliente.celular.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_SEXO", cliente.sexo.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_EMAIL", cliente.email.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_CLI_DELETE", false.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia.ToString());
                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspCliente");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;
        }

        

        public List<Cliente> buscaCliente(string id)
        {
            List<Cliente> listaCliente = new List<Cliente>();
            DataTable dtCliente;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 2);
                acessaBancoDados.AdicionaParametros("@VAR_CLI_ID", Convert.ToInt32(id));            
                acessaBancoDados.AdicionaParametros("VAR_CLI_NOME", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CPFCNPJ", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_RGIE", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_DTNASCIMENTO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_NACIONALIDADE", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_ESTADOCIVIL", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_DOMICILIO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CEPDOMICILIO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_RESIDENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CEPRESIDENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_TELEFONE", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CELULAR", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_SEXO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_EMAIL", null);
                acessaBancoDados.AdicionaParametros("@VAR_CLI_DELETE", false);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia.ToString());
                dtCliente = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspCliente");

                foreach (DataRow linha in dtCliente.Rows)
                {
                    Cliente cliente = new Cliente();

                    cliente.id = Convert.ToInt32(linha["CLI_ID"].ToString());
                    cliente.nome = linha["CLI_NOME"].ToString();
                    cliente.cpf_cnpj = linha["CLI_CPFCNPJ"].ToString();
                    cliente.rg_ie = linha["CLI_RGIE"].ToString();
                    cliente.data_nascimento = Convert.ToDateTime(linha["CLI_DTNASCIMENTO"].ToString());
                    cliente.nacionalidade = linha["CLI_NACIONALIDADE"].ToString();
                    cliente.estado_civil = linha["CLI_ESTADOCIVIL"].ToString();
                    cliente.telefone = linha["CLI_TELEFONE"].ToString();
                    cliente.celular = linha["CLI_CELULAR"].ToString();
                    cliente.email = linha["CLI_EMAIL"].ToString();
                    cliente.sexo = linha["CLI_SEXO"].ToString();
                    cliente.excluido = Convert.ToBoolean(linha["CLI_DELETE"].ToString());


                    cliente.endereco = new Endereco();
                    cliente.endereco.logradouro = linha["CLI_RESIDENCIA"].ToString();
                    cliente.endereco.cep = linha["CLI_CEPRESIDENCIA"].ToString();

                    cliente.Domicilio = new Domicilio();
                    cliente.Domicilio.logradouro = linha["CLI_DOMICILIO"].ToString();
                    cliente.Domicilio.cep = linha["CLI_CEPDOMICILIO"].ToString();

                    listaCliente.Add(cliente);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaCliente;
        }

        public List<Cliente> buscaCliente(string id = "", string descricao = "")
        {
            List<Cliente> listaCliente = new List<Cliente>();
            DataTable dtCliente;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 3);                
                acessaBancoDados.AdicionaParametros("VAR_CLI_ID", id);
                acessaBancoDados.AdicionaParametros("VAR_CLI_NOME", descricao);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CPFCNPJ", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_RGIE", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_DTNASCIMENTO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_NACIONALIDADE", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_ESTADOCIVIL", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_DOMICILIO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CEPDOMICILIO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_RESIDENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CEPRESIDENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_TELEFONE", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CELULAR", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_SEXO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_EMAIL", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_DELETE", false);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia.ToString());
                dtCliente = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspCliente");

                foreach (DataRow linha in dtCliente.Rows)
                {
                    Cliente cliente = new Cliente();

                    cliente.id = Convert.ToInt32(linha["CLI_ID"].ToString());
                    cliente.nome = linha["CLI_NOME"].ToString();
                    cliente.cpf_cnpj = linha["CLI_CPFCNPJ"].ToString();
                    cliente.rg_ie = linha["CLI_RGIE"].ToString();
                    cliente.data_nascimento = Convert.ToDateTime(linha["CLI_DTNASCIMENTO"].ToString());
                    cliente.nacionalidade = linha["CLI_NACIONALIDADE"].ToString();
                    cliente.estado_civil = linha["CLI_ESTADOCIVIL"].ToString();
                    cliente.telefone = linha["CLI_TELEFONE"].ToString();
                    cliente.celular = linha["CLI_CELULAR"].ToString();
                    cliente.email = linha["CLI_EMAIL"].ToString();
                    cliente.sexo = linha["CLI_SEXO"].ToString();
                    cliente.excluido = Convert.ToBoolean(linha["CLI_DELETE"].ToString());


                    cliente.endereco = new Endereco();
                    cliente.endereco.logradouro = linha["CLI_RESIDENCIA"].ToString();
                    cliente.endereco.cep = linha["CLI_CEPRESIDENCIA"].ToString();

                    cliente.Domicilio = new Domicilio();
                    cliente.Domicilio.logradouro = linha["CLI_DOMICILIO"].ToString();
                    cliente.Domicilio.cep = linha["CLI_CEPDOMICILIO"].ToString();

                    listaCliente.Add(cliente);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaCliente;
        }

        

        public bool deletaCliente(string id)
        {
            bool lRetorn = false;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 0);
                acessaBancoDados.AdicionaParametros("@VAR_CLI_ID", Convert.ToInt32(id));   
                acessaBancoDados.AdicionaParametros("@VAR_CLI_NOME", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CPFCNPJ", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_RGIE", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_DTNASCIMENTO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_NACIONALIDADE", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_ESTADOCIVIL", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_DOMICILIO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CEPDOMICILIO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_RESIDENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CEPRESIDENCIA", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_TELEFONE", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_CELULAR", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_SEXO", null);
                acessaBancoDados.AdicionaParametros("VAR_CLI_EMAIL", null);
                acessaBancoDados.AdicionaParametros("@VAR_CLI_DELETE", true);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia.ToString());
                acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspCliente");
                lRetorn = true;
            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return lRetorn;
        }

        public bool equals(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
