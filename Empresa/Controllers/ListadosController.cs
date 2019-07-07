using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Guia10_RB140362.Models;

namespace Guia10_RB140362.Controllers
{
    public class ListadosController : ApiController
    {
        private Person db = new Person();

        // GET: api/Listados
        public IQueryable<Listado> GetListado()
        {
            return db.Listado;
        }

        // GET: api/Listados/5
        [ResponseType(typeof(Listado))]
        public IHttpActionResult GetListado(int id)
        {
            Listado listado = db.Listado.Find(id);
            if (listado == null)
            {
                return NotFound();
            }

            return Ok(listado);
        }

        // PUT: api/Listados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutListado(int id, Listado listado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listado.codigo)
            {
                return BadRequest();
            }

            db.Entry(listado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Listados
        [ResponseType(typeof(Listado))]
        public IHttpActionResult PostListado(Listado listado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Listado.Add(listado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = listado.codigo }, listado);
        }

        // DELETE: api/Listados/5
        [ResponseType(typeof(Listado))]
        public IHttpActionResult DeleteListado(int id)
        {
            Listado listado = db.Listado.Find(id);
            if (listado == null)
            {
                return NotFound();
            }

            db.Listado.Remove(listado);
            db.SaveChanges();

            return Ok(listado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListadoExists(int id)
        {
            return db.Listado.Count(e => e.codigo == id) > 0;
        }
    }
}