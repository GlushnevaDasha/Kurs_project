using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace kr_avt.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("BDEntities")
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<Role> Roles { get; set; }
    }

    [Table("User")]
    public class userprofile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int userid { get; set; }
        public string username { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
    } 
}