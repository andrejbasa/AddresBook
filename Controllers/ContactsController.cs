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
using AddresBook.Models;

namespace AddresBook.Controllers
{
    public class ContactsController : ApiController
    {
        private LocalDBEntities db = new LocalDBEntities();

        // GET: api/Contacts
        public IQueryable<Contact> GetContact()
        {
            return db.Contact;
        }

        // GET: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult GetContact(int id)
        {
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

    // PUT: api/Contacts/5
    [HttpPut]
    [ResponseType(typeof(void))]
        public IHttpActionResult PutContact(int id, [FromBody]Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.Id)
            {
                return BadRequest();
            }

            db.Entry(contact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
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

    // POST: api/Contacts



    [ResponseType(typeof(Contact))]
    public IHttpActionResult PostContact([FromBody]Contact contact)
        {
          if (!ModelState.IsValid)
           {
               return BadRequest(ModelState);
            }






      db.Contact.Add(contact);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ContactExists(contact.Id)||ContactExistsP(contact.PhoneNum))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = contact.Id }, contact);
        }

        // DELETE: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult DeleteContact(int id)
        {
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            db.Contact.Remove(contact);
            db.SaveChanges();

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return db.Contact.Count(e => e.Id == id) > 0;
        }

    private bool ContactExistsP(String ph)
    {
      return db.Contact.Count(e => e.PhoneNum.Equals(ph)) > 0;
    }



  }
}
