﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Zadatak.Models;

namespace Zadatak.Controllers
{
    public class TablicaHitovasAPIController : ApiController
    {
        private HitoviEntities1 db = new HitoviEntities1();
        public IQueryable<TablicaHitova> GetTablicaHitovas()
        {
            return db.TablicaHitovas;
        }

        // GET: api/MuzikasAPI/5
        [ResponseType(typeof(TablicaHitova))]
        public IHttpActionResult GetTablicaHitovas(int Id)
        {
            TablicaHitova TablicaHitova = db.TablicaHitovas.Find(Id);
            if (TablicaHitova == null)
            {
                return NotFound();
            }

            return Ok(TablicaHitova);
        }

        // PUT: api/MuzikasAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTablicaHitova(int Id, TablicaHitova TablicaHitova)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (Id != TablicaHitova.Id)
            {
                return BadRequest();
            }

            db.Entry(TablicaHitova).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TablicaHitovaExists(Id))
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

        // POST: api/MuzikasAPI
        [ResponseType(typeof(TablicaHitova))]
        public IHttpActionResult PostTablicaHitova(TablicaHitova TablicaHitova)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TablicaHitovas.Add(TablicaHitova);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = TablicaHitova.Id }, TablicaHitova);
        }

        // DELETE: api/MuzikasAPI/5
        [ResponseType(typeof(TablicaHitova))]
        public IHttpActionResult DeleteTablicaHitova(int Id)
        {
            TablicaHitova TablicaHitova = db.TablicaHitovas.Find(Id);
            if (TablicaHitova == null)
            {
                return NotFound();
            }

            db.TablicaHitovas.Remove(TablicaHitova);
            db.SaveChanges();

            return Ok(TablicaHitova);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TablicaHitovaExists(int Id)
        {
            return db.TablicaHitovas.Count(e => e.Id == Id) > 0;
        }
    }
}