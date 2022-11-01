using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaApi.Models;

namespace PracticaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LlamadasController : ControllerBase
    {


        [HttpGet]
        public IEnumerable<Llamada> Get()
        {
            using (var context = new TelefoniaContext())
            {
                return context.Llamadas.ToList();

            }
        }

        [HttpGet("cod")]


        public List<Object> Get(int cod)
        {

            using (Models.TelefoniaContext DB = new TelefoniaContext())
            {
                var lst = from d in DB.Llamadas
                          where d.CodLlamada == cod
                          select d;


                if (lst.Count() > 0)
                {

                    return lst.ToList<Object>();



                }
                else
                {
                    return lst.ToList<Object>();
                }
            }

        }



        [HttpPut("put")]
        public Llamada Put(Llamada llamada)
        {
            using (var context = new TelefoniaContext())
            {
                var LllamadaP = context.Llamadas.FirstOrDefault(x =>x.CodLlamada  == llamada.CodLlamada);
                LllamadaP.CodLlamada = llamada.CodLlamada;
                LllamadaP.Telefono = llamada.Telefono;
                LllamadaP.Fecha = llamada.Fecha;
                LllamadaP.Duracion = llamada.Duracion;
                context.SaveChanges();
                return llamada;
            }
        }





        [HttpDelete]
        public bool Delete(int cod)
        {
            using (var context = new TelefoniaContext())
            {
                var LlamadasDel = context.Llamadas.FirstOrDefault(x => x.CodLlamada == cod);
                context.Llamadas.Remove(LlamadasDel);
                context.SaveChanges();
                return true;
            }

        }





        [HttpPost("Post")]
        public Llamada Post(Llamada llamada)
        {
            using (var context = new TelefoniaContext())
            {
                context.Llamadas.Add(llamada);
                context.SaveChanges();
                return llamada;
            }
        }

    }
}


