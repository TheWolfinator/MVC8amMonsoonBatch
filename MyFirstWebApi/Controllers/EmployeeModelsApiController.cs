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
using MyFirstWebApi.Models;

namespace MyFirstWebApi.Controllers
{
    public class EmployeeModelsApiController : ApiController
    {
        private arvindEntities db = new arvindEntities();

        // GET: api/EmployeeModelsApi
        public IQueryable<EmployeeModel> GetEmployeeModels()
        {
            return db.EmployeeModels;
        }

        // GET: api/EmployeeModelsApi/5
        [ResponseType(typeof(EmployeeModel))]
        public IHttpActionResult GetEmployeeModel(int id)
        {
            EmployeeModel employeeModel = db.EmployeeModels.Find(id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            return Ok(employeeModel);
        }

        // PUT: api/EmployeeModelsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployeeModel(int id, EmployeeModel employeeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeModel.EmpId)
            {
                return BadRequest();
            }

            db.Entry(employeeModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeModelExists(id))
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

        // POST: api/EmployeeModelsApi
        [ResponseType(typeof(EmployeeModel))]
        public IHttpActionResult PostEmployeeModel(EmployeeModel employeeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeModels.Add(employeeModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employeeModel.EmpId }, employeeModel);
        }

        // DELETE: api/EmployeeModelsApi/5
        [ResponseType(typeof(EmployeeModel))]
        public IHttpActionResult DeleteEmployeeModel(int id)
        {
            EmployeeModel employeeModel = db.EmployeeModels.Find(id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            db.EmployeeModels.Remove(employeeModel);
            db.SaveChanges();

            return Ok(employeeModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeModelExists(int id)
        {
            return db.EmployeeModels.Count(e => e.EmpId == id) > 0;
        }
    }
}