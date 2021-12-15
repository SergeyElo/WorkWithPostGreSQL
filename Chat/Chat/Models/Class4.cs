using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Chat.Models
{
    public class UserDbInitializer : DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext db)
        {
          //  db.Users.Add(new User { Name = "Petrov Petr", Login = "petr", Password = "111", Email = "p@mail.ru", Phone = "+79157000901"});
          //  db.Users.Add(new User { Name = "Ivanov Ivan", Login = "ivan", Password = "222", Email = "i@mail.ru", Phone = "+79158000902" });

          //  base.Seed(db);
        }
    }


}