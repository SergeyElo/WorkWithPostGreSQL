using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PrimChat.Models
{
    public class ChatDbInitializer : DropCreateDatabaseAlways<ChatContext>
    {
        protected override void Seed(ChatContext db)
        {
            db.Users.Add(new User { mat = "Pavlov Pavel", login = "pav", password = "1", email = "pav@mail.ru", phone = "+79108007090" }); ; ;
            db.Users.Add(new User { mat = "Kotov Lev", login = "kotik", password = "2", email = "kot@mail.ru",  phone = "+79108000090" });
            db.Users.Add(new User { mat = "Soboleva", login = "sobol", password = "772tt", email = "sobol@mail.ru", phone = "+79151001010" });
            db.Users.Add(new User { mat = "Kim Lena", login = "lenchik", password = "321", email = "kim35@mail.ru", phone = "+79107770305" });
            db.Users.Add(new User { mat = "Nosova Masha ", login = "les999", password = "999", email = "koko@mail.ru", phone = "+79208009095" });
            base.Seed(db);
        }
    }
}