using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aspose.Cells.UI.Services
{
	public abstract class BaseAPICacheService
	{
		protected static HttpClient _httpClient = new HttpClient();

		protected V GetCached<K, V>(Dictionary<K, V> dict, K key, Func<Task<V>> refresh)
		{
			lock (dict)
			{
				if (!dict.ContainsKey(key))
				{
					var result = Task.Run(async () => await refresh()).Result;
					dict.Add(key, result);
				}

				return dict[key];
			}
		}
	}
}
