﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using FluentValidation;

namespace Application.CustomValidators
{
    public static class ListValidator
    {
        public static IRuleBuilderOptions<T, TElement> IsValidListMember<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder, List<string> list)
        {
            return ruleBuilder.Must((TElement value) =>
            {
                return value != null && typeof(TElement) == typeof(string) && !String.IsNullOrWhiteSpace(value.ToString()) ? list.Contains(value.ToString()) : true;
            }).WithMessage("{PropertyName} field should only contain one of the following values (" + String.Join(',', list.ToArray()) + ")");
        }
    }
}
