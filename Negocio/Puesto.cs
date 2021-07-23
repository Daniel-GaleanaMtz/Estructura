using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Puesto
    {
        public int IdPuesto { get; set; }
        public string Descripcion { get; set; }
        public List<object> Puestos { get; set; }

        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (AccesoDatos.DGaleanaEstructuraEntities context = new AccesoDatos.DGaleanaEstructuraEntities())
                {
                    var puestos = context.GetAllPuesto().ToList();
                    result.Objects = new List<object>();
                    if (puestos != null)
                    {
                        foreach (var objs in puestos)
                        {
                            Puesto puesto = new Puesto();

                            puesto.IdPuesto = objs.IdPuesto;
                            puesto.Descripcion = objs.Descripcion;

                            result.Objects.Add(puesto);
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
