using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace webapi.Models
{
    public class TableEntity
    {
        [Key]
        public int TableId { get; set; }
        [Required]
        [StringLength(50)]
        public string? TableDescription { get; set; }
        public int Capacity { get; set; }
        //Relación con Restaurant
        public int RestaurantId { get; set; }
        //Relacion con locaciones
        public int LocationId { get; set; }
        //Relacion con reservas
        public ICollection<ReservationEntity>? Reservations { get; set; }



    }
}
