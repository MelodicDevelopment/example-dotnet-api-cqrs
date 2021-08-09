using System;
using dotnet_api_cqrs.data.Interfaces;

namespace dotnet_api_cqrs.services
{
	public abstract class Service : IDisposable
	{
		protected readonly IDbContext Context;
		protected readonly IDbContext ReadOnlyContext;

		public Service() { }
		public Service(IDbContext context)
		{
			Context = context;
		}
		public Service(IDbContext context = null, IDbContext readOnlyContext = null)
		{
			Context = context;
			ReadOnlyContext = readOnlyContext;
		}

		public virtual void Dispose()
		{
			if (Context != null) {
				Context.Dispose();
			}

			if (ReadOnlyContext != null) {
				ReadOnlyContext.Dispose();
			}
		}

		~Service()
		{
			Dispose();
		}
	}
}
