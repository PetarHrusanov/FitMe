namespace FitMe.Application.Exrercising.Exercises.Commands.Common
{
    using System;
    using FitMe.Application.Common;

    public abstract class ExerciseCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Name { get; set; } = default!;

        public string Instruction { get; set; } = default!;

        public string Description { get; set; } = default!;

        public string Muscle { get; set; } = default!;

        public int Complexity { get; set; }

    }
}
