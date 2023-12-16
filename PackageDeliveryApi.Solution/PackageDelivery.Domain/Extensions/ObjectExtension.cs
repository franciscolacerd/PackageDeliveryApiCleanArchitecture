using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;

namespace PackageDelivery.Domain.Extensions
{
    public static class ObjectExtension
    {
        public static short ToShort(this object obj)
        {
            int valueOrDefault = obj.ToNullableInt().GetValueOrDefault();
            if (valueOrDefault > 32767)
            {
                return short.MaxValue;
            }

            return (short)valueOrDefault;
        }

        public static int ToInt(this object obj)
        {
            return obj.ToNullableInt().GetValueOrDefault();
        }

        public static int? ToNullableInt(this object obj)
        {
            if (obj is Enum || obj is int)
            {
                return (int)obj;
            }

            int result = 0;
            if (int.TryParse(obj?.ToString(), out result))
            {
                return result;
            }

            return null;
        }

        public static decimal ToDecimal(this object obj)
        {
            return obj.ToNullableDecimal().GetValueOrDefault();
        }

        public static decimal? ToNullableDecimal(this object obj)
        {
            if (obj is null)
            {
                return null;
            }

            decimal result = default(decimal);
            string text = obj.ToString()!.Replace(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator, "");
            if (CultureInfo.CurrentCulture != null)
            {
                if (CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
                {
                    text = text.Replace(".", ",");
                }

                if (CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ".")
                {
                    text = text.Replace(",", ".");
                }
            }

            if (decimal.TryParse(text, out result))
            {
                return result;
            }

            return null;
        }

        public static DateTime ToDateTime(this object obj)
        {
            return obj.ToNullableDateTime() ?? DateTime.MinValue;
        }

        public static DateTime? ToNullableDateTime(this object obj)
        {
            if (obj is null)
            {
                return null;
            }

            if (obj.GetType().Name == "DateTime")
            {
                return (DateTime)obj;
            }

            DateTime result = DateTime.MinValue;
            DateTime.TryParse(obj.ToString(), out result);
            if (result == DateTime.MinValue)
            {
                return null;
            }

            return result;
        }

        public static string ToJson(this object obj, bool lowerCamelCase = true, short? decimalPlaces = null)
        {
            if (obj is null)
            {
                return null;
            }

            try
            {
                List<JsonConverter> list = new List<JsonConverter>();
                if (decimalPlaces.HasValue && decimalPlaces.Value > 0)
                {
                    list.Add(new DecimalFormatConverter(decimalPlaces.Value));
                }

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = (lowerCamelCase ? new CamelCasePropertyNamesContractResolver() : null),
                    Converters = list
                };
                return JsonConvert.SerializeObject(obj, Formatting.None, settings);
            }
            catch (Exception)
            {
                return obj.ToString();
            }
        }

        public static T DeserializeTo<T>(this object obj)
        {
            if (obj is null)
            {
                return default(T);
            }

            try
            {
                return obj.ToString().DeserializeTo<T>();
            }
            catch (JsonReaderException)
            {
                return default(T);
            }
        }

        public static IDictionary<string, IList<string>> ValidateDataAnnotations(this object obj)
        {
            List<ValidationResult> list = new List<ValidationResult>();
            ValidationContext validationContext = new ValidationContext(obj);
            Validator.TryValidateObject(obj, validationContext, list, validateAllProperties: true);
            Dictionary<string, IList<string>> dictionary = new Dictionary<string, IList<string>>();
            foreach (ValidationResult item in list)
            {
                string key = item.MemberNames?.First();
                if (dictionary.ContainsKey(key))
                {
                    dictionary[key].Add(item.ErrorMessage);
                    continue;
                }

                dictionary.Add(key, new string[1] { item.ErrorMessage }.ToList());
            }

            return dictionary;
        }

        public static void TrimAllProperties<T>(this T obj)
        {
            if (obj is null)
            {
                return;
            }

            IEnumerable<PropertyInfo> enumerable = from p in obj.GetType().GetProperties()
                                                   where p.PropertyType == typeof(string)
                                                   select p;
            foreach (PropertyInfo item in enumerable)
            {
                string text = (string)item.GetValue(obj, null);
                item.SetValue(obj, text?.Trim(), null);
            }
        }

        public static IDictionary<string, string> ToDictionary(this object metaToken)
        {
            if (metaToken is null)
            {
                return null;
            }

            JToken jToken = metaToken as JToken;
            if (jToken is null)
            {
                return JObject.FromObject(metaToken).ToDictionary();
            }

            if (jToken.HasValues)
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                foreach (JToken item in jToken.Children().ToList())
                {
                    IDictionary<string, string> dictionary2 = item.ToDictionary();
                    if (dictionary2 != null)
                    {
                        dictionary = dictionary.Concat(dictionary2).ToDictionary((KeyValuePair<string, string> k) => k.Key, (KeyValuePair<string, string> v) => v.Value);
                    }
                }

                return dictionary;
            }

            JValue jValue = jToken as JValue;
            if (jValue?.Value is null)
            {
                return null;
            }

            string value = ((jValue is null || jValue.Type != JTokenType.Date) ? jValue?.ToString(CultureInfo.InvariantCulture) : jValue?.ToString("o", CultureInfo.InvariantCulture));
            return new Dictionary<string, string> { { jToken.Path, value } };
        }
    }
}