
using GIGIS.FACTUR.ENTITY.Parametros;
using GIGIS.FACTUR.BUSINESS;
using GIGIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GIGIS.Controllers
{
    public class RegistroEmpresaController : Controller
    {
        private modelList model;
        private BUDepartamento budepartamento;
        private BURegistroEmpresa buregistroempresa;
        public RegistroEmpresaController()
        {
            model = new modelList();
            budepartamento = new BUDepartamento();
            buregistroempresa = new BURegistroEmpresa();
        }
       
        public ActionResult RegistroEmpresa(ENRegistroEmpresa paramss)
        {
            string token = "";

            model.listDepartamento = budepartamento.listaDepartamento(paramss, token);

            model.listMoneda = budepartamento.listarMoneda(paramss, token);

            model.listTImpuesto = budepartamento.listarTImpuestos(paramss, token);

            model.listPImpuestos = budepartamento.listarPImpuestos(paramss, token);

            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult validarRegistro(ENRegistroEmpresa paramss)
        {
            string token = "";
            var rpt = buregistroempresa.validarRegistro(paramss, token);
            return Json(new { dt = rpt });
        }

    }
}
