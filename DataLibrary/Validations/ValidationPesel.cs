using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Validations
{
    public class ValidationPesel : ValidationAttribute
    {
        public string errorLenght = "PESEL Number has 11 digits. Please check it.";
        public string errorPesel = "PESEL Number is incorrect.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string pesel = (string)value;

            if (!decimal.TryParse(pesel, out decimal result_status)) return new ValidationResult(errorPesel);

            if (pesel.Length == 11)
            {
                int[] weight = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
                int sum = 0;
                int controlNum = int.Parse(pesel.Substring(10, 1));

                for (int i = 0; i < weight.Length; i++)
                {
                    sum += int.Parse(pesel.Substring(i, 1)) * weight[i];
                }

                sum = sum % 10;

                if (10 - sum == controlNum) return ValidationResult.Success;

                else return new ValidationResult(errorPesel);
            }
            else return new ValidationResult(errorLenght);
        }
    }
}
