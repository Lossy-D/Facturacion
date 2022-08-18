using GIGIS.FACTUR.ENTITY.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIGIS.Models
{
    public class modelList
    {
        public List<ResponseDepartamento> listDepartamento { get; set; }

        public List<ResponseMoneda> listMoneda { get; set; }

        public List<ResponseTImpuesto> listTImpuesto { get; set; }

        public List<ResponsePImpuestos> listPImpuestos { get; set; }
    }
}