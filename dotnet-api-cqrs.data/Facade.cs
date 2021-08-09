using System;
using System.Data;
using dotnet_api_cqrs.contracts.data;

namespace dotnet_api_cqrs.data
{
	public class Facade
	{
		protected Func<IDbContext, IDbTransaction, T> Prepare<T>(IQuery<T> queryCommand)
		{
			return (context, transaction) => {
				return queryCommand.Execute(context, transaction);
			};
		}

		protected Action<IDbContext, IDbTransaction> Prepare(ICommand command)
		{
			return (context, transaction) => {
				command.Execute(context, transaction);
			};
		}
	}
}
