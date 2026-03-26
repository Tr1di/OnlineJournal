using AutoMapper.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MakeTopGreatAgain.Validators;

public class GreaterThanAttribute(int min) 
    : ValidationAttribute("Value must be greater than {0}")
{
    public int Min { get; } = min;

    public override bool IsValid(object? value)
    {
        if (value == null)
        {
            return true;
        }

        if (value is not int intVal)
        {
            throw new InvalidCastException("Cannot cast to int");
        }

        return intVal > Min;
    }

    public override string FormatErrorMessage(string name) =>
            string.Format(CultureInfo.CurrentCulture, ErrorMessageString, Min);
}
