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
    public class PlanesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Plane> Get()
        {
            using (var context = new TelefoniaContext())
            {
                return context.Planes.ToList();

            }
        }

        [HttpGet("id")]


        public List<Object> Get(string id)
        {

            using (Models.TelefoniaContext DB = new TelefoniaContext())
            {
                var lst = from d in DB.Planes
                          where d.IdPlan == id
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
        public Plane Put(Plane plane)
        {
            using (var context = new TelefoniaContext())
            {
                var PlaneP = context.Planes.FirstOrDefault(x => x.IdPlan == plane.IdPlan);
                PlaneP.Descripcion = plane.Descripcion;
                PlaneP.Renta = plane.Renta;
                PlaneP.CostoMin = plane.CostoMin;
                context.SaveChanges();
                return plane;
            }
        }










        [HttpDelete]
        public bool Delete(string id)
        {
            using (var context = new TelefoniaContext())
            {
                var PlanesDel = context.Planes.FirstOrDefault(x => x.IdPlan == id);
                context.Planes.Remove(PlanesDel);
                context.SaveChanges();
                return true;
            }

        }





        [HttpPost("Post")]
        public Plane Post(Plane plane)
        {
            using (var context = new TelefoniaContext())
            {
                context.Planes.Add(plane);
                context.SaveChanges();
                return plane;
            }
        }

    }
}


