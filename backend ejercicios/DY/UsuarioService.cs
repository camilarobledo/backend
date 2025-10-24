namespace MiPrimerApi.DY
{
    public class UsuarioService
    {

        private readonly IEmailService emailService; 

       
        public UsuarioService(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public void NotificarUsuario(string email)
        {

            emailService.Enviar(email, "Notificación");

        }

        public string CrearUsuario(string nombre, string email)
        {
            try
            {
                if (!emailService.ValidarEmail(email))
                {
                    return "Email inválido";
                }

                Console.WriteLine($"Creando usuario: {nombre} con email: {email}");

                emailService.Enviar(email, $"¡Bienvenido {nombre}! Tu cuenta ha sido creada.");

                return $"Usuario {nombre} creado exitosamente";
            }
            catch (Exception ex)
            {
                return $"Error al crear usuario: {ex.Message}"; 
            }
        }

        public string EnviarMensajePersonalizado(string email, string mensaje)
        {
            try
            {
                if (emailService.ValidarEmail(email))
                {
                    emailService.Enviar(email, mensaje);
                    return "Mensaje enviado exitosamente";
                }
                return "Email inválido";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }



        }
    }
}
