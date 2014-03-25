using System;
using System.Linq.Expressions;

namespace Punku
{
	/**
     * Used to extract variable name in runtime. ONLY FOR DEBUGGING!
 	 */
	public static class MemberInfoGetter
	{
		public static string GetMemberName<T> (Expression<Func<T>> memberExpression)
		{
			MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
			return expressionBody.Member.Name;
		}
	}
}
