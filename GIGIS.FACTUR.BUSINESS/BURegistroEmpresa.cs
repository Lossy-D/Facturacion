using GIGIS.FACTUR.BIBLIOTEC.Response;
using GIGIS.FACTUR.CLIENTS;
using GIGIS.FACTUR.ENTITY.Parametros;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIGIS.FACTUR.BUSINESS
{
    public class BURegistroEmpresa
    {
        private Client clients;

        public BURegistroEmpresa()
        {
            clients = new Client();
        }

        public ResponseRegistroEmpresa validarRegistro(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseRegistroEmpresa>(clients.Post<ENRegistroEmpresa>("RegistroEmpresa/validarRegistro", paramss, token));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
