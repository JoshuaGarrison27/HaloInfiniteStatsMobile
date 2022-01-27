using HaloInfiniteMobileApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HaloInfiniteMobileApp.Converters;

public class GameModeJsonConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(GameMode);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        try
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject gameModeJson = JObject.Load(reader);

            var gameTypeKey = gameModeJson.Properties().FirstOrDefault()?.Name;

            return gameTypeKey switch
            {
                "zones" => gameModeJson[gameTypeKey].ToObject<Zones>(),
                "elimination" => gameModeJson[gameTypeKey].ToObject<Elimination>(),
                "flags" => gameModeJson[gameTypeKey].ToObject<Flags>(),
                _ => null,
            };
        }
        catch (Exception)
        {
            return null;
        }
    }

    public override bool CanWrite => false;

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
