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
    public class PersonaController : Controller
    {
        private readonly AppDbContext context;
        public PersonaController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult getPersonas()
        {
            try
            {
                return Ok(context.Personas.ToList());
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}", Name ="getPersona")]
        public ActionResult getPersona(string id)
        {
            try
            {
                var persona = context.Personas.FirstOrDefault(f => f.cddocumento == id);
                return Ok(persona);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]Personas p)
        {
            try
            {
                context.Personas.Add(p);
                context.SaveChanges();
                return CreatedAtRoute("getPersona", new { id = p.cddocumento }, p);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Personas p)
        {
            try
            {
                if (p.cddocumento == id)
                {
                    context.Entry(p).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("getPersona", new { id = p.cddocumento }, p);
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
