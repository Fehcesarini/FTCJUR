using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoBancoDados;
using System.Data;

namespace Negocio
{
    public class CargosFuncionariosDAO : ICargosFuncionarios
    {

        AcessaBancoDados acessaBancoDados = new AcessaBancoDados(Definicoes.banco, Definicoes.server, Definicoes.usuario, Definicoes.senha);


        //Função Abaixo Completa 19/01
        public object atualizaCargosFuncionarios(CargosFuncionarios cargosfuncionarios)
        {
            object id;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 4);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ID", cargosfuncionarios.id);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_DESCRICAO", cargosfuncionarios.nomecargo.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_CADASTRO", cargosfuncionarios.permissaocadastro.ToString());
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_CONSULTA", cargosfuncionarios.permissaoconsulta.ToString());
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_AGENDA", cargosfuncionarios.permissaoagenda.ToString());
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_FINANCEIRO", cargosfuncionarios.permissaofinanceiro.ToString());
                acessaBancoDados.AdicionaParametros("@VAR_CAR_EXCLUIDO", false.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);

                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspCargo");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;
        }


        //Função Abaixo Completa 19/01
        public List<CargosFuncionarios> buscaCargosFuncionarios()
        {
            
            List<CargosFuncionarios> listaCargoFuncionario = new List<CargosFuncionarios>();
            DataTable dtCargoFuncionario;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 1);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ID", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_DESCRICAO", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_CADASTRO",null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_CONSULTA", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_AGENDA", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_FINANCEIRO", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_EXCLUIDO", null);
                acessaBancoDados.AdicionaParametros("@VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtCargoFuncionario = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspCargo");

                foreach (DataRow linha in dtCargoFuncionario.Rows)
                {
                    CargosFuncionarios CargoFuncionario = new CargosFuncionarios();

                    CargoFuncionario.id = Convert.ToInt32(linha["CAR_ID"].ToString());
                    CargoFuncionario.nomecargo = linha["CAST(AES_DECRYPT(CAR_DESCRICAO,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString();
                    CargoFuncionario.permissaocadastro = Convert.ToBoolean(linha["CAST(AES_DECRYPT(CAR_ACESSO_CADASTRO,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString());
                    CargoFuncionario.permissaoconsulta = Convert.ToBoolean(linha["CAST(AES_DECRYPT(CAR_ACESSO_CONSULTA,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString());
                    CargoFuncionario.permissaoagenda = Convert.ToBoolean(linha["CAST(AES_DECRYPT(CAR_ACESSO_AGENDA,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString());
                    CargoFuncionario.permissaofinanceiro = Convert.ToBoolean(linha["CAST(AES_DECRYPT(CAR_ACESSO_FINANCEIRO,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString());
                    listaCargoFuncionario.Add(CargoFuncionario);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaCargoFuncionario;

        }


        //Função Abaixo Completa 19/01
        public List<CargosFuncionarios> buscaCargosFuncionarios(string id)
        {
            List<CargosFuncionarios> listaCargoFuncionario = new List<CargosFuncionarios>();
            DataTable dtCargoFuncionario;
            try                
            {
                CargosFuncionarios CargoFuncionario = new CargosFuncionarios();
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 2);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ID", id);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_DESCRICAO", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_CADASTRO", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_CONSULTA", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_AGENDA", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_FINANCEIRO", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_EXCLUIDO", null);
                acessaBancoDados.AdicionaParametros("@VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);

                dtCargoFuncionario = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspCargo");

                foreach (DataRow linha in dtCargoFuncionario.Rows)
                {

                    CargoFuncionario.id = Convert.ToInt32(linha["CAR_ID"].ToString());
                    CargoFuncionario.nomecargo = linha["CAST(AES_DECRYPT(CAR_DESCRICAO,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString();
                    CargoFuncionario.permissaocadastro = Convert.ToBoolean(linha["CAST(AES_DECRYPT(CAR_ACESSO_CADASTRO,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString());
                    CargoFuncionario.permissaoconsulta = Convert.ToBoolean(linha["CAST(AES_DECRYPT(CAR_ACESSO_CONSULTA,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString());
                    CargoFuncionario.permissaoagenda = Convert.ToBoolean(linha["CAST(AES_DECRYPT(CAR_ACESSO_AGENDA,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString());
                    CargoFuncionario.permissaofinanceiro = Convert.ToBoolean(linha["CAST(AES_DECRYPT(CAR_ACESSO_FINANCEIRO,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString());
                    listaCargoFuncionario.Add(CargoFuncionario);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaCargoFuncionario;


        }




        public CargosFuncionarios buscaCargosFuncionariosPopulatextbox(string id)
        {
            CargosFuncionarios cargospoup = new CargosFuncionarios();
            DataTable dtCargoFuncionario;
            try
            {
                CargosFuncionarios CargoFuncionario = new CargosFuncionarios();
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 2);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ID", id);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_DESCRICAO", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_CADASTRO", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_CONSULTA", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_AGENDA", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_FINANCEIRO", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_EXCLUIDO", null);
                acessaBancoDados.AdicionaParametros("@VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);

                dtCargoFuncionario = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspCargo");

                foreach (DataRow linha in dtCargoFuncionario.Rows)
                {

                    cargospoup.id = Convert.ToInt32(linha["CAR_ID"].ToString());
                    cargospoup.nomecargo = linha["CAST(AES_DECRYPT(CAR_DESCRICAO,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString();
                    cargospoup.permissaocadastro = Convert.ToBoolean(linha["CAST(AES_DECRYPT(CAR_ACESSO_CADASTRO,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString());
                    cargospoup.permissaoconsulta = Convert.ToBoolean(linha["CAST(AES_DECRYPT(CAR_ACESSO_CONSULTA,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString());
                    cargospoup.permissaoagenda = Convert.ToBoolean(linha["CAST(AES_DECRYPT(CAR_ACESSO_AGENDA,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString());
                    cargospoup.permissaofinanceiro = Convert.ToBoolean(linha["CAST(AES_DECRYPT(CAR_ACESSO_FINANCEIRO,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString());
                    
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return cargospoup;


        }


        //Função Abaixo Completa19/01
        public List<CargosFuncionarios> buscaCargosFuncionarios(string id, string descricao)
        {
            List<CargosFuncionarios> listaCargoFuncionario = new List<CargosFuncionarios>();
            DataTable dtCargoFuncionario;
            try
            {
                CargosFuncionarios CargoFuncionario = new CargosFuncionarios();
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 3);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ID", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_DESCRICAO", Criptografia.EncryptString(descricao));
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_CADASTRO", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_CONSULTA", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_AGENDA", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_FINANCEIRO", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_EXCLUIDO", null);

                dtCargoFuncionario = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspCargo");

                foreach (DataRow linha in dtCargoFuncionario.Rows)
                {

                    CargoFuncionario.id = Convert.ToInt32(linha["CAR_ID"].ToString());
                    CargoFuncionario.id = Convert.ToInt32(linha["CAR_ID"].ToString());
                    CargoFuncionario.nomecargo = linha["CAST(AES_DECRYPT(CAR_DESCRICAO,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString();
                    CargoFuncionario.permissaocadastro = Convert.ToBoolean(linha["CAST(AES_DECRYPT(CAR_ACESSO_CADASTRO,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString());
                    CargoFuncionario.permissaoconsulta = Convert.ToBoolean(linha["CAST(AES_DECRYPT(CAR_ACESSO_CONSULTA,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString());
                    CargoFuncionario.permissaoagenda = Convert.ToBoolean(linha["CAST(AES_DECRYPT(CAR_ACESSO_AGENDA,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString());
                    CargoFuncionario.permissaofinanceiro = Convert.ToBoolean(linha["CAST(AES_DECRYPT(CAR_ACESSO_FINANCEIRO,VAR_SENHA_CRIPTOGRAFIA) as char)"].ToString());
                    listaCargoFuncionario.Add(CargoFuncionario);
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaCargoFuncionario;

        }


        //Função Abaixo Completa 19/01
        public object cadastroCargosFuncionarios(CargosFuncionarios cargosfuncionarios)
        {

            object id;
            try
            {
                
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 0);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ID", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_DESCRICAO", cargosfuncionarios.nomecargo.ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_CADASTRO", cargosfuncionarios.permissaocadastro.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_CONSULTA", cargosfuncionarios.permissaoconsulta.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_AGENDA", cargosfuncionarios.permissaoagenda.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_FINANCEIRO", cargosfuncionarios.permissaofinanceiro.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_CAR_EXCLUIDO", false.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);

                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspCargo");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;
            
        }


        //Função funcionando 25/01
        public bool deletaCargosFuncionarios(string id)
        {
            bool lRetorn = false;
            try
            {
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 5);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ID", Convert.ToInt32(id));
                acessaBancoDados.AdicionaParametros("@VAR_CAR_DESCRICAO", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_CADASTRO", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_CONSULTA",null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_AGENDA", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_ACESSO_FINANCEIRO", null);
                acessaBancoDados.AdicionaParametros("@VAR_CAR_EXCLUIDO", true.ToString().ToUpper());
                acessaBancoDados.AdicionaParametros("@VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspCargo");
                lRetorn = true;
            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return lRetorn;
        }

        public bool equals(CargosFuncionarios Cargosfuncionarios)
        {
            throw new NotImplementedException();
        }
    }
}
