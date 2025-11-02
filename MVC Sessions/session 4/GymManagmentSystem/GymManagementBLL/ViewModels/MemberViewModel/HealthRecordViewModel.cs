using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.ViewModels.MemberViewModel
{
    public class HealthRecordViewModel
    {
        [Required(ErrorMessage ="height is required")]
        [Range(1, 300,ErrorMessage ="between 1,300 ")]
        public decimal Height { get; set; }

        [Required(ErrorMessage = "weight is required")]
        [Range(1, 300, ErrorMessage = "between 1,300 ")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage ="blood type required")]
        [StringLength(3,ErrorMessage ="should be at most 3 chars")]
        public string BloodType { get; set; } = null!;

        public string? Note { get; set; }
    }
}
