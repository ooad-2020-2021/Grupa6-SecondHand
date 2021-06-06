using Microsoft.AspNetCore.Identity;
using SecondHand.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SecondHand.Models
{
    public class AUser

    {
        /* private readonly SecondHandContext _context;
         private  List<IdentityUser> korisnici = new List<IdentityUser>();
         AUser(SecondHandContext context)
         {
             _context = context;

         }

         public async void proba()
         {
             korisnici = _context.Users.ToList();
         }*/
        
        [Key]
        public int Id { get; set; }
        public  IdentityUser korisnik { get; set; }

        public AUser()
        {

        }
    }
}
