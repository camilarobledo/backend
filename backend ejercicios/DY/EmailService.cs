namespace MiPrimerApi.DY
{ 
   
        public class EmailService : IEmailService
        {
            public void Enviar(string email, string mensaje)
            {
                
                Console.WriteLine($"Enviando email a {email} con el mensaje: {mensaje}");
            }

            public bool ValidarEmail(string email)
            {
                
                return email.Contains("@");
            }
        }
    }

