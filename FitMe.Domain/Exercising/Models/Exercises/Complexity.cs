namespace FitMe.Domain.Exercising.Models.Exercises
{
    using System;
    using FitMe.Domain.Common.Models;

    public class Complexity : Enumeration
    {
        public static readonly Complexity Low = new Complexity(1, nameof(Low));
        public static readonly Complexity Medium = new Complexity(2, nameof(Medium));
        public static readonly Complexity Hard = new Complexity(3, nameof(Hard));
        public static readonly Complexity Extreme = new Complexity(4, nameof(Extreme));

        private Complexity(int value)
            : this(value, FromValue<Complexity>(value).Name)
        {
        }

        private Complexity(int value, string name)
            : base(value, name)
        {
        }
    }
}
