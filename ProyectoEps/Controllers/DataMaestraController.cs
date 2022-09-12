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
    public class DataMaestraController : Controller
    {
        private readonly AppDbContext context;
        public DataMaestraController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult getDataMaestra()
        {
            try
            {
                return Ok(context.DataMaestra.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}", Name = "getDataMaestra")]
        public ActionResult getDataMaestra(string id)
        {
            try
            {
                var DataMaestra = context.DataMaestra.FirstOrDefault(f => f.nmdato == id);
                return Ok(DataMaestra);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] DataMaestra p)
        {
            try
            {
                context.DataMaestra.Add(p);
                context.SaveChanges();
                return CreatedAtRoute("getDataMaestra", new { id = p.nmdato }, p);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] DataMaestra p)
        {
            try
            {
                if (p.nmdato == id)
                {
                    context.Entry(p).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("getDataMaestra", new { id = p.nmdato }, p);
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
