using FluentAssertions;
using System;
using System.Linq;
using ValidatorsComparison.Api.Validators;
using ValidatorsComparison.Api.Models;
using Xunit;

namespace ValidatorsComparison.Api.Tests.Validators;

public class VehicleValidatorsTests
{
    private readonly VehicleFluentValidator _fluentVvalidator = new();
    private readonly VehicleCustomValidator _customValidator = new();

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Validate_WhenCalledWithInvalidId_ReturnError(string id)
    {
        var vehicle = GetVehicle();
        vehicle.Id = id;

        var _fluentVvalidatorResult = _fluentVvalidator.Validate(vehicle);
        var _customValidatorResult = _customValidator.Validate(vehicle);

        var expectedError = "Id must be provided";
        _fluentVvalidatorResult.Errors.Single().ErrorMessage.Should().Be(expectedError);
        _customValidatorResult.Errors.Single().Message.Should().Be(expectedError);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Validate_WhenCalledWithInvalidMake_ReturnError(string make)
    {
        var vehicle = GetVehicle();
        vehicle.Make = make;

        var _fluentVvalidatorResult =  _fluentVvalidator.Validate(vehicle);
        var _customValidatorResult = _customValidator.Validate(vehicle);

        var expectedError = "Make must be provided";
        _fluentVvalidatorResult.Errors.Single().ErrorMessage.Should().Be(expectedError);
        _customValidatorResult.Errors.Single().Message.Should().Be(expectedError);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Validate_WhenCalledWithInvalidModel_ReturnError(string model)
    {
        var vehicle = GetVehicle();
        vehicle.Model = model;

        var _fluentVvalidatorResult = _fluentVvalidator.Validate(vehicle);
        var _customValidatorResult = _customValidator.Validate(vehicle);

        var expectedError = "Model must be provided";
        _fluentVvalidatorResult.Errors.Single().ErrorMessage.Should().Be(expectedError);
        _customValidatorResult.Errors.Single().Message.Should().Be(expectedError);
    }

    [Fact]
    public void Validate_WhenCalledWithInvalidRegistrationDate_ReturnError()
    {
        var vehicle = GetVehicle();
        vehicle.RegistrationDate = DateTime.Now.AddDays(10);

        var _fluentVvalidatorResult = _fluentVvalidator.Validate(vehicle);
        var _customValidatorResult = _customValidator.Validate(vehicle);

        var expectedError = "RegistrationDate must not be a future date";
        _fluentVvalidatorResult.Errors.Single().ErrorMessage.Should().Be(expectedError);
        _customValidatorResult.Errors.Single().Message.Should().Be(expectedError);
    }

    [Fact]
    public void Validate_WhenCalledWithInvalidDescription_ReturnError()
    {
        var vehicle = GetVehicle();
        vehicle.Description = new string('*', 501);

        var _fluentVvalidatorResult = _fluentVvalidator.Validate(vehicle);
        var _customValidatorResult = _customValidator.Validate(vehicle);

        var expectedError = "Description must not be more than 500 characters";
        _fluentVvalidatorResult.Errors.Single().ErrorMessage.Should().Be(expectedError);
        _customValidatorResult.Errors.Single().Message.Should().Be(expectedError);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(1001)]
    public void Validate_WhenCalledWithInvalidHorsePower_ReturnError(int horsePower)
    {
        var vehicle = GetVehicle();
        vehicle.HorsePower = horsePower;

        var _fluentVvalidatorResult = _fluentVvalidator.Validate(vehicle);
        var _customValidatorResult = _customValidator.Validate(vehicle);

        var expectedError = "HorsePower must be a number between 0 and 100";
        _fluentVvalidatorResult.Errors.Single().ErrorMessage.Should().Be(expectedError);
        _customValidatorResult.Errors.Single().Message.Should().Be(expectedError);
    }

    [Fact]
    public void Validate_WhenCalledWithInvalidMilleage_ReturnError()
    {
        var vehicle = GetVehicle();
        vehicle.Milleage = -10;

        var _fluentVvalidatorResult = _fluentVvalidator.Validate(vehicle);
        var _customValidatorResult = _customValidator.Validate(vehicle);

        var expectedError = "Milleage must be a positive number";
        _fluentVvalidatorResult.Errors.Single().ErrorMessage.Should().Be(expectedError);
        _customValidatorResult.Errors.Single().Message.Should().Be(expectedError);
    }

    [Fact]
    public void Validate_WhenCalledWithInvalidIsDamaged_ReturnError()
    {
        var vehicle = GetVehicle();
        vehicle.IsDamaged = null;

        var _fluentVvalidatorResult = _fluentVvalidator.Validate(vehicle);
        var _customValidatorResult = _customValidator.Validate(vehicle);

        var expectedError = "IsDamaged must be provided";
        _fluentVvalidatorResult.Errors.Single().ErrorMessage.Should().Be(expectedError);
        _customValidatorResult.Errors.Single().Message.Should().Be(expectedError);
    }

    [Fact]
    public void Validate_WhenCalledWithValidModel_ReturnNoError()
    {
        var _fluentVvalidatorResult = _fluentVvalidator.Validate(GetVehicle());
        var _customValidatorResult = _customValidator.Validate(GetVehicle());

        _fluentVvalidatorResult.Errors.Should().BeEmpty();
        _customValidatorResult.Errors.Should().BeEmpty();
    }

    private static Vehicle GetVehicle()
        => new()
        {
            Id = "VehicleId",
            Make = "Jeep",
            Model = "Cherokee",
            RegistrationDate = DateTime.Now.AddDays(-10),
            Description = null,
            HorsePower = 200,
            Milleage = 100000,
            IsDamaged = false
        };
}
