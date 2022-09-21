using Newtonsoft.Json;
using System.Text;

namespace PackageDelivery.Domain.Extensions
{
    internal class DecimalFormatConverter : JsonConverter
    {
        private readonly short _decimalPlaces;

        internal DecimalFormatConverter(short decimalPlaces)
        {
            this._decimalPlaces = decimalPlaces;
        }

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(float) || objectType == typeof(float?) || objectType == typeof(double) || objectType == typeof(double?) || objectType == typeof(decimal) ? true : objectType == typeof(decimal?));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < this._decimalPlaces; i++)
            {
                stringBuilder.Append("0");
            }
            writer.WriteValue(string.Format(string.Concat("{0:0.", stringBuilder.ToString(), "}"), value));
        }
    }
}