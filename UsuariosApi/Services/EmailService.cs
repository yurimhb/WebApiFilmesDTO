using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;

namespace UsuariosApi.Controller
{
    public class EmailService
    {
        private IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void EnviarEmail(string[] destinatario, string assunto, int id, String codeAtivacao)
        {
            Mensagem msg = new Mensagem(destinatario, assunto, id, codeAtivacao);

            var mensagemDeEmail = CriaCorpoDoEmail(msg);
            Enviar(mensagemDeEmail);
        }

        private void Enviar(MimeMessage mimeMessage)
        {
            using (var client = new SmtpClient())
            {
                try 
                {
                    client.Connect(configuration.GetValue<string>("Emailsettings:smtpserver"),
                                   configuration.GetValue<int>("Emailsettings:port"),
                                   true);
                    client.Authenticate(configuration.GetValue<string>("Emailsettings:from"),
                                        configuration.GetValue<string>("Emailsettings:password"));
                    client.Send(mimeMessage);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CriaCorpoDoEmail(Mensagem msg)
        {
            var mensagemDeEmail = new MimeMessage();
            mensagemDeEmail.From.Add(new MailboxAddress(configuration.GetValue<string>("Emailsettings:from")));
            mensagemDeEmail.To.AddRange(msg.Destinatario);
            mensagemDeEmail.Subject = msg.Assunto;
            mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = msg.Conteudo };

            return mensagemDeEmail;
        }
    }
}