using System.Data;

namespace dotnet_api_cqrs.contracts.data
{
	public interface IQuery<T>
	{
		string Sql { get; set; }

		T Execute(IDbContext context, IDbTransaction transaction = null);
	}
}
