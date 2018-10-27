using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteka.Validators
{
    public class IsPesel:ValidationAttribute
    {
        public string Sex { get; private set; }
        public IsPesel()
        {
            Sex = null;
        }
        public IsPesel(string sex)
        {
            Sex = sex;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string errormessage;
            string pesel;

            if (validationContext.DisplayName == null)
            {
                errormessage = "Numer PESEL jest niepoprawny";
            }
            else
            {
                errormessage = FormatErrorMessage(validationContext.DisplayName);
            }

            if(value==null)
            {
                return ValidationResult.Success;
            }

            if (value is string)
            {
                pesel = value.ToString();
            }
            else return new ValidationResult("Nie poprawny format");

            if (pesel.Length != 11) return new ValidationResult(errormessage);

            int[] weight = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int k = 0;

            for (int i = 0; i<pesel.Length ; i++)
            {
                int tmp;

                if (!Int32.TryParse(pesel[i].ToString(), out tmp))
                {
                    return new ValidationResult(errormessage);
                }

                if (i + 1 == pesel.Length)
                {
                    if ((10 - k % 10) % 10 != tmp)
                    {
                        return new ValidationResult(errormessage);
                    }
                }
                else k += tmp * weight[i];
            }

            if (Sex != null)
            {
                int n = Convert.ToInt32(pesel[9].ToString());

                switch(Sex)
                {
                    case "k":
                        {
                            if (n % 2 != 0) return new ValidationResult("Mężczyzna");
                            break;
                        }
                    case "m":
                        {
                            if (n % 2 != 1) return new ValidationResult("Kobieta");
                            break;
                        }
                    default:
                        {
                            var sexInfo = validationContext.ObjectType.GetProperty(Sex);
                            var sexValue = (string)sexInfo.GetValue(validationContext.ObjectInstance, null);

                            switch (sexValue)
                            {
                                case "k":
                                    {
                                        if (n % 2 != 0) return new ValidationResult("Mężczyzna");
                                        break;
                                    }
                                case "m":
                                    {
                                        if (n % 2 != 1) return new ValidationResult("Kobieta");
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }


            return ValidationResult.Success;
        }
    }
}