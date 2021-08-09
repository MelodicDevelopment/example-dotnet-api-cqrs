﻿using System;
using System.Collections.Generic;
using System.Data;

namespace dotnet_api_cqrs.contracts.data
{
	public interface IDbContext : IDisposable
	{
		T QueryFirst<T>(string query, object param = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null);
		IEnumerable<T> Query<T>(string query, object param = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null);
		int InsertSingle(string sql, object param = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null, int? timeout = null);
		int Command(string sql, object param = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null, int? timeout = null);
		T Transaction<T>(Func<IDbTransaction, T> query);
		void Transaction(Action<IDbTransaction> query);
	}
}
