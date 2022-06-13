using System;
using System.Collections;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text.RegularExpressions;

namespace ProjetoPrisma5
{
    public class EnviarEmail
    {
        public bool ValidaEnderecoEmail(string email)
        {
            try
            {
                //define a expressão regulara para validar o email
                string texto_Validar = email;
                Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

                // testa o email com a expressão
                if (expressaoRegex.IsMatch(texto_Validar))
                {
                    // o email é valido
                    return true;
                }
                else
                {
                    // o email é inválido
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string EnviaMensagemComAnexos(string Destinatario)
        {
            string Remetente = "fragas_quer_cafe@yahoo.com";
            string Senha = "querocafe123*";
            string Assunto = "Cidades";
            string enviaMensagem = "";
            string anexo = @"C:\Users\Pichau\Desktop\Nova pasta\Teste_pratico_prisma\WebApplication1\WebApplication1\Dados\teste.xlsx";
            try
            {
                // valida o email
                bool bValidaEmail = ValidaEnderecoEmail(Destinatario);

                if (bValidaEmail == false)
                    return "Email do destinatário inválido:" + Destinatario;

                // Cria uma mensagem
                MailMessage mensagemEmail = new MailMessage(
                   Remetente, Destinatario, Assunto, enviaMensagem);

                // Adiciona o anexo;
                Attachment anexado = new Attachment(anexo, MediaTypeNames.Application.Octet);
                mensagemEmail.Attachments.Add(anexado);

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                NetworkCredential cred = new NetworkCredential(Remetente, Senha);
                client.Credentials = cred;

                // Inclui as credenciais
                client.UseDefaultCredentials = false;

                // envia a mensagem
                client.Send(mensagemEmail);

                return "Mensagem enviada para " + Destinatario + " às " + DateTime.Now.ToString() + ".";
            }
            catch (Exception ex)
            {
                string erro = ex.InnerException.ToString();
                return ex.Message.ToString() + erro;
            }
        }
    }
}
