using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App1.Controllers
{
    public class APICategoryController : ApiController
    {
        // GET: api/APICategory
        public IEnumerable<BusinessProcess.fieldCategory> Get()
        {
            BusinessProcess.CategoryManager cm = new BusinessProcess.CategoryManager();
            var dd = cm.ListAll();
            return dd;
        }

        // GET: api/APICategory/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/APICategory
        public IEnumerable<string> Post([FromBody] DataModel.Category category)
        {

            if (ModelState.IsValid)
            {
                BusinessProcess.CategoryManager cm = new BusinessProcess.CategoryManager();
                string idData = Guid.NewGuid().ToString();
                category = new DataModel.Category { Id = idData, Name = category.Name };
                var data = cm.Add(category);
                return new string[] { "info", data };
            }
            else
            {
                return new string[] { "info", "" };
            }
        }

        // PUT: api/APICategory/5
        public IEnumerable<string> Update(string id, [FromBody] DataModel.Category category)
        {
            
            BusinessProcess.CategoryManager cm = new BusinessProcess.CategoryManager();
            string idData = id.ToString();
            category = new DataModel.Category { Id = idData, Name = category.Name };
            var data = cm.Update(idData,category);
            return new string[] { "info", data };
            
        }

        // DELETE: api/APICategory/5
        public string Delete(int id)
        {
            BusinessProcess.CategoryManager cm = new BusinessProcess.CategoryManager();
            string idData = id.ToString();
            var data = cm.Delete(idData);
            return data;

            
        }
    }
}
