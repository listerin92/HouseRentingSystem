﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace HouseRentingSystem.Infrastructure.Data
{
    public class Agent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 7)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;
    }
}
