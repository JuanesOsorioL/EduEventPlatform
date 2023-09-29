using System.Net;

namespace EduEventPlatform.WEB.Repositories
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Error = error;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }

        public bool Error { get; set; }

        public T? Response { get; set; }

        public HttpResponseMessage HttpResponseMessage { get; set; }

        //Opcion 2-->
        /*
        private string BuildFriendlyErrorMessage(ValidationErrorResponse errorObj)
        {
            if (errorObj?.errors == null) return "Datos incompletos o incorrectos. Por favor, revise y complete el formulario.";

            var sb = new StringBuilder();
            sb.AppendLine("Por favor corrija los siguientes errores:");

            foreach (var error in errorObj.errors)
            {
                sb.AppendLine($"- {string.Join(", ", error.Value)}");
            }

            return sb.ToString();
        }
        
        private class ValidationErrorResponse
        {
            public Dictionary<string, List<string>> errors { get; set; }
        }
        */
        public async Task<string?> GetErrorMessageAsync()
        {

            if (!Error)
            {
                return null;
            }

            var codigoEstatus = HttpResponseMessage.StatusCode;
            if (codigoEstatus == HttpStatusCode.NotFound)
            {
                return "Recurso no encontrado";
            }
            else if (codigoEstatus == HttpStatusCode.BadRequest)
            {

                //Opcion del profe
                return await HttpResponseMessage.Content.ReadAsStringAsync();
                //Opcion 1-->// return "Datos incompletos o incorrectos. Por favor, revise y complete el formulario.";
                //Opcion 2-->//var errorContent = await HttpResponseMessage.Content.ReadAsStringAsync();
                //Opcion 2-->//var errorObj = JsonSerializer.Deserialize<ValidationErrorResponse>(errorContent);
                //Opcion 2-->//var friendlyErrorMessage = BuildFriendlyErrorMessage(errorObj);
                //Opcion 2-->//return friendlyErrorMessage;
            }
            else if (codigoEstatus == HttpStatusCode.Unauthorized)
            {
                return " Debes loguearte para realizar esta acción";
            }
            else if (codigoEstatus == HttpStatusCode.Forbidden)
            {
                return " No tienes permisos para ejecutar esta acción";
            }

            return "Ha ocurrido un error inesperado";
        }
    }
}

