using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App1.Controllers
{
    public class ModuleController : ApiController
    {
        // GET: api/Module
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Module/5
        public DataModel.Module Get(string id)
        {
            var data = new DataModel.Module { Id = id, Name = "module1" };
            return data;
        }

        // POST: api/Module
        public IEnumerable<string> Post([FromBody]DataModel.Module module)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string idm = Guid.NewGuid().ToString();
                    var module1 = new DataModel.Module { Id = idm, Name = "UserManagement1" };
                    BusinessProcess.ModuleManager mm = new BusinessProcess.ModuleManager();
                    mm.Add(module);
                    return new string[] { module.Id, module.Name };
                    //return "Success";
                }
                else
                {
                    return new string[] { "Info", "Fail" };
                }
            }
            catch(Exception err)
            {
                return new string[] { "Info"+err };
            }
        }

        // PUT: api/Module/5
        public IEnumerable<string> Put(string id, DataModel.Module module)
        {
            try
            {
                BusinessProcess.ModuleManager mm = new BusinessProcess.ModuleManager();
                mm.Update(id,module);
                return new string[] { "Info" };
            }
            catch (Exception err)
            {
                return new string[] { "Info", err.ToString() };
            }
        }

        // DELETE: api/Module/5
        public IEnumerable<string> Delete([FromBody]DataModel.Module module)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BusinessProcess.ModuleManager mm = new BusinessProcess.ModuleManager();
                    mm.Delete(module);
                    return new string[] { module.Id, module.Name };
                    //return "Success";
                }
                else
                {
                    return new string[] { "Info", "Fail" };
                }
            }
            catch (Exception err)
            {
                return new string[] { "Info" + err };
            }
        }
    }
}
