using System;

namespace ValidatorsComparison.Api.Models;

public class Vehicle
{
    public string Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string Description { get; set; }
    public int HorsePower { get; set; }
    public int Milleage { get; set; }
    public bool? IsDamaged { get; set; }
}
