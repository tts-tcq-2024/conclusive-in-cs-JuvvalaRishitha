using Xunit;

public class TypeWiseAlertTests
{
    [Theory]
    [InlineData(TypeWiseAlert.CoolingType.PASSIVE_COOLING, 20, TypewiseAlert.BreachType.NORMAL)]
    [InlineData(TypeWiseAlert.CoolingType.PASSIVE_COOLING, -1, TypewiseAlert.BreachType.TOO_LOW)]
    [InlineData(TypeWiseAlert.CoolingType.PASSIVE_COOLING, 36, TypewiseAlert.BreachType.TOO_HIGH)]
    [InlineData(TypeWiseAlert.CoolingType.HI_ACTIVE_COOLING, 46, TypewiseAlert.BreachType.TOO_HIGH)]
    [InlineData(TypeWiseAlert.CoolingType.MED_ACTIVE_COOLING, 41, TypewiseAlert.BreachType.TOO_HIGH)]
    public void ClassifyTemperatureBreach_ReturnsCorrectBreachType(TypeWiseAlert.CoolingType coolingType, double temperature, TypeWiseAlert.BreachType expectedBreach)
    {
        var result = TypeWiseAlert.ClassifyTemperatureBreach(coolingType, temperature);
        Assert.Equal(expectedBreach, result);
    }

    [Fact]
    public void CheckAndAlert_SendsToController()
    {
        var batteryChar = new TypeWiseAlert.BatteryCharacter { coolingType = TypeWiseAlert.CoolingType.PASSIVE_COOLING, brand = "BrandX" };
        TypewiseAlert.CheckAndAlert(TypeWiseAlert.AlertTarget.TO_CONTROLLER, batteryChar, 36);
        // Validate console output, possibly using a custom TextWriter
    }

    [Fact]
    public void CheckAndAlert_SendsToEmail()
    {
        var batteryChar = new TypeWiseAlert.BatteryCharacter { coolingType = TypeWiseAlert.CoolingType.PASSIVE_COOLING, brand = "BrandX" };
        TypeWiseAlert.CheckAndAlert(TypewiseAlert.AlertTarget.TO_EMAIL, batteryChar, 36);
        // Validate console output, possibly using a custom TextWriter
    }
}
