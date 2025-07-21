using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TipsTrade.VCheck.Model;

namespace Tests {
  public class ModelTests {
    [TestCaseSource(nameof(ModelTestCases))]
    public void Json_Properties_Match(JsonProperties value) {
      Assert.That(value.IgnoreIsValid, Is.True);
      Assert.That(value.NameIsValid, Is.True);
    }

    #region Test cases
    public static IEnumerable<TestCaseData> ModelTestCases() {
      var classTypes = typeof(IMakeModel).Assembly.GetTypes()
        .Where(t => t.IsClass)
        ;

      foreach (var type in classTypes) {
        foreach (var prop in type.GetProperties()) {
          var nsProp = prop.GetCustomAttribute<Newtonsoft.Json.JsonPropertyAttribute>()?.PropertyName;
          var stProp = prop.GetCustomAttribute<System.Text.Json.Serialization.JsonPropertyNameAttribute>()?.Name;
          var nsIgnore = prop.GetCustomAttribute<Newtonsoft.Json.JsonIgnoreAttribute>() != null;
          var stIgnore = prop.GetCustomAttribute<System.Text.Json.Serialization.JsonIgnoreAttribute>() != null;


          if (nsProp != null || stProp != null || nsIgnore || stIgnore) {
            yield return new TestCaseData<JsonProperties>(new JsonProperties(nsProp, stProp, nsIgnore, stIgnore))
              .SetCategory("JsonAttributes")
              .SetName($"{type.Name}.{prop.Name}");
          }
        }
      }
    }
    #endregion

    #region Inner classes
    public record JsonProperties(string? NewtonsoftName, string? SystemTextName, bool NewtonsoftIgnore, bool SystemTextIgnore) {
      public bool IgnoreIsValid => NewtonsoftIgnore == SystemTextIgnore;
      public bool NameIsValid => NewtonsoftName == SystemTextName;
    }
    #endregion
  }
}
