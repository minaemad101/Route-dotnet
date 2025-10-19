﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.ViewModels.TrainerViewModel
{
    internal class TrainerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Photo { get; set; }
        public string Email { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string DateOfBirth { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Specialities { get; set; } = null!;
    }
}
