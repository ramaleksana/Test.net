using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Input_Module_Data()
        {
            /*Initialize Data*/
            string idm = Guid.NewGuid().ToString();
            var module = new DataModel.Module { Id = idm , Name = "UserManagement3" };
            BusinessProcess.ModuleManager mm = new BusinessProcess.ModuleManager();
            mm.Add(module);
        }

        [TestMethod]
        public void Test_Delete_Module_Data()
        {
            /*Initialize Data*/
            string idm = "E43050CB-7443-4745-8229-931EDE7BB885";
            var module = new DataModel.Module { Id = idm, Name = "UserManagement1" };
            BusinessProcess.ModuleManager mm = new BusinessProcess.ModuleManager();
            mm.Delete(module);
        }

        [TestMethod]
        public void Test_Update_Module_Data()
        {
            /*Initialize Data*/
            string idm = "41DDD5EB-D8A8-47C7-9243-F0E22D256093";
            var module = new DataModel.Module { Id = idm, Name = "User" };
            BusinessProcess.ModuleManager mm = new BusinessProcess.ModuleManager();
            mm.Update(idm,module);
        }

        [TestMethod]
        public void Test_GetAll_Module_Data()
        {
            /*Initialize Data*/
            BusinessProcess.ModuleManager mm = new BusinessProcess.ModuleManager();
            var x = mm.GetAll().Count();
            var y = mm.GetAll();
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(mm.GetAll().Count());
        }
    }
}
