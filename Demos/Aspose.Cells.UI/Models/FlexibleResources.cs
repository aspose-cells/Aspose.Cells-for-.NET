using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Aspose.Cells.UI.Services;

namespace Aspose.Cells.UI.Models
{
	public class FlexibleResources
	{
		private string _locale;
		static ResourcesService _ResourcesService = new ResourcesService();
		HttpContext _context;
		Dictionary<string, string> _resources;
		public FlexibleResources(HttpContext context, string locale, Dictionary<string, string> resourcesFile)
		{
			_context = context;
			_locale = locale;
		
			_resources = resourcesFile.ToDictionary(k => k.Key, v => v.Value);

#if !NO_DATABASE
			var resourcesDB = _ResourcesService.GetCachedResources(locale);

			foreach (var rdb in resourcesDB)
				_resources[rdb.Key] = rdb.Value;
#endif
		}

		public string Locale => _locale;

		public Dictionary<string, string> CarbonCopy() => _resources.ToDictionary(k => k.Key, v => v.Value);

		public bool ContainsKey(string key) => _resources.ContainsKey(key);

		public string this[string key]
		{
			get
			{
				_ResourcesService.TrackKey(_context, key);
				if (!_resources.ContainsKey(key))
				{
					var anotherKey = ChangeFirstCharCase(key);
					if (_resources.ContainsKey(anotherKey))
						return _resources[anotherKey];

					throw new KeyNotFoundException($"The given key '{key}' was not present in the dictionary.");
				}

				return _resources[key];
			}
		}

		private string ChangeFirstCharCase(string key)
		{
			if (key.IsNullOrEmpty())
				return key;

			var builder = new StringBuilder();

			if (char.IsLower(key[0]))
				builder.Append(char.ToUpper(key[0]));
			else
				builder.Append(char.ToLower(key[0]));

			for (int i = 1; i < key.Length; i++)
				builder.Append(key[i]);

			return builder.ToString();
		}

		public string GetValueOrDefault(string key)
        {
			_ResourcesService.TrackKey(_context, key);

			if (!_resources.TryGetValue(key, out string result))
				return default(string);

			return result;
		}

        internal string GetValueOrDefault(object p)
        {
            throw new NotImplementedException();
        }
    }
}
