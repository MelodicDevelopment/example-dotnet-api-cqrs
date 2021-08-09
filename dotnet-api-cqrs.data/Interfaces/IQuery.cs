using System.Data;

namespace dotnet_api_cqrs.data.Interfaces
{
	public interface IQuery<T>
	{
		string Sql { get; set; }

		T Execute(IDbContext context, IDbTransaction transaction = null);
	}
}
