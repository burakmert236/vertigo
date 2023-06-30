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
        public struct WheelTypeSprite
        {
            public WheelType type;
            public Sprite sprite;
        }

        public WheelTypeSprite[] wheelTypeSprites;

        public Sprite GetSpriteOfWheelType (WheelType type)
        {

            // default sprite for spin
            Sprite result = wheelTypeSprites[0].sprite;

            foreach (WheelTypeSprite _wheelTypeSprite in wheelTypeSprites)
            {
                if(_wheelTypeSprite.type == type)
                {
                    result = _wheelTypeSprite.sprite;
                    return result;
                }
            }

            return result;
        }

    }
}