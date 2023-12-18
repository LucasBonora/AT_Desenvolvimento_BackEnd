using System.ComponentModel.DataAnnotations;

namespace BonosCarrosWeb.Models
{
    public class Carro
    {
        public int CarroId { get; set; }

        [Required (AllowEmptyStrings = false, ErrorMessage ="Campo modelo obrigatório")]
        [StringLength(50, MinimumLength =1,ErrorMessage ="Campo 'modelo' precisa ter entre 1 e 50 caracteres")]
        public string Modelo { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Campo ImgUri obrigatório")]
		public string ImgUri { get; set; }

		[Required(ErrorMessage = "Campo Descrição obrigatório")]
		[StringLength(100, ErrorMessage = "Campo 'Descrição' precisa ter menos de 100 caracteres")]
        public string Descricao { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Campo Preço obrigatório")]
		[Display(Name ="Preço")]
        [DataType(DataType.Currency)]
		public double Preco { get; set; }

		[Required(ErrorMessage = "Campo Está Disponível obrigatório")]
		[Display(Name = "Está disponível?")]
		public bool Disponibilidade { get; set; }

        public string DisponibilidadeFormatada => Disponibilidade ? "Sim" : "Não";

		[Required(ErrorMessage = "Campo Data Lançamento obrigatório")]
		[Display(Name = "Data de Lançamento")]
        [DisplayFormat(DataFormatString = "{0: MMMM yyyy}")]
        public DateTime DataLancamento { get; set; }

		[Display(Name = "Marca")]
		public int? MarcaId { get; set; }
		[Display(Name = "Designers")]
		public ICollection<Designer>? ListaDesigners { get; set; }
		[Display(Name = "Cep")]
		public string? Cep { get; set; }


	}
}
