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
    public class TelefonoesController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Telefono> Get()
        {
            using (var context = new TelefoniaContext())
            {
                return context.Telefonos.ToList();

            }
        }

        [HttpGet("id")]


        public List<Object> Get(int id)
        {

            using (Models.TelefoniaContext DB = new TelefoniaContext())
            {
                var lst = from d in DB.Telefonos
                          where d.IdCliente == id
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

        [HttpDelete]
        public bool Delete(string numero)
        {
            using (var context = new TelefoniaContext())
            {
                var TelefonoDel = context.Telefonos.FirstOrDefault(x => x.Telefono1 == numero);
                context.Telefonos.Remove(TelefonoDel);
                context.SaveChanges();
                return true;
            }

        }


        [HttpPut("put")]
        public Telefono Put(Telefono telefono)
        {
            using (var context = new TelefoniaContext())
            {
                var telefonoP = context.Telefonos.FirstOrDefault(x => x.Telefono1 == telefono.Telefono1);
                telefonoP.Telefono1 = telefono.Telefono1;
                telefonoP.TipoPlan = telefono.TipoPlan;
                context.SaveChanges();
                return telefono;
            }
        }






        [HttpPost("Post")]
        public Telefono Post(Telefono telefono)
        {
            using (var context = new TelefoniaContext())
            {
                context.Telefonos.Add(telefono);
                context.SaveChanges();
                return telefono;
            }
        }

    }
}


