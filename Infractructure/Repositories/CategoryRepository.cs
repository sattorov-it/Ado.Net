using System.Data;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;
using NpgsqlTypes;

namespace Infractructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public void AddCategory(Categories name)
        {
            using var conn = Database.Connection();
            conn.Open();
            var query = "insert into categories(name) values (@name)";
            var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("name", name.Name);
            cmd.ExecuteNonQuery();
        }

        public void UpdateCategory(Categories name)
        {
            using var conn = Database.Connection();
            conn.Open();
            var query = "update categories set name = @name where id = @id";
            var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("name", name.Name);
            cmd.Parameters.AddWithValue("id", name.Id);
            cmd.ExecuteNonQuery();
        }
        public void DeleteCategory(int id)
        {
            using var conn = Database.Connection();
            conn.Open();
            var query = "delete from categories where id = @id";
            var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }

        public Categories GetCategory(int id)
        {
            using var conn = Database.Connection();
            conn.Open();
            var query = "select id, name from categories where id = @id";
            var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id", id);
            var reader = cmd.ExecuteReader();
            var category = new Categories();
            while (reader.Read())
            {
                category.Id = reader.GetInt32(0);
                category.Name = reader.GetString(1);
            }
            return category;
        }

        public List<Categories> GetCategories()
        {
            using var conn = Database.Connection();
            conn.Open();
            var query = "select id, name from categories";
            var cmd = new NpgsqlCommand(query, conn);
            var reader = cmd.ExecuteReader();
            var list = new List<Categories>();
            while (reader.Read())
            {
                var category = new Categories();
                category.Id = reader.GetInt32(0);
                category.Name = reader.GetString(1);
                list.Add(category);
            }
            return list;
        }

    }
}