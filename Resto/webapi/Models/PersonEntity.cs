﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;
using webapi.Models;

namespace Entities
{
    public class PersonEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }
        
        [StringLength(50)]
        public string? PersonLastName { get; set; }

        [Required]
        [StringLength(50)]
        public string PersonName { get; set; }
        public int? IdentityNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }




    }
}
