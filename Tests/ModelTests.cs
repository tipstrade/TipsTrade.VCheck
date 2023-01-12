using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using TipsTrade.VCheck.Model;

namespace Tests {
  public class ModelTests : TestBase {
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

          Assert.NotNull(stProp, $"{type.FullName}.{prop.Name} has no JsonPropertyNameAttribute.");
          Assert.AreEqual(nsProp.PropertyName, stProp.Name, $"{type.FullName}.{prop.Name} property names are not equal.");
        }
      }
    }

  }
}
