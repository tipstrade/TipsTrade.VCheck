namespace TipsTrade.VCheck.Model {
  /// <summary>Provides make and model information.</summary>
  public  interface IMakeModel {
    /// <summary>The make of the vehicle.</summary>
    string Make { get; set; }

    /// <summary>The model of the vehicle.</summary>
    string Model { get; set; }
  }
}
