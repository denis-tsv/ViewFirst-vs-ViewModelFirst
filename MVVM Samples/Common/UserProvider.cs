using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class UserProvider
    {
        public List<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    FirstName = "User 1",
                    LastName = "First"
                },

                new User
                {
                    FirstName = "User 2",
                    LastName = "Second"
                },

                new User
                {
                    FirstName = "User 3",
                    LastName = "Third"
                },
            };
        }
    }
}
