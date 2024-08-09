using System;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Coffee.Infrastructure.EntityFrameworkCore.Interceptors
{
	public class QueryNoLockInterceptor : IQueryExpressionInterceptor
	{
		public QueryNoLockInterceptor()
		{
		}
	}
}

