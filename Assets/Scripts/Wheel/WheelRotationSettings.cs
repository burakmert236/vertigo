using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

namespace Wheel
{
    [CreateAssetMenu(menuName = "Wheel/Wheel Rotation Settings")]
    public class WheelRotationSettings : ScriptableObject
    {
        public float wheelRotationDuration;
        public float wheelRotationDelayOffset;

        public int randomRotationMinAngle;
        public int randomRotationMaxAngle;

    }
}