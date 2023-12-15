using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;

namespace KaTool
{
	public static class GetNameClass
	{
		public static string GetName<TResult>(Expression<Func<TResult>> propertyName)
		{
			var memberEx = propertyName.Body as MemberExpression;
			return memberEx.Member.Name;
		}
	}
}
