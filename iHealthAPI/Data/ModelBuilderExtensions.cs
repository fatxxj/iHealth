using iHealthAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Text;
using System.Security.Cryptography;
using iHealthAPI.Models;

public static class ModelBuilderExtensions 
{
    
    public static void Seed(this ModelBuilder modelBuilder)
    {
         string HashString(string str)
        {
            if (str != null)
            {
                var message = Encoding.Unicode.GetBytes(str);
                var hash = new SHA256Managed();

                var hashValue = hash.ComputeHash(message);

                return Encoding.Unicode.GetString(hashValue);
            }
            return null;
        }

        modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id=1,
                   Name = "Fat Main User",
                   Surname = "Halimi ",
                   Email = "halimifat@gmail.com",
                   Password = HashString("UserPassword "),
                   
               }
        );
    }
}

