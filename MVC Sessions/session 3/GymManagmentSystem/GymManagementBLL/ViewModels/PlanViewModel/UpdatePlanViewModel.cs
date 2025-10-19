using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.ViewModels.PlanViewModel
{
    internal class UpdatePlanViewModel
    {
       
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Description Is Required")]
        [StringLength(200,
            MinimumLength = 5,
            ErrorMessage = "Name Must be Between 5 and 200 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can Contain only letters and spaces")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Duration Is Required")]
        [Range(1,356,ErrorMessage ="Duration between 1 and 356 days")]
        public int DurationDays { get; set; }

        [Required(ErrorMessage = "Price Is Required")]
        [Range(0.1,10000,ErrorMessage ="between 0.1 and 10k")]
        public decimal Price { get; set; }
    }
}
