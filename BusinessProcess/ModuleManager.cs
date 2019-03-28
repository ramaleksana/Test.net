using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;

namespace BusinessProcess
{
    public class ModuleManager
    {
        public IEnumerable<DataModel.Module> GetAll()
        {
            var x = new SqlConnection("Server=DESKTOP-IM658HL;Database=testapp;Trusted_Connection=True;");
           IEnumerable<DataModel.Module> q =  x.Query<DataModel.Module>("SELECT TOP (1000) [idmodule],[module] FROM [tmodule]").ToList();
            //var data ;
            foreach(var item in q)
            {
                var data = new DataModel.Module
                {
                    Id = "wegfadef",
                    Name = "adefad"
                };
            }
            return q;
            //return q.AsEnumerable<string>();
           
           
        }
        public string Add(DataModel.Module Items)
        {
            try
            {
                var x = new SqlConnection("Server=DESKTOP-IM658HL;Database=testapp;Trusted_Connection=True;");
                string id = Guid.NewGuid().ToString();
                string name = Items.Name;
                x.Execute("INSERT INTO [tmodule] ([idmodule], [module]) VALUES (@Id ,@Name)", new { Id = id, Name = name });
                return "Success";
            }
            catch (Exception err)
            {
                return ("info : " + err);
            }
        }

        public string Delete(DataModel.Module Items)
        {
            try
            {
                var x = new SqlConnection("Server=DESKTOP-IM658HL;Database=testapp;Trusted_Connection=True;");
                string id = Items.Id;
                x.Execute("DELETE FROM [tmodule] WHERE [idmodule] = @Id", new { Id = id});
                return "Success";
            }
            catch (Exception err)
            {
                return ("info : " + err);
            }
        }

        public int Search(DataModel.Module Items)
        {
            try
            {
                var x = new SqlConnection("Server=DESKTOP-IM658HL;Database=testapp;Trusted_Connection=True;");
                string id = Items.Id;
                string module = Items.Name;
                IEnumerable<DataModel.Module> q =  x.Query<DataModel.Module>("SELECT * FROM [tmodule] WHERE [idmodule] = @Id", new { Id = id }).ToList();
                return q.Count();
                
            }
            catch (Exception err)
            {
                return 0;
            }
        }
        public string Update(string id,DataModel.Module Items)
        {
            try
            {
                string module = Items.Name;
                var x = new SqlConnection("Server=DESKTOP-IM658HL;Database=testapp;Trusted_Connection=True;");
                int c = Search(Items);
                if (c > 0)
                {
                    x.Execute(@"UPDATE [tmodule] SET module = @Module WHERE idmodule = @Id", new { Id = id, Module = module });
                    return "Success";
                }
                else
                {
                    return "Fail";
                }
            }catch(Exception err)
            {
                return "error : "+err;
            }
        }

    }
}