using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Control_Production.Models;
using WebApi_Control_Production.Repository_s;
using WebApiProduccion.Models;

namespace WebApi_Control_Production.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class ProductionController : ControllerBase
	{
		private readonly IProductionRepositorio _production;
		protected myResponse _response;
		public ProductionController(IProductionRepositorio production)
		{
			_production = production;
			_response = new myResponse();
		}
		//[HttpGet("{id}")]
		
		/*public async Task<ActionResult> GetProductionById(int id)
		{
			try
			{
				if (id!=null)
				{

				}
				Production model = await _production.GetProductionById(id);
				if (model == null)
				{
					_response.DisplayMessage = "El registro consultado no existe";
					return Ok(_response);
				}
				_response.Result = model;
				_response.DisplayMessage = "Registro Id : " + id;
				return Ok(_response);
			}
			catch (Exception e)
			{
				_response.DisplayMessage = "Error al obtener el registro Id : " + id;
				_response.ErrorMessages = new List<string> { e.ToString() };
				return BadRequest(_response);
			}
		}*/
		[HttpGet]
		//[Route("GetAll")]
		public async Task<ActionResult> GetAll()
		{
			try
			{
				var list = await _production.Get();
				_response.Result = list;
				_response.DisplayMessage = "List of Production";
				return Ok(_response);
			}
			catch (Exception e)
			{
				_response.DisplayMessage = "Error, cannot get Data";
				_response.ErrorMessages = new List<string> { e.ToString() };
				return BadRequest(_response);
			}
		}

		[HttpGet("{date}")]
		public async Task<ActionResult<IEnumerable<Production>>> GetProduction(string date)
		{
			try
			{
				DateTime newDate = Convert.ToDateTime(date);
				var list = await _production.GetProductionsByDate(newDate);
				_response.Result = list;
				_response.DisplayMessage = "List of " + date;
				return Ok(_response);
			}
			catch (Exception e)
			{

				_response.DisplayMessage = "Error, cannot get Data of : "+date;

				_response.ErrorMessages = new List<string> { e.ToString() };
				return BadRequest(_response);
			}
		}

		[HttpPost]
		public async Task<ActionResult<Production>> CreateProduction(Production model)
		{
			try
			{
				string mensaje;
				mensaje = await _production.CreateUpdate(model);
				if (mensaje== "create")
				{
					_response.Result = model;
					_response.DisplayMessage = "Registro Creado";
					return Ok(_response);
				}
				_response.DisplayMessage = "Error interno";
				return BadRequest(_response);
			}
			catch (Exception e)
			{
				_response.DisplayMessage = "Error al grabar el registro";
				_response.ErrorMessages = new List<string> { e.ToString() };
				return BadRequest(_response);
			}
		}
		[HttpPut]
		public async Task<ActionResult> EditProduction(Production model)
		{
			try
			{
				string mensaje;
				mensaje = await _production.CreateUpdate(model);
				if (mensaje == "update")
				{
					_response.DisplayMessage = "Record Actualizado";
					_response.Result = model;
					return Ok(_response);
				}
				_response.DisplayMessage = "Error interno ";
				return BadRequest(_response);
			}
			catch (Exception e)
			{
				_response.DisplayMessage = "Error al actaulizar el registro";
				_response.ErrorMessages = new List<string> { e.ToString() };
				return BadRequest(_response);
			}
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteProduction(int id)
		{
			try
			{
				string mensaje = await _production.Delete(id);
				if (mensaje== "delete")
				{
					_response.DisplayMessage = "Record Eliminando";
					return Ok(_response);
				}
				else
				{
					if (mensaje== "El record no exixte")
					{
						_response.DisplayMessage = "El record no existe";
						return BadRequest(_response);
					} 
				}
				_response.DisplayMessage = "Error Interno";
				return BadRequest(_response);
			}
			catch (Exception e)
			{
				_response.DisplayMessage = "Error al eliminar el registro";
				_response.ErrorMessages = new List<string> { e.ToString() };
				return BadRequest(_response);
			}
		}
		
	}
}
