
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;  

//2.This is second way to implement custom validation
public class ExternalValidation:ValidationAttribute                    //inherit ValidationAttribute of System.ComponentModel.DataAnnotations
{                                                                      //and override the IsValid method.

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        //we have to convert value to value to specific type
        if((int)value<90)
        {
            return new ValidationResult("The value is out of range");
        }
        return ValidationResult.Success;
    }

}