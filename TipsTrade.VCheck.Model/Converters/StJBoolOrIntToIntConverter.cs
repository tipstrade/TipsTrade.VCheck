using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TipsTrade.VCheck.Model.Converters {
  /// <summary>
  /// JSON converter that deserializes values that may be boolean, numeric, or numeric strings into an <see cref="int"/>.
  /// </summary>
  /// <remarks>
  /// - JSON true is deserialized to 1.
  /// - JSON false is deserialized to 0.
  /// - JSON numbers are returned as their integer value.
  /// - JSON strings are parsed using <see cref="CultureInfo.InvariantCulture"/> and must represent an integer.
  /// </remarks>
  internal class StJBoolOrIntToIntConverter : JsonConverter<int> {
    /// <inheritdoc/>
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
      if (reader.TokenType == JsonTokenType.True) {
        return 1;
      } else if (reader.TokenType == JsonTokenType.False) {
        return 0;
      } else if (reader.TokenType == JsonTokenType.Number) {
        return reader.GetInt32();
      } else if (reader.TokenType == JsonTokenType.String && reader.GetString() is string strValue) {
        if (int.TryParse(strValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out int result)) {
          return result;
        }

        throw new JsonException($"Invalid string value '{strValue}' when parsing int. Value should be boolean or number.");
      }

      throw new JsonException($"Unexpected token {reader.TokenType} when parsing int. Value should be boolean or number.");
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options) {
      writer.WriteNumberValue(value);
    }
  }
}
