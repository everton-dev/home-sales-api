﻿using System.Text.RegularExpressions;

namespace Domain.Validators
{
    public static class GuidValidator
    {
        public static bool IsGuid(string guidString)
        {
            bool isValid = false;
            if (!string.IsNullOrEmpty(guidString))
            {
                Regex isGuid =
                    new Regex(@"^({){0,1}[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}(}){0,1}$"
                        , RegexOptions.Compiled);

                if (isGuid.IsMatch(guidString))
                {
                    isValid = true;
                }
            }
            return isValid;
        }
    }
}