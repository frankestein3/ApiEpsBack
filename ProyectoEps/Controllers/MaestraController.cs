using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEps.Context;
using ProyectoEps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoEps.Controllers
{
    [Route("api/[controller]")]
    public class MaestraController : Controller
    {
        private readonly AppDbContext context;
        public MaestraController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult getMaestra()
        {
            try
            {
                return Ok(context.Maestras.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}", Name = "getMaestra")]
        public ActionResult getMaestra(string id)
        {
            try
            {
                var Maestra = context.Maestras.FirstOrDefault(f => f.nmaestro == id);
                return Ok(Maestra);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Maestras p)
        {
            try
            {
                context.Maestras.Add(p);
                context.SaveChanges();
                return CreatedAtRoute("getMaestra", new { id = p.nmaestro }, p);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Maestras p)
        {
            try
            {
                if (p.nmaestro == id)
                {
                    context.Entry(p).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("getMaestra", new { id = p.nmaestro }, p);
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
