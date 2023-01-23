using WebApi_Control_Production.Models;

namespace WebApi_Control_Production.Repository_s
{
	public class ProductionRepository : IProductionRepositorio
	{
		public Task<string> CreateUpdate(Production prod)
		{
			throw new NotImplementedException();
		}

		public Task<string> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Production> GetProductionById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Production>> GetProductions(DateTime date)
		{
			throw new NotImplementedException();
		}
	}
}
