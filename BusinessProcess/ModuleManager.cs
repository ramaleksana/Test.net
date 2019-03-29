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
        //public connection
        SqlConnection x = new SqlConnection("Server=DESKTOP-IM658HL;Database=testapp;Trusted_Connection=True;");

        public IEnumerable<DataModel.Module> GetAll()
        {
            //IEnumerable<DataModel.Module> q = x.Query<DataModel.Module>("SELECT TOP (1000) [idmodule] Id,[module] Name FROM [tmodule]").ToList();
            //var items = x.Query("SELECT TOP (1000) [idmodule] Id,[module] Name FROM [tmodule]").ToList();
            var q = from item in x.Query("SELECT TOP (1000) [idmodule] Id,[module] Name FROM [tmodule]")
                    select new DataModel.Module { Id = item.Id.ToString(), Name = item.Name };
            DataModel.Module[] data = new DataModel.Module[] {
                new DataModel.Module{Id="1231",Name="test"},
                new DataModel.Module{Id="131",Name="test1"},
                new DataModel.Module{Id="121",Name="test2"}
            };
            var c = from a in data
                    select new { a.Id, test = "aaa" + a.Name   };
            return q;
        }

        public string Add(DataModel.Module Items)
        {
            try
            {
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