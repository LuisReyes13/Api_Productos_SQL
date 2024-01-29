using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Productos_Server.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [MaxLength(50,ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        public string sNombre { get; set; } = null!;

        [DataType(DataType.MultilineText)]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        public string sDescripcion { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal dPrecio { get; set; }

    }

    //  Consola del Administrador de paquetes
    //  ejecutar comando siguiente.
    //  add-migration Productos
    //  una ves creado carpeta y archivo de migration y es correcto ejecutar comando siguiente.
    //  update-database
}
