using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Collections;
using System.Threading.Tasks;
using DataModel;

namespace BusinessProcess
{
    public class CategoryManager
    {
        string connectionString = @"Server=DESKTOP-5IGADTA\SQLEXPRESS;Database=testapp;Trusted_Connection=True;";
        SqlConnection connection;
        string error;

        public string Add(DataModel.Category data)
        {
            connection = new SqlConnection(connectionString);
            string sql = "INSERT INTO [category] ([idcategory],[category]) VALUES (@idcategory , @category)";
            try
            {
                connection.Execute(sql,new { idcategory = data.Id, category = data.Name});
                return "Success";
            }
            catch(Exception err)
            {
                error = err.ToString();
                return error;
            }

        }

        public string Update(string id, DataModel.Category data)
        {
            connection = new SqlConnection(connectionString);
            string sql = "UPDATE [category] SET [category] = @category WHERE [idcategory] = @idcategory";
            try
            {
                connection.Execute(sql, new { idcategory = id, category = data.Name });
                return "Success";
            }
            catch (Exception err)
            {
                error = err.ToString();
                return error;
            }
        }

        public string Delete(string id)
        {
            connection = new SqlConnection(connectionString);
            string sql = "DELETE FROM [category] WHERE [idcategory] = @idcategory";
            try
            {
                connection.Execute(sql, new { idcategory = id});
                return "Success";
            }catch(Exception err)
            {
                error = err.ToString();
                return error;
            }
        }

        public IEnumerable<DataModel.Category> List(string getId)
        {
            connection = new SqlConnection(connectionString);
            if(getId == null)
            {
                var sql = "";
            }
            else
            {
                string idc = getId.ToString();
                var sql = "";
            }
        }

        /*public List<fieldCategory> ListAll()
        {
            List<fieldCategory> lst = new List<fieldCategory>();
            string sql = "SELECT * FROM [category]";
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var listData = connection.Query<fieldCategory>(sql).ToList();
                return listData;
            }
           
        }*/




    }

    /*public class fieldCategory
    {
        public object idcategory;
        public string category;
    }*/
}