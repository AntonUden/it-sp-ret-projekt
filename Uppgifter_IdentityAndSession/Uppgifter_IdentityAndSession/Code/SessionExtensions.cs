using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Uppgifter_IdentityAndSession.Code
{
	public static class SessionExtensions
	{
		public static void Set<T>(this ISession session, string key, T value)
		{
			session.SetString(key, JsonSerializer.Serialize(value));
		}

		public static T Get<T>(this ISession session, string key)
		{
			string data = session.GetString(key);

			return data == null ? default : JsonSerializer.Deserialize<T>(data);
		}
	}
}
