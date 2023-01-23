using System.ComponentModel.DataAnnotations;

namespace WebApi_Control_Production.Models
{
	public class Production
	{
		[Key]
		public int id { get; set; }
		[Required]
		public DateTime fecha { get; set; }
		[Required]
		public string tanque { get; set; }
		[Required]
		public string productoName { get; set; }
		[Required]
		public string lote { get; set; }
		[Required]
		public decimal cantidad { get; set; }
		[Required]
		public string horaInicio { get; set; }
		[Required]
		public string nivelFinal { get; set; }
		[Required]
		public string responsable { get; set; }

		public string comentario { get; set; }



	}
}
