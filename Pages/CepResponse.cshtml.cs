using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BonosCarrosWeb.Models;
using BonosCarrosWeb.Services;
using System.Web;
using Azure;

namespace BonosCarrosWeb.Pages
{
	public class CepResponseModel : PageModel
	{
		static readonly HttpClient client = new HttpClient();
		private ICarroService _service;

		public CepResponseModel(ICarroService carroService)
		{
			_service = carroService;
		}

		public Carro carro { get; private set; }

		private const string FirstApiUrl = "https://viacep.com.br/ws/";
		private const string SecondApiUrl = "/json/";



		public static string BuildUrl(
		   string firstPath, string carroCep, string secondPath)
		{
			return $"{firstPath}{carroCep}{secondPath}";
		}
		

		public void OnGet(int id)
		{
			carro = _service.Obter(id);


			string apiUrl = BuildUrl(FirstApiUrl, carro.Cep, SecondApiUrl);

			var task = client.GetAsync(apiUrl);
			HttpResponseMessage response = task.Result;
			CepResponse cepResponse = new CepResponse();
			if (response.IsSuccessStatusCode)
			{
				Task<string> readString = response.Content.ReadAsStringAsync();
				string jsonString = readString.Result;
				cepResponse = CepResponse.FromJson(jsonString);
			}
			ViewData["CepResponse"] = cepResponse;
		}
	}
}