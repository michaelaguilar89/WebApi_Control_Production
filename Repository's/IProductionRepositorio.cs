using WebApi_Control_Production.Models;

namespace WebApi_Control_Production.Repository_s
{
	public interface IProductionRepositorio
	{
		Task<List<Production>> GetProductionsByDate(DateTime date);
		Task<List<Production>> Get();
		Task<Production> GetProductionById(int id);

		Task<string> CreateUpdate(Production prod);

		Task<string> Delete(int id);


	}
}
