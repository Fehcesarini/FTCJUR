using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoBancoDados;
using System.Data;

namespace Negocio
{
    public class SerialKeyDAO : ISerialKey
    {
        AcessaBancoDadosSerialKey acessaBancoDados = new AcessaBancoDadosSerialKey(Definicoes.bancoSerial, Definicoes.serverSerial, Definicoes.usuarioSerial, Definicoes.senhaSerial);

        public object atualizaSerial(SerialKey serialkey)
        {
            object id;
            try
            {

                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 2);
                acessaBancoDados.AdicionaParametros("VAR_cha_id", serialkey.id);
                acessaBancoDados.AdicionaParametros("VAR_emp_id", serialkey.idEmpresa);
                acessaBancoDados.AdicionaParametros("VAR_emp_cnpj", serialkey.cnpjCPF.ToUpper());
                acessaBancoDados.AdicionaParametros("VAR_cha_macadress", serialkey.macadress.ToString());
                acessaBancoDados.AdicionaParametros("VAR_cha_chave", serialkey.serialkey.ToString());
                acessaBancoDados.AdicionaParametros("VAR_emp_razaosocial", serialkey.RazaoSocial.ToString());
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                id = acessaBancoDados.ExecultarManipulacao(CommandType.StoredProcedure, "uspChaves");

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            return id;
        }
      
        public SerialKey buscaSerial(string CNPJ, string serialkey)
        {
            SerialKey listaSerialKey = new SerialKey();
            DataTable dtSerialKey;
            try
            {
                
                SerialKey chave = new SerialKey();
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 0);
                acessaBancoDados.AdicionaParametros("VAR_cha_id", null);
                acessaBancoDados.AdicionaParametros("VAR_emp_id", null);
                acessaBancoDados.AdicionaParametros("VAR_emp_cnpj", CNPJ);
                acessaBancoDados.AdicionaParametros("VAR_cha_macadress", null);
                acessaBancoDados.AdicionaParametros("VAR_cha_chave", serialkey);
                acessaBancoDados.AdicionaParametros("VAR_emp_razaosocial", null);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtSerialKey = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspChaves");

                foreach (DataRow linha in dtSerialKey.Rows)
                {

                    listaSerialKey.id = linha["cha_id"].ToString();
                    listaSerialKey.idEmpresa = linha["emp_id"].ToString();
                    listaSerialKey.cnpjCPF = linha["emp_cnpj"].ToString();
                    listaSerialKey.RazaoSocial = linha["emp_razaosocial"].ToString();
                    listaSerialKey.serialkey = linha["cha_chave"].ToString();
                    listaSerialKey.macadress = linha["cha_macadress"].ToString();
                   
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaSerialKey;
        }

        public SerialKey buscaSerial(string CNPJ, string serialkey, string macadress)
        {
            SerialKey listaSerialKey = new SerialKey();
            DataTable dtSerialKey;
            try
            {

                SerialKey chave = new SerialKey();
                acessaBancoDados.LimpaParametros();
                acessaBancoDados.AdicionaParametros("@acao", 1);
                acessaBancoDados.AdicionaParametros("VAR_cha_id", null);
                acessaBancoDados.AdicionaParametros("VAR_emp_id", null);
                acessaBancoDados.AdicionaParametros("VAR_emp_cnpj", CNPJ);
                acessaBancoDados.AdicionaParametros("VAR_cha_macadress", macadress);
                acessaBancoDados.AdicionaParametros("VAR_cha_chave", serialkey);
                acessaBancoDados.AdicionaParametros("VAR_emp_razaosocial", null);
                acessaBancoDados.AdicionaParametros("VAR_SENHA_CRIPTOGRAFIA", Definicoes.senhaCriptografia);
                dtSerialKey = acessaBancoDados.ExecultarConsulta(CommandType.StoredProcedure, "uspChaves");

                foreach (DataRow linha in dtSerialKey.Rows)
                {

                    listaSerialKey.id = linha["cha_id"].ToString();
                    listaSerialKey.idEmpresa = linha["emp_id"].ToString();
                    listaSerialKey.cnpjCPF = linha["emp_cnpj"].ToString();
                    listaSerialKey.RazaoSocial = linha["emp_razaosocial"].ToString();
                    listaSerialKey.serialkey = linha["cha_chave"].ToString();
                    chave.macadress = linha["cha_macadress"].ToString();
                    
                }

            }
            catch (Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }

            return listaSerialKey;
        }

        public bool equals(SerialKey serialkey)
        {
            throw new NotImplementedException();
        }
    }
}
