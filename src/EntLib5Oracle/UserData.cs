using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace EntLib5Oracle
{
    public class UserData
    {
        private readonly Database database;
        private readonly Mapper<User> mapper; 
        
        public UserData()
        {
            database = EnterpriseLibraryContainer.Current.GetInstance<Database>();
            mapper = new Mapper<User>(MapUser);
        }

        public IEnumerable<User> GetAll()
        {
            var reader = database.ExecuteReader("pkg_client.sp_list", null, null, null);
            return mapper.MapList(reader);
        }

        public User GetById(int id)
        {
            var reader = database.ExecuteReader("pkg_client.sp_list", id, null, null);
            return mapper.MapSingle(reader);
        }        

        private static User MapUser(IDataReader reader)
        {
            var user = new User
            {
                Id = (int)reader["id"],
                Name = (string)reader["name"],
                Email = reader["email"] as string,
                BirthDate = reader["birthdate"] as DateTime?,
                Phone = reader["phone"] as string
            };
            return user;
        }
    }
}
