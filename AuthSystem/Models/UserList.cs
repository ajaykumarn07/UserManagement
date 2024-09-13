using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace UserManagementSystem.Models
{
    public class UserList
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Please enter valid email")]
        //[RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)](([\w-]+\.)+))([a-zA-Z] [2,4][0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        public long PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; }
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }
        [Required(ErrorMessage = "PinCode is required.")]
        [DataType(DataType.PostalCode)]
        public int Pincode { get; set; }

        [Required(ErrorMessage = "UserName is required.")]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Max 20 or Min 5 Characters allowed")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Select Any one from dropdown")]
        public string Status { get; set; }
    }
}
