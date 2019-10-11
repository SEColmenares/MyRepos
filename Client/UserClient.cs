using System.Collections.Generic;
using System.Threading.Tasks;
using MVC_Core.Models;

namespace MVC_Core.Client
{
    public partial class ApiClient
    {
        public async Task<List<DatosBasicosUsuario>> GetUsers()
        {
            var requestURL = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "values"));  
            return await GetAsync<List<DatosBasicosUsuario>>(requestURL);
        }

        public async Task<Message<DatosBasicosUsuario>> SaveUsers(DatosBasicosUsuario datosUsuario)
        {
            var requestURL = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "values/1"));
            return await  PostAsync<DatosBasicosUsuario>(requestURL, datosUsuario);
        }

    }
}