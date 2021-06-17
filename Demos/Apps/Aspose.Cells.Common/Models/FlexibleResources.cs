using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Common.Config;
using Microsoft.AspNetCore.Hosting;

namespace Aspose.Cells.Common.Models
{
	public class FlexibleResources
	{
		private string _locale;
		protected IWebHostEnvironment Env { get; }
		public FlexibleResources(IWebHostEnvironment env, string locale)
		{
			Env = env;
			_locale = locale;
		}

		public string Locale => _locale;

		public bool ContainsKey(string key) => AppXmlResource.ContainsKey(key);

		public string this[string key]
		{
			get
			{
				if (!AppXmlResource.ContainsKey(key))
				{
					var anotherKey = ChangeFirstCharCase(key);
					if (AppXmlResource.ContainsKey(anotherKey))
						return AppXmlResource.GetResource(anotherKey);

					throw new KeyNotFoundException($"The given key '{key}' was not present in the dictionary.");
				}

				return AppXmlResource.GetResource(key);
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
			if (!AppXmlResource.TryGetValue(key, out string result))
				return default(string);

			return result;
		}

        internal string GetValueOrDefault(object p)
        {
            throw new NotImplementedException();
        }
    }
}
