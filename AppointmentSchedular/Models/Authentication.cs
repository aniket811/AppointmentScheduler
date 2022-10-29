namespace AppointmentSchedular.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Authentication")]
    public partial class Authentication
    {
        [Key]
        [StringLength(30, ErrorMessage = "Username must be 8-30 characters",MinimumLength =8)]
        [Required]
        public string username { get; set; }

        [StringLength(50, ErrorMessage = "Name must be 8-50 characters", MinimumLength = 8)]
        public string name { get; set; }

        [StringLength(16, ErrorMessage = "Password must be 8-16 characters", MinimumLength = 8)]
        public string passwords { get; set; }

        [StringLength(16, ErrorMessage = "Confirm Password must be 8-16 characters ", MinimumLength = 8)]
        [Compare("passwords", ErrorMessage = "Password and Confirm Password must be same")]
        public string conpassword { get; set; }
    }
}
