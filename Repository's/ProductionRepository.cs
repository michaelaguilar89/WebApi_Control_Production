using Microsoft.EntityFrameworkCore;
using WebApi_Control_Production.Connection;
using WebApi_Control_Production.Models;

namespace WebApi_Control_Production.Repository_s
{
	public class ProductionRepository : IProductionRepositorio
	{
		private readonly ApplicationDbContext _db;
		public ProductionRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<string> CreateUpdate(Production prod)
		{
			try
			{
				string mensaje = "";
				if (prod.id>0)
				{
					_db.productions.Update(prod);
					mensaje = "update";
				}
				else
				{
					await _db.productions.AddAsync(prod);
					mensaje = "create";
				}
				await _db.SaveChangesAsync();
				return mensaje;
			}
			catch (Exception )
			{

				string mensaje = "-500";
				return mensaje;
			}
		}

		public async Task<string> Delete(int id)
		{
			try
			{
				string mensaje = "";
				Production production = await _db.productions.FindAsync(id);
				if (production != null)
				{
					_db.Remove(production);
					await _db.SaveChangesAsync();
					mensaje = "delete";
					return mensaje;
				}
				mensaje = "El record no exixte";
				return mensaje;
			}
			catch (Exception)
			{
				string mensaje = "-500";
				return mensaje;
			}
		}
		public async Task<List<Production>> Get()
		{
			var list = await _db.productions.ToListAsync();
			return list;
		}
		public async Task<Production> GetProductionById(int id)
		{
			Production production = await _db.productions.FindAsync(id);
			return production;
		}

		public async Task<List<Production>> GetProductionsByDate(DateTime date)
		{

			List<Production> lista = await _db.productions.Where(
				x => x.fecha == date).OrderBy(x=>x.horaInicio).ToListAsync();
				return lista;
			
		}
	}
}
