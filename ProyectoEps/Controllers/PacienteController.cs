using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoEps.Context;
using System;
using ProyectoEps.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProyectoEps.Controllers
{
    [Route("api/[controller]")]
    public class PacienteController : Controller
    {
        private readonly AppDbContext context;
        public PacienteController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult getPaciente()
        {
            try
            {
                return Ok(context.Pacientes.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}", Name = "getPaciente")]
        public ActionResult getPaciente(int id)
        {
            try
            {
                var Paciente = context.Pacientes.FirstOrDefault(f => f.nmid == id);
                return Ok(Paciente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Pacientes p)
        {
            try
            {
                context.Pacientes.Add(p);
                context.SaveChanges();
                return CreatedAtRoute("getPaciente", new { id = p.nmid }, p);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pacientes p)
        {
            try
            {
                if (p.nmid == id)
                {
                    context.Entry(p).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("getPaciente", new { id = p.nmid }, p);
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
