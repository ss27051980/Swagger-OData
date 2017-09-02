using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using Test.OData.Api.Models;
using Microsoft.Data.OData;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Linq;
using System.Web.Http.Description;

namespace Test.OData.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    public class CustomersController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/Customers
        public IHttpActionResult GetCustomers(ODataQueryOptions<Customer> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            var json = File.ReadAllText(HttpContext.Current.Server.MapPath(@"~/App_Data/data.json"));
            var list = JsonConvert.DeserializeObject<List<Customer>>(json);
            return Ok<IEnumerable<Customer>>(list);
        }

        //public IQueryable<Customer> GetCustomer([FromODataUri] Guid key)
        //{
        //    var json = File.ReadAllText(HttpContext.Current.Server.MapPath(@"~/App_Data/data.json"));
        //    var list = JsonConvert.DeserializeObject<List<Customer>>(json);
        //    return list.Where(x=> x.Id == key).AsQueryable();
        //}

        // PUT: odata/Customers(5)
        public IHttpActionResult Put([FromODataUri] string key, Delta<Customer> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(customer);

            // TODO: Save the patched entity.

            // return Updated(customer);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Customers
        public IHttpActionResult Post(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(customer);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Customers(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] string key, Delta<Customer> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(customer);

            // TODO: Save the patched entity.

            // return Updated(customer);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Customers(5)
        public IHttpActionResult Delete([FromODataUri] string key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
