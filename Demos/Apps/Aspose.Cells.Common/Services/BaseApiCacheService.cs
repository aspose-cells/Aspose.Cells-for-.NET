using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aspose.Cells.Common.Services
{
    public abstract class BaseApiCacheService
    {
        protected TV GetCached<TK, TV>(Dictionary<TK, TV> dict, TK key, Func<Task<TV>> refresh)
        {
            lock (dict)
            {
                if (dict.ContainsKey(key)) return dict[key];

                var result = Task.Run(async () => await refresh()).Result;
                dict.Add(key, result);

                return dict[key];
            }
        }
    }
}