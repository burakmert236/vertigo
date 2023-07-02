using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

namespace Wheel
{
    [CreateAssetMenu(menuName = "Wheel/Wheel Type Settings")]
    public class WheelTypeSettings : ScriptableObject
    {
        public enum WheelType
        {
            NORMAL,
            SILVER,
            GOLD
        }

        [System.Serializable]
        public struct WheelTypes
        {
            public WheelType type;
            public Sprite sprite;
            public Color color;
            public string text;
        }

        public WheelTypes[] wheelTypes;

        public WheelTypes GetSpriteOfWheelType (WheelType type)
        {

            // default sprite for spin
            WheelTypes result = wheelTypes[0];

            foreach (WheelTypes _wheelTypeSprite in wheelTypes)
            {
                if(_wheelTypeSprite.type == type)
                {
                    return _wheelTypeSprite;
                }
            }

            return result;
        }

    }
}