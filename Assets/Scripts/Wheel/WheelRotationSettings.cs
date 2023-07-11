using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using DG.Tweening;

namespace Wheel
{
    [CreateAssetMenu(menuName = "Wheel/Wheel Rotation Settings")]
    public class WheelRotationSettings : ScriptableObject
    {
        public float wheelRotationDuration;
        public float wheelRoundingRotationDuration;
        public float wheelRotationDelayOffset;

        public int randomRotationMinAngle;
        public int randomRotationMaxAngle;

        public int wheelSlotNumber;
        public Ease rotationEaseType;
        public Ease roundingRotationEaseType;
    }
}