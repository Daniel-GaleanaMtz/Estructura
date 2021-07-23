using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Departamento
    {
        public int IdDepartamento { get; set; }
        public string Descripcion { get; set; }
        public List<object> Departamentos { get; set; }

        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (AccesoDatos.DGaleanaEstructuraEntities context = new AccesoDatos.DGaleanaEstructuraEntities())
                {
                    var departamentos = context.GetAllDepartamento();
                    result.Objects = new List<object>();
                    if (departamentos != null)
                    {
                        foreach (var objs in departamentos)
                        {
                            Departamento departamento = new Departamento();

                            departamento.IdDepartamento = objs.IdDepartamento;
                            departamento.Descripcion = objs.Descripcion;

                            result.Objects.Add(departamento);
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
    }
}
