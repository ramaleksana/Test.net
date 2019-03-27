using System;
using App1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Tambah_Module_Data()
        {
            /*Initialize Data*/
            var module = new DataModel.Module { Id = "satu", Name = "UserManagement" };

            BusinessProcess.ModuleManager mm = new BusinessProcess.ModuleManager();
            mm.Add(module);

            //var datamodule = new MModule { idmodule="ho",module="hola"};

            ///*Initialize Business Process*/
            //var test = new Tools();
            //test.test1();
        }
    }
}
