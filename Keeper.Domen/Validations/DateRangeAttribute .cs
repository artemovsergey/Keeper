namespace Keeper.Domen.Validations;

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;


public class DateRangeAttribute : ValidationAttribute, IClientModelValidator
{
    // логика на сервере
    public override bool IsValid(object value)
    {
        if (value == null)
            return false; // Обязательное поле для заполнения

        if (value is DateTime date)
        {
            DateTime today = DateTime.Today;
            DateTime minDate = today.AddDays(1); // Минимальная дата: следующий день от текущей
            DateTime maxDate = today.AddDays(15); // Максимальная дата:  15 дней вперед от текущей

            return date >= minDate && date <= maxDate;
        }

        return false;
    }

    public override string FormatErrorMessage(string name)
    {
        return $"Дата должна быть между {DateTime.Today.AddDays(1)} и {DateTime.Today.AddDays(15)}.";
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        // Получаем текущую дату
        DateTime today = DateTime.Today;
        DateTime minDate = today.AddDays(1); // Минимальная дата: следующий день от текущей
        DateTime maxDate = today.AddDays(15); // Максимальная дата:  15 дней вперед от текущей

        // Форматируем даты в формат, подходящий для атрибутов данных
        string minDateString = minDate.ToString("yyyy-MM-dd");
        string maxDateString = maxDate.ToString("yyyy-MM-dd");
        Console.WriteLine(minDateString);
        Console.WriteLine(maxDateString);

        // Добавляем атрибуты данных для валидации на стороне клиента
        context.Attributes.Add("data-val", "true");
        context.Attributes.Add("data-val-date", "Дата в правильном формате");
        
        context.Attributes.Add("data-val-range", FormatErrorMessage(context.ModelMetadata.GetDisplayName()));
        context.Attributes.Add("data-val-range-min", minDateString);
        context.Attributes.Add("data-val-range-max", maxDateString);
    }
}
