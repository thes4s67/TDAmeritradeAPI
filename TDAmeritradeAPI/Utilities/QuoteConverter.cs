using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TDAmeritradeAPI.Models.Price_History;
using TDAmeritradeAPI.Models.Quotes;

namespace TDAmeritradeAPI.Utilities
{
    public class QuoteConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var list = (QuoteList)value;

            writer.WriteStartObject();

            foreach (var p in list.Quotes)
            {
                writer.WritePropertyName(p.symbol);
                serializer.Serialize(writer, p);
            }

            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = serializer.Deserialize<JObject>(reader);
            var result = new QuoteList();
            result.Quotes = new List<Quote>();

            foreach (var prop in jo.Properties())
            {
                var p = prop.Value.ToObject<Quote>();
                // set name from property name
                p.symbol = prop.Name;
                result.Quotes.Add(p);
            }

            return result;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(QuoteList);
        }
    }
}
