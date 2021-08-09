using System;
using System.Collections.Generic;
using System.Data;
using dotnet_api_cqrs.data;

namespace dotnet_api_cqrs.tests
{
	public class TestDbContext : DbContext
	{
		private readonly bool _noCommit;
		private bool _isQuery;

		public TestDbContext(string connectionString, bool noCommit = false) : base(connectionString)
		{
			_noCommit = noCommit;
		}

		public override IEnumerable<T> Query<T>(string query, object param = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null)
		{
			_isQuery = true;
			return base.Query<T>(query, param, commandType, transaction);
		}

		public override T QueryFirst<T>(string query, object param = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null)
		{
			_isQuery = true;
			return base.QueryFirst<T>(query, param, commandType, transaction);
		}

		public override int InsertSingle(string sql, object param = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null, int? timeout = null)
		{
			_isQuery = false;
			return base.InsertSingle(sql, param, commandType, transaction, timeout);
		}

		public override int Command(string sql, object param = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null, int? timeout = null)
		{
			_isQuery = false;
			return base.Command(sql, param, commandType, transaction, timeout);
		}

		public override T Transaction<T>(Func<IDbTransaction, T> query)
		{
			if (!_noCommit || _isQuery) {
				_isQuery = false;
				return base.Transaction(query);
			} else {
				_isQuery = false;

				using var connection = Connection;
				using var transaction = BeginTransaction();

				try {
					var result = query(transaction);
				} catch (Exception) {
					throw;
				}

				transaction.Rollback();

				return default;
			}
		}

		public override void Transaction(Action<IDbTransaction> query)
		{
			if (!_noCommit || _isQuery) {
				_isQuery = false;
				base.Transaction(query);
			} else {
				_isQuery = false;

				using var connection = Connection;
				using var transaction = BeginTransaction();

				try {
					query(transaction);
				} catch (Exception) {
					throw;
				}

				transaction.Rollback();
			}
		}

		~TestDbContext()
		{
			Dispose();
		}
	}
}
