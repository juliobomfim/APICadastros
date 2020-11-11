namespace ApiCad.Domain.Modelos.Saidas
{
    public enum RespostaTipo
    {
        Sucesso,
        Falha,
        Aviso
    }
    public class Resposta
    {
        private Resposta(string mensagem, RespostaTipo tipo, object data)
        {
            Mensagem = mensagem;
            Tipo = tipo;
            Data = data;
        }

        public string Mensagem { get; set; }
        public RespostaTipo Tipo { get; set; }
        public object Data { get; set; }

        public static Resposta Sucesso(string mensagem, object data = null) => new Resposta(mensagem, RespostaTipo.Sucesso, data);
        public static Resposta Falha(string mensagem, object data = null) => new Resposta(mensagem, RespostaTipo.Falha, data);
        public static Resposta Aviso(string mensagem, object data = null) => new Resposta(mensagem, RespostaTipo.Aviso, data);
    }
}
