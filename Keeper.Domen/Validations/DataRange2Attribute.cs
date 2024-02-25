using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Validations;

public class DateRange2Attribute : ValidationAttribute
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;

    public DateRange2Attribute(string startDate, string endDate)
    {
        _startDate = DateTime.Parse(startDate);
        _endDate = DateTime.Parse(endDate);
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime dateTime)
        {
            if (dateTime >= _startDate && dateTime <= _endDate)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Дата должна быть в диапазоне от " + _startDate.ToShortDateString() + " по " + _endDate.ToShortDateString());
            }
        }
        return new ValidationResult("Неверный тип данных");
    }
}
