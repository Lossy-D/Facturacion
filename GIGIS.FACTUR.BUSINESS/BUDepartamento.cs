using GIGIS.FACTUR.ENTITY.Parametros;
using GIGIS.FACTUR.ENTITY.Response;
using GIGIS.FACTUR.CLIENTS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIGIS.FACTUR.BUSINESS
{
    public class BUDepartamento
    {
        private Client client;

        public BUDepartamento()
        {
            client = new Client();
        }

        public List<ResponseDepartamento> listaDepartamento(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponseDepartamento>>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/listarDepartamentos", paramss, token));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<ResponseMoneda> listarMoneda(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponseMoneda>>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/listarMoneda", paramss, token));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ResponseTImpuesto> listarTImpuestos(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponseTImpuesto>>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/listarTImpuestos", paramss, token));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ResponsePImpuestos> listarPImpuestos(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponsePImpuestos>>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/listarPImpuestos", paramss, token));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}
