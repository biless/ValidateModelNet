using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace ValidateModel
{
    public static class ServiceCollectionExtend
    {
        public static readonly Dictionary<string, Dictionary<string, string>> LangDic =
            new Dictionary<string, Dictionary<string, string>>();

        public static string LangHeader { get; private set; }

        public static void AddValidateMode(this IServiceCollection services,
            Action<Dictionary<string, Dictionary<string, string>>> addDic = null, string header = "Accept-Language")
        {
            LangHeader = header;
            addDic?.Invoke(LangDic);
        }
    }
}