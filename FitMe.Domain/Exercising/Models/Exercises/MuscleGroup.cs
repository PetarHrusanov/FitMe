namespace FitMe.Domain.Exercising.Models.Exercises
{
    using Common;
    using Common.Models;

    public class MuscleGroup : Enumeration
    {
        public static readonly MuscleGroup Biceps = new MuscleGroup(1, nameof(Biceps));
        public static readonly MuscleGroup Triceps = new MuscleGroup(2, nameof(Triceps));
        public static readonly MuscleGroup Shoulder = new MuscleGroup(3, nameof(Shoulder));
        public static readonly MuscleGroup LowerArm = new MuscleGroup(4, nameof(LowerArm));

        public static readonly MuscleGroup Back = new MuscleGroup(5, nameof(Back));
        public static readonly MuscleGroup Chest = new MuscleGroup(6, nameof(Chest));

        public static readonly MuscleGroup UpperLeg = new MuscleGroup(7, nameof(UpperLeg));
        public static readonly MuscleGroup LowerLeg = new MuscleGroup(8, nameof(LowerLeg));

        private MuscleGroup(int value)
            : this(value, FromValue<MuscleGroup>(value).Name)
        {
        }

        private MuscleGroup(int value, string name)
            : base(value, name)
        {
        }
    }
}
