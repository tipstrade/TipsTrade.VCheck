using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TipsTrade.ApiClient.Testing;
using TipsTrade.VCheck.Model;

namespace Tests {
  public class ModelTests {
    [TestCaseSource(nameof(ModelTestCases))]
    public void Json_Properties_Match(PropertyInfo property) {
      JsonAttributeAssert.IsConsistent(property);
    }

    #region Test cases
    public static IEnumerable<TestCaseData<PropertyInfo>> ModelTestCases() {
      return typeof(IMakeModel).Assembly.GetTypes()
        .Where(t => t.IsClass)
        .SelectMany(t => t.GetTestCases())
        ;
    }
    #endregion
  }
}
