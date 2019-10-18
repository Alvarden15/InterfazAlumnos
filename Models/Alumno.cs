using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterfazAlumnos.Models
{
    [Table("Alumnos")]
    public class Alumno{
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nombre")]
        public String Nombre { get; set; }
        [Column("Apellido")]
        public String Apellido { get; set; }
        [Column("Edad")]
        public int Edad { get; set; }
        
    }
}