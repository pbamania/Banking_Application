using banking_app.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking_app.DataAccess.Dtos
{
    [Table("Clients")]
    public class UserDTO: IDto
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(124)]
        public string FullName { get; set; }

        [Required]
        public int SIN { get; set; }

        [Required]
        [StringLength(12)]
        public string PasswordHash { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }


        public UserDTO(string fullName, int SIN, string passwordHash, string email, string phoneNumber)
        {
            FullName = fullName;
            this.SIN = SIN;
            PasswordHash = passwordHash;
            Email = email;
            PhoneNumber = phoneNumber;
            
        }

        public UserDTO(string fullName, int sin, string passwordHash, string email, string phoneNumber, List<AccountDTO>? accounts = null)
        {
            this.FullName = fullName;
            this.PasswordHash = passwordHash;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.SIN =sin;
        
        }

        public int getId()
        {
            return this.ID;
        }
    }
}
