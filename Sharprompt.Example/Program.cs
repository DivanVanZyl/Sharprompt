﻿using System;
using System.ComponentModel.DataAnnotations;

using Sharprompt.Validations;

namespace Sharprompt.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            RunInputSample();

            RunSelectSample();

            RunPasswordSample();

            RunConfirmSample();

            RunMultiSelectSample();

            RunSelectEnumSample();
        }

        private static void RunInputSample()
        {
            var name = Prompt.Input<string>("What's your name?", validators: new[] { Validators.Required() });
            Console.WriteLine($"Hello, {name}!");
        }

        private static void RunSelectSample()
        {
            var city = Prompt.Select("Select your city", new[] { "Seattle", "London", "Tokyo", "New York", "Singapore", "Shanghai" }, pageSize: 3);
            Console.WriteLine($"Hello, {city}!");
        }

        private static void RunPasswordSample()
        {
            var secret = Prompt.Password("Type new password", new[] { Validators.Required(), Validators.MinLength(8) });
            Console.WriteLine("Password OK");
        }

        private static void RunConfirmSample()
        {
            var answer = Prompt.Confirm("Are you ready?");
            Console.WriteLine($"Your answer is {answer}");
        }

        private static void RunMultiSelectSample()
        {
            var options = Prompt.MultiSelect("Which cities would you like to visit?", new[] { "Seattle", "London", "Tokyo", "New York", "Singapore", "Shanghai" }, pageSize: 3);
            Console.WriteLine($"You picked {string.Join(", ", options)}");
        }

        private static void RunSelectEnumSample()
        {
            var value = Prompt.Select<MyEnum>("Select enum value");
            Console.WriteLine($"You selected {value}");
        }

        public enum MyEnum
        {
            [Display(Name = "Foo value")]
            Foo,

            [Display(Name = "Bar value")]
            Bar,

            [Display(Name = "Baz value")]
            Baz
        }
    }
}
