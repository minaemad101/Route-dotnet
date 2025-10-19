using GymManagementDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.ViewModels.MemberViewModel
{
    internal class MemberToUpdateViewModel
    {
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "invalid email")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "email between 5,100")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "phone is required")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "invalid phone")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "wrong phone format")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "building number is required")]
        [Range(1, 1000, ErrorMessage = "should be between 1 and 1000")]
        public int BuildingNumber { get; set; }

        [Required(ErrorMessage = "street required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "between 2,30")]
        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "city is required")]
        [StringLength(50,
            MinimumLength = 2,
            ErrorMessage = "City Must be Between 2 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City can Contain only letters and spaces")]
        public string City { get; set; } = null!;

        public string? Photo { get; set; }
    }
}
