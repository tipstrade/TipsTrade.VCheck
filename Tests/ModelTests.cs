using Newtonsoft.Json;
using NUnit.Framework;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using TipsTrade.VCheck.Model;

namespace Tests {
  public class ModelTests {
    [Test(Description = "JSON properties match for NewtonSoft and System.Text.Json")]
    public void TestJsonPropertyNamesMatch() {
      var classTypes = typeof(IMakeModel).Assembly.GetTypes()
        .Where(t => t.IsClass)
        ;

      foreach (var type in classTypes) {
        foreach (var prop in type.GetProperties()) {
          var nsProp = prop.GetCustomAttribute<JsonPropertyAttribute>();
          var stProp = prop.GetCustomAttribute<JsonPropertyNameAttribute>();

          if (nsProp == null) {
            continue;
          }

          Assert.That(
            nsProp == null, 
            Is.EqualTo(stProp == null),
            $"{type.FullName}.{prop.Name} has mismathed JsonProperty attributes."
            );
          Assert.That(
            nsProp.PropertyName,
            Is.EqualTo(stProp.Name),
            $"{type.FullName}.{prop.Name} property names are not equal."
            );
        }
      }
    }

  }
}
