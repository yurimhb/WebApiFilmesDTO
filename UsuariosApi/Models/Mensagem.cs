using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace UsuariosApi.Controller
{
    public class Mensagem
    {
        private List<MailboxAddress> destinatario;
        private string assunto;
        private string codeudo;
        private int id;
        private string codeAtivacao;

        public Mensagem(string[] destinatario, string assunto, int id, string codeAtivacao)
        {
            this.destinatario = new List<MailboxAddress>();
            this.destinatario.AddRange(destinatario.Select(x => new MailboxAddress(x)));
            this.assunto = assunto;
            this.id = id;
            this.codeAtivacao = codeAtivacao;
            this.codeudo = $"https://localhost:6001/ativa?id={id}&codigodeativacao={codeAtivacao}";
        }

        public List<MailboxAddress> Destinatario { get => destinatario;}
        public string Assunto { get => assunto; set => assunto = value; }
        public int Id { get => id; set => id = value; }
        public string CodeAtivacao { get => codeAtivacao; set => codeAtivacao = value; }
        public string Conteudo { get => codeudo; set => codeudo = value; }
    }
}