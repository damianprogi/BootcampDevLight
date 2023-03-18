using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace webapi.Models
{
    public class ClientEntity
    {
        [Key]
        public int ClientId { get; set; }
        //Relación con personas 

        [ForeignKey("PersonEntity")]
        public int PersonId { get; set; }
        public PersonEntity Person { get; set; }
        //Relacion con Reservas
        public ICollection<ReservationEntity>? Reservations { get; set; }

    }
}
