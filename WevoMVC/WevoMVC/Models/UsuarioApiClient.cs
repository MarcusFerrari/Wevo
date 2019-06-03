using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WevoMVC.Models
{
    public partial class ApiClient
    {
        public async Task<Message<Usuario>> cadastra(Usuario model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "api/usuario/addUsuario"));
            return await PostAsync<Usuario, Usuario>(requestUrl, model);
        }
    }
}
