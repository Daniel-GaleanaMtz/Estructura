using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public Puesto Puesto { get; set; }
        public Departamento Departamento { get; set; }
        public List<object> Empleados { get; set; }

        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (AccesoDatos.DGaleanaEstructuraEntities context = new AccesoDatos.DGaleanaEstructuraEntities())
                {
                    var Empleados = context.GetEmpleadoPuestoDepartamento().ToList();
                    result.Objects = new List<object>();
                    if (Empleados != null)
                    {
                        foreach (var objs in Empleados)
                        {
                            Empleado empleado = new Empleado();

                            empleado.IdEmpleado = objs.IdEmpleado;
                            empleado.Nombre = objs.Nombre;
                            empleado.Puesto = new Puesto();
                            empleado.Puesto.IdPuesto = objs.IdPuesto.Value;
                            empleado.Puesto.Descripcion = objs.PuestoDescripcion;

                            empleado.Departamento = new Departamento();
                            empleado.Departamento.IdDepartamento = objs.IdDepartamento.Value;
                            empleado.Departamento.Descripcion = objs.DepartamentoDescripcion;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }

        public static Result GetAllByName(Empleado empleadoItem)
        {
            Result result = new Result();
            try
            {
                using (AccesoDatos.DGaleanaEstructuraEntities context = new AccesoDatos.DGaleanaEstructuraEntities())
                {
                    var Empleados = context.GetByNameEmpleado(empleadoItem.Nombre).ToList();
                    result.Objects = new List<object>();
                    if (Empleados != null)
                    {
                        foreach (var objs in Empleados)
                        {
                            Empleado empleado = new Empleado();

                            empleado.IdEmpleado = objs.IdEmpleado;
                            empleado.Nombre = objs.Nombre;
                            empleado.Puesto = new Puesto();
                            empleado.Puesto.IdPuesto = objs.IdPuesto.Value;
                            empleado.Puesto.Descripcion = objs.PuestoDescripcion;

                            empleado.Departamento = new Departamento();
                            empleado.Departamento.IdDepartamento = objs.IdDepartamento.Value;
                            empleado.Departamento.Descripcion = objs.DepartamentoDescripcion;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }

        public static Result Add(Empleado empleado)
        {
            Result result = new Result();
            try
            {
                using (AccesoDatos.DGaleanaEstructuraEntities context = new AccesoDatos.DGaleanaEstructuraEntities())
                {
                    var query = context.AddEmpleado(empleado.Nombre, empleado.Puesto.IdPuesto, empleado.Departamento.IdDepartamento);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }

        public static Result Delete(Empleado empleado)
        {
            Result result = new Result();
            try
            {
                using (AccesoDatos.DGaleanaEstructuraEntities context = new AccesoDatos.DGaleanaEstructuraEntities())
                {
                    var query = context.DeleteEmpleado(empleado.IdEmpleado);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }

    }
}
