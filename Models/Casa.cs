using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace InterfazAlumnos.Models{
    [Table("casa")]
    public class Casa{
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }
        [Column("Direccion")]
        public string Direccion { get; set; }
        [Column("Precio")]
        public int Precio { get; set; }
    }
    
}