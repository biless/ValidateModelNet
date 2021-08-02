using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace ValidateModel
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        /// <summary>
        ///  获取对象属性
        /// </summary>
        /// <param name="key">属性Key</param>
        /// <param name="type">属性类型</param>
        /// <returns></returns>
        private static string GetPropName(string key, Type type)
        {
            var keys = key.Split('.');
            var findType = type;
            var propNames = new List<string>();

            foreach (var itemKey in keys)
            {
                var findKey = itemKey;
                var indexValue = string.Empty;

                if (itemKey.EndsWith("]"))
                {
                    findKey = itemKey.Substring(0, itemKey.Length - 3);
                    indexValue = itemKey.Substring(itemKey.Length - 3, 3);
                }

                var propertyInfo = findType?.GetProperty(findKey);
                if (propertyInfo is null) continue;
                findType = itemKey.EndsWith("]")
                    ? propertyInfo.PropertyType.GetProperty("Item")?.PropertyType
                    : propertyInfo.PropertyType;

                var attribute =
                    (JsonPropertyAttribute) propertyInfo.GetCustomAttribute(typeof(JsonPropertyAttribute), true);

                var propName = itemKey;
                if (attribute is {PropertyName: { }})
                    propName = attribute.PropertyName;
                propNames.Add(propName + indexValue);
            }

            return string.Join(".", propNames);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // 如果没有问题则直接执行接下来的执行器
            if (context.ModelState.IsValid) return;

            var result = context.ModelState.Keys
                .SelectMany(key =>
                {
                    var baseType = context.ActionArguments.Values.First().GetType();
                    var propName = GetPropName(key, baseType);

                    return context.ModelState[key].Errors.Select(x => new ValidationError()
                    {
                        FieldError = x.ErrorMessage,
                        FieldName = propName
                    });
                });

            context.Result = new ObjectResult(result.FirstOrDefault());
        }
    }
}