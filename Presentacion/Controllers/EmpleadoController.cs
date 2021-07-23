using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class EmpleadoController : Controller
    {
        //
        // GET: /Empleado/
        public ActionResult GetAll()
        {
            Negocio.Empleado empleado = new Negocio.Empleado();
            if (empleado.Nombre == null)
            {
                empleado.Nombre = "";
            }
            Negocio.Result result = Negocio.Empleado.GetAllByName(empleado);
            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
            }
            else
            {

            }
            return View(empleado);

        }

        [HttpPost]
        public ActionResult GetAll(Negocio.Empleado empleado)
        {
            if (empleado.Nombre == null)
            {
                empleado.Nombre = "";
            }
            Negocio.Result result = Negocio.Empleado.GetAllByName(empleado);
            empleado.Empleados = result.Objects;
            return View(empleado);
        }

        public ActionResult Delete(int IdEmpleado)
        {
            Negocio.Empleado empleado = new Negocio.Empleado();
            empleado.IdEmpleado = IdEmpleado;
            Negocio.Result result = Negocio.Empleado.Delete(empleado);

            return RedirectToAction("GetAll");
        }

        public ActionResult Form()
        {
            Negocio.Empleado empleado = new Negocio.Empleado();

            Negocio.Result resultDepto = Negocio.Departamento.GetAll();
            empleado.Departamento = new Negocio.Departamento();
            empleado.Departamento.Departamentos = resultDepto.Objects;

            Negocio.Result resultPuesto = Negocio.Puesto.GetAll();
            empleado.Puesto = new Negocio.Puesto();
            empleado.Puesto.Puestos = resultPuesto.Objects;

            return View(empleado);
        }

        [HttpPost]
        public ActionResult Form(Negocio.Empleado empleado)
        {
            Negocio.Result result = Negocio.Empleado.Add(empleado);
            if (result.Correct)
            {
                
            }
            return RedirectToAction("GetAll");
        }
	}
}