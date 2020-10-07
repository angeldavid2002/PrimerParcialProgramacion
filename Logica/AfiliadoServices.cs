using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
namespace Logica
{
    public class AfiliadoServices
    {
        static AfiliadoRepositorio afiliadoRepositorio;
        public AfiliadoServices()
        {
            afiliadoRepositorio = new AfiliadoRepositorio();
        }
        public string Guardar(Afiliado afiliado)
        {
            try
            {
                afiliadoRepositorio.Guardar(afiliado);
                return "se guardo exitosamente";
            }
            catch (Exception e)
            {

                return "error de la aplicacion: " + (e.Message);
            }
        }
        public class RespuestaAfiliado
        {
            public List<Afiliado> afiliaciones { get; set; }
            public bool listaVacia { get; set; }
            public string mensaje { get; set; }
            public RespuestaAfiliado(List<Afiliado> afiliaciones)
            {
                this.afiliaciones = afiliaciones;
                this.listaVacia = false;
                this.mensaje = "lectura exitosa";
            }
            public RespuestaAfiliado(string mensaje)
            {
                this.listaVacia = true;
                this.mensaje = mensaje;
            }
        }
        public RespuestaAfiliado ConsultarTodos()
        {
            RespuestaAfiliado respuestaAfiliado;
            try
            {
                if(afiliadoRepositorio.ConsultarTodos()!= null)
                {
                    List<Afiliado> afiliaciones = afiliadoRepositorio.ConsultarTodos();
                    respuestaAfiliado = new RespuestaAfiliado(afiliaciones);
                    return respuestaAfiliado;
                }
                else
                {
                    return respuestaAfiliado = new RespuestaAfiliado("no se encontraron elementos");
                }
            }
            catch (Exception e)
            {

                return respuestaAfiliado = new RespuestaAfiliado("se produjo un error: "+e.Message);
            }
        }
        public string AsignarNumeroLiquidacion(Afiliado afiliado)
        {
            try
            {
                if (afiliadoRepositorio.ConsultarTodos().Any())
                {
                    afiliado.numeroLiquidacion = afiliadoRepositorio.ConsultarTodos().Last().numeroLiquidacion + 1;
                    return "operacion realizada con exito";
                }
                else
                {
                    afiliado.numeroLiquidacion = 1;
                    return "operacion realizada con exito";
                }
            }
            catch (Exception e)
            {
                return "ocurrio un error: "+e.Message;
            }
            
        }
    }
}
