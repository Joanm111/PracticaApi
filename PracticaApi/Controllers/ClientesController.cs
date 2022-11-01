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
    public class ClientesController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            using (var context = new TelefoniaContext())
            {
                return context.Clientes.ToList();

            }
        }

        [HttpGet("id")]


        public List<Object> Get(int id)
        {

            using (Models.TelefoniaContext DB = new TelefoniaContext())
            {
                var lst = from d in DB.Clientes
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

        [HttpPut("put")]
        public Cliente Put(Cliente cliente)
        {
            using (var context = new TelefoniaContext())
            {
                var ClienteP = context.Clientes.FirstOrDefault(x => x.IdCliente == cliente.IdCliente);
                ClienteP.Nombre = cliente.Nombre;
                ClienteP.Apellido = cliente.Apellido;
                ClienteP.FechaNacimiento = cliente.FechaNacimiento;
                context.SaveChanges();
                return cliente;
            }
        }



        [HttpDelete]
        public bool Delete(int id)
        {
            using (var context = new TelefoniaContext())
            {
                var ClientesDel = context.Clientes.FirstOrDefault(x => x.IdCliente == id);
                context.Clientes.Remove(ClientesDel);
                context.SaveChanges();
                return true;
            }

        }





        [HttpPost("Post")]
        public Cliente Post(Cliente cliente)
        {
            using (var context = new TelefoniaContext())
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
                return cliente;
            }
        }

    }
}


