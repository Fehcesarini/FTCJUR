using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoBancoDados;
using System.Data;

namespace Negocio
{
    public class FuncionarioDAO : IFuncionario
    {
        AcessaBancoDados acessaBancoDados = new AcessaBancoDados(Definicoes.banco, Definicoes.server, Definicoes.usuario, Definicoes.senha);
        //Função Funcionando 20/01
        public object cadastroFuncionario(Funcionario funcionario)
        {
            object id;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 0);

                acessaBancoDados.AdicionaParametros("@VAR_CAR_ID", funcionario.CargoFuncionarios.id);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_ID", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_NOME", funcionario.nome.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_CPFCNPJ", funcionario.cpf_cnpj.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_RGIE", funcionario.rg_ie.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_EMAIL", funcionario.email.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_ENDERECO", funcionario.endereco.logradouro.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_CEP", funcionario.endereco.cep.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_TELEFONE", funcionario.telefone.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_CELULAR", funcionario.celular.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_DTNASCIMENTO", funcionario.data_nascimento.ToString());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_SALARIO", funcionario.salario.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_DTADIMISSAO", funcionario.data_admissao.ToLongDateString());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_COMISSAO", funcionario.comissao.ToString());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_SEXO", funcionario.sexo.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_LOGIN", funcionario.Login.usuario.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_SENHA", funcionario.Login.senha.ToUpper());
                
                acessaBancoDados.AdicionaParametros("@VAR_FUN_DELETE", false.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                
                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspFuncionario");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;
        }

        //Função Funcioando 25/01
        public object atualizaFuncionario(Funcionario funcionario)
        {
            object id;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 4);

                acessaBancoDados.AdicionaParametros("@VAR_CAR_ID", funcionario.CargoFuncionarios.id);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_ID", funcionario.id);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_NOME", funcionario.nome.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_CPFCNPJ", funcionario.cpf_cnpj.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_RGIE", funcionario.rg_ie.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_EMAIL", funcionario.email.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_ENDERECO", funcionario.endereco.logradouro.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_CEP", funcionario.endereco.cep.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_TELEFONE", funcionario.telefone.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_CELULAR", funcionario.celular.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_SALARIO", funcionario.salario.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_DTADIMISSAO", funcionario.data_admissao.ToLongDateString());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_DTNASCIMENTO", funcionario.data_nascimento.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_COMISSAO", funcionario.comissao.ToString());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_SEXO", funcionario.sexo.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_LOGIN", funcionario.Login.usuario.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_SENHA", funcionario.Login.senha.ToUpper());

                acessaBancoDados.AdicionaParametros("@VAR_FUN_DELETE", false.ToString().ToUpper());

                acessaBancoDados.AdicionaParametros("@VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);

                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspFuncionario");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return id;
        }

        //Função Funcionando 20/01
        public List<Funcionario> buscaFuncionario()
        {
            List<Funcionario> listaFuncionario = new List<Funcionario>();
            DataTable dtCargoFuncionario;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 1);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ID", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_ID", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_NOME", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_CPFCNPJ", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_RGIE", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_EMAIL", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_ENDERECO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_CEP", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_TELEFONE", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_CELULAR", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_SALARIO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_DTADIMISSAO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_DTNASCIMENTO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_COMISSAO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_SEXO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_LOGIN", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_SENHA", null);

                acessaBancoDados.AdicionaParametros("@VAR_FUN_DELETE", false.ToString().ToUpper());

                acessaBancoDados.AdicionaParametros("@VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);

                //parametros para o banco de dados Cargos Funcionarios
                acessaBancoDados.AdicionaParametros("@VAR_CAR_DESCRICAO", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_CADASTRO", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_CONSULTA", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_AGENDA", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_FINANCEIRO", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_EXCLUIDO", null);
               

                dtCargoFuncionario = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspFuncionario");

                foreach (DataRow linha in dtCargoFuncionario.Rows)
                {
                    Funcionario funcionario = new Funcionario();

                    funcionario.id = Convert.ToInt32(linha["FUN_ID"].ToString());
                    funcionario.nome = linha["FUN_NOME"].ToString();
                    funcionario.cpf_cnpj = linha["FUN_CPFCNPJ"].ToString();
                    funcionario.rg_ie = linha["FUN_RGIE"].ToString();
                    funcionario.email = linha["FUN_EMAIL"].ToString();
                    funcionario.telefone = linha["FUN_TELEFONE"].ToString();
                    funcionario.celular = linha["FUN_CELULAR"].ToString();
                    funcionario.salario = linha["FUN_SALARIO"].ToString();
                    funcionario.data_admissao = Convert.ToDateTime(linha["FUN_DTADIMISSAO"].ToString());
                    funcionario.comissao = Convert.ToDecimal(linha["FUN_COMISSAO"].ToString());
                    funcionario.sexo = linha["FUN_SEXO"].ToString();

                    funcionario.CargoFuncionarios = new CargosFuncionarios();
                    funcionario.CargoFuncionarios.nomecargo = linha["CAR_DESCRICAO"].ToString();

                    funcionario.endereco = new Endereco();
                    funcionario.endereco.logradouro = linha["FUN_ENDERECO"].ToString();
                    funcionario.endereco.cep = linha["FUN_CEP"].ToString();

                    funcionario.Login = new Login();
                    funcionario.Login.id = Convert.ToInt32(linha["FUN_ID"].ToString());
                    funcionario.Login.usuario =  linha["FUN_LOGIN"].ToString();
                    funcionario.Login.senha = linha["FUN_SENHA"].ToString();

                    listaFuncionario.Add(funcionario);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaFuncionario;
        }

        //Função Funcionando 25/01
        public List<Funcionario> buscaFuncionario(string id)
        {
            List<Funcionario> listaFuncionario = new List<Funcionario>();
            DataTable dtCargoFuncionario;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 2);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ID", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_ID", Convert.ToInt32(id));
                acessaBancoDados.AdicionaParametros("@VAR_FUN_NOME", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_CPFCNPJ", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_RGIE", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_EMAIL", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_ENDERECO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_CEP", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_TELEFONE", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_CELULAR", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_SALARIO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_DTADIMISSAO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_DTNASCIMENTO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_COMISSAO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_SEXO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_LOGIN", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_SENHA", null);

                acessaBancoDados.AdicionaParametros("@VAR_FUN_DELETE", false.ToString().ToUpper());

                acessaBancoDados.AdicionaParametros("@VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtCargoFuncionario = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspFuncionario");

                foreach (DataRow linha in dtCargoFuncionario.Rows)
                {
                    Funcionario funcionario = new Funcionario();

                    funcionario.id = Convert.ToInt32(linha["FUN_ID"].ToString());
                    funcionario.nome = linha["FUN_NOME"].ToString();
                    funcionario.cpf_cnpj = linha["FUN_CPFCNPJ"].ToString();
                    funcionario.rg_ie = linha["FUN_RGIE"].ToString();
                    funcionario.email = linha["FUN_EMAIL"].ToString();
                    funcionario.telefone = linha["FUN_TELEFONE"].ToString();
                    funcionario.celular = linha["FUN_CELULAR"].ToString();
                    funcionario.salario = linha["FUN_SALARIO"].ToString();
                    funcionario.data_admissao = Convert.ToDateTime(linha["FUN_DTADIMISSAO"].ToString());
                    funcionario.data_nascimento = Convert.ToDateTime(linha["FUN_DTNASCIMENTO"].ToString());
                    funcionario.comissao = Convert.ToDecimal(linha["FUN_COMISSAO"].ToString());
                    funcionario.sexo = linha["FUN_SEXO"].ToString();

                    funcionario.endereco = new Endereco();
                    funcionario.endereco.logradouro = linha["FUN_ENDERECO"].ToString();
                    funcionario.endereco.cep = linha["FUN_CEP"].ToString();

                    funcionario.Login = new Login();
                    funcionario.Login.id = Convert.ToInt32(linha["FUN_ID"].ToString());
                    funcionario.Login.usuario = linha["FUN_LOGIN"].ToString();
                    funcionario.Login.senha = linha["FUN_SENHA"].ToString();

                    funcionario.CargoFuncionarios = new CargosFuncionarios();
                    funcionario.CargoFuncionarios.id = Convert.ToInt32(linha["CAR_ID"].ToString());

                    listaFuncionario.Add(funcionario);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaFuncionario;
        }

        //Função Funcionando 25/01
        public List<Funcionario> buscaFuncionario(string id = "", string descricao = "")
        {
            List<Funcionario> listaFuncionario = new List<Funcionario>();
            DataTable dtCargoFuncionario;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 3);
                acessaBancoDados.AdicionaParametros("@CAR_ID", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_ID", descricao.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_FUN_NOME", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_CPFCNPJ", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_RGIE", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_EMAIL", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_ENDERECO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_CEP", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_TELEFONE", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_CELULAR", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_SALARIO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_DTADIMISSAO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_DTNASCIMENTO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_COMISSAO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_SEXO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_LOGIN", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_SENHA", null);

                acessaBancoDados.AdicionaParametros("@VAR_FUN_DELETE", false.ToString().ToUpper());

                acessaBancoDados.AdicionaParametros("@VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtCargoFuncionario = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspCargo");

                foreach (DataRow linha in dtCargoFuncionario.Rows)
                {
                    Funcionario funcionario = new Funcionario();

                    funcionario.id = Convert.ToInt32(linha["FUN_ID"].ToString());
                    funcionario.nome = linha["FUN_NOME"].ToString();
                    funcionario.cpf_cnpj = linha["FUN_CPFCNPJ"].ToString();
                    funcionario.rg_ie = linha["FUN_RGIE"].ToString();
                    funcionario.email = linha["FUN_EMAIL"].ToString();
                    funcionario.telefone = linha["FUN_TELEFONE"].ToString();
                    funcionario.celular = linha["FUN_CELULAR"].ToString();
                    funcionario.salario = linha["FUN_SALARIO"].ToString();
                    funcionario.data_admissao = Convert.ToDateTime(linha["FUN_DTADIMISSAO"].ToString());
                    funcionario.comissao = Convert.ToDecimal(linha["FUN_COMISSAO"].ToString());
                    funcionario.sexo = linha["FUN_SEXO"].ToString();

                    funcionario.endereco = new Endereco();
                    funcionario.endereco.logradouro = linha["FUN_ENDERECO"].ToString();
                    funcionario.endereco.cep = linha["FUN_CEP"].ToString();

                    funcionario.Login = new Login();
                    funcionario.Login.id = Convert.ToInt32(linha["FUN_ID"].ToString());
                    funcionario.Login.usuario = linha["FUN_LOGIN"].ToString();
                    funcionario.Login.senha = linha["FUN_SENHA"].ToString();

                    listaFuncionario.Add(funcionario);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaFuncionario;
        }

        
        public bool deletafuncionario(string id)
        {
            bool lRetorn = false;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 5);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ID", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_ID", Convert.ToInt32(id));
                acessaBancoDados.AdicionaParametros("@VAR_FUN_NOME", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_CPFCNPJ", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_RGIE", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_EMAIL", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_ENDERECO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_CEP", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_TELEFONE", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_CELULAR", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_SALARIO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_DTADIMISSAO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_DTNASCIMENTO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_COMISSAO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_SEXO", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_LOGIN", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_SENHA", null);
                acessaBancoDados.AdicionaParametros("@VAR_FUN_DELETE", true.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);

                acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspFuncionario");

                lRetorn = true;
            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return lRetorn;
        }

        public bool equals(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }
    }
}
