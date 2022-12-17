using FluentValidation;
using System;
using ValidatorsComparison.Api.Models;

namespace ValidatorsComparison.Api.Validators;

public class VehicleFluentValidator : AbstractValidator<Vehicle>
{
    private const string _mustBeProvidedErrorMessage = "must be provided";

    public VehicleFluentValidator()
    {
        RuleFor(m => m.Id).NotEmpty().WithMessage($"{nameof(Vehicle.Id)} {_mustBeProvidedErrorMessage}");
        RuleFor(m => m.Make).NotEmpty().WithMessage($"{nameof(Vehicle.Make)} {_mustBeProvidedErrorMessage}");
        RuleFor(m => m.Model).NotEmpty().WithMessage($"{nameof(Vehicle.Model)} {_mustBeProvidedErrorMessage}");
        
        RuleFor(m => m.RegistrationDate).LessThan(DateTime.Now).WithMessage($"{nameof(Vehicle.RegistrationDate)} must not be a future date");
        RuleFor(m => m.Description).Length(0, 500).WithMessage($"{nameof(Vehicle.Description)} must not be more than 500 characters");
        RuleFor(m => m.HorsePower).InclusiveBetween(0, 1000).WithMessage($"{nameof(Vehicle.HorsePower)} must be a number between 0 and 100");
        RuleFor(m => m.Milleage).GreaterThan(0).WithMessage($"{nameof(Vehicle.Milleage)} must be a positive number");
        
        RuleFor(m => m.IsDamaged).NotEmpty().WithMessage($"{nameof(Vehicle.IsDamaged)} {_mustBeProvidedErrorMessage}");
    }
}
