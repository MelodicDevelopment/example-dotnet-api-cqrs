using dotnet_api_cqrs.contracts.data;

namespace dotnet_api_cqrs.tests
{
	public abstract class TestBase
	{
		private readonly bool _noCommit;

		protected readonly IDbContext TestDbContext;

		public TestBase(bool noCommit = false)
		{
			_noCommit = noCommit;

			TestDbContext = new TestDbContext($"use-configuration-to-get-connection-string", _noCommit);
		}
	}
}