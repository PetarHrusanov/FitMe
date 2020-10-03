namespace FitMe.Domain.Exercising.Models.Exercises
{
    using System;
    using System.Collections.Generic;
    using FitMe.Domain.Common;

    public class MuscleData : IInitialData
    {
        public Type EntityType => typeof(Muscle);

        public IEnumerable<object> GetData()
            => new List<Muscle>
                {
                    new Muscle("Biceps", "The biceps sometimes abbreviated to biceps brachii) is a large muscle that lies on the front of the upper arm between the shoulder and the elbow.", MuscleGroup.Biceps),
                    new Muscle("Triceps", "The triceps, also triceps brachii (Latin for three-headed muscle of the arm), is a large muscle on the back of the upper limb of many vertebrates. It consists of 3 parts: the medial, lateral, and long head. It is the muscle principally responsible for extension of the elbow joint (straightening of the arm)", MuscleGroup.Triceps),
                    new Muscle("Cuff muscles", "The most important shoulder muscles are the four rotator cuff muscles - the subscapularis, supraspinatus, infraspinatus and teres minor muscles - which connect the scapula to the humerus and provide support for the glenohumeral joint.", MuscleGroup.Shoulder),
                    new Muscle("LatisimusDorsi", "Within this group of back muscles you will find the latissimus dorsi", MuscleGroup.Back),
                    new Muscle("Lower Chest", "Two muscles form the pecs. The pectoralis major spans from the shoulder to the middle of the chest, and the pectoralis minor is on the outer ed", MuscleGroup.Chest),
                    new Muscle("Rectus Femoris", "Front part of the leg", MuscleGroup.UpperLeg),
                    new Muscle("Calf", "Lower part of the leg", MuscleGroup.LowerLeg)
                };
    }
}
