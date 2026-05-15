using Newtonsoft.Json;
using System;
using System.Globalization;

namespace TipsTrade.VCheck.Model.Converters {
  /// <summary>
  /// JSON converter that deserializes JSON boolean, integer, or numeric string values to an <see cref="int"/>.
  /// </summary>
  /// <remarks>
  /// - If the JSON token is a boolean, <c>true</c> maps to <c>1</c> and <c>false</c> maps to <c>0</c>.
  /// - If the JSON token is an integer, it is converted to <see cref="int"/>.
  /// - If the JSON token is a string, the string is parsed using <see cref="CultureInfo.InvariantCulture"/>.
  /// - A <see cref="JsonSerializationException"/> is thrown for unexpected token types or unparsable strings.
  /// </remarks>
  internal class NsBoolOrIntToIntConverter : JsonConverter<int> {
    /// <inheritdoc/>
    public override int ReadJson(JsonReader reader, Type objectType, int existingValue, bool hasExistingValue, JsonSerializer serializer) {
      if (reader.TokenType == JsonToken.Boolean) {
        return Convert.ToBoolean(reader.Value) ? 1 : 0;
      } else if (reader.TokenType == JsonToken.Integer) {
        return Convert.ToInt32(reader.Value);
      } else if (reader.TokenType == JsonToken.String && reader.Value is string strValue) {
        if (int.TryParse(strValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out int result)) {
          return result;
        }

        throw new JsonSerializationException($"Invalid string value '{strValue}' when parsing int. Value should be boolean or number.");
      }

      throw new JsonSerializationException($"Unexpected token {reader.TokenType} when parsing int. Value should be boolean or number.");
    }

    /// <inheritdoc/>
    public override void WriteJson(JsonWriter writer, int value, JsonSerializer serializer) {
      writer.WriteValue(value);
    }
  }
}
