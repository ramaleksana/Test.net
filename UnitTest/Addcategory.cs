using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class Addcategory
    {
        [TestMethod]
        public void tambah_kategori()
        {
            string idnya = Guid.NewGuid().ToString();
            var kategori = new DataModel.Category { Id = idnya, Name = "Apa Aja" };
            BusinessProcess.CategoryManager cm = new BusinessProcess.CategoryManager();
            cm.Add(kategori);
        }
    }
}
