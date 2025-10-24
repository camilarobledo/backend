namespace MiPrimerApi.DY
{
    public interface IEmailService
    {
        void Enviar(string email, string mensaje);
        bool ValidarEmail(string email);
    }
}
