﻿using System.ComponentModel.DataAnnotations;

namespace UdlaBlog.Application.DTOs
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public string CorreoElectronico { get; set; }
    }
}
