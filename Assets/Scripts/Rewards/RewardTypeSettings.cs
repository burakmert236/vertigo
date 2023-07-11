using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using static Wheel.WheelTypeSettings;

namespace Reward
{
    [CreateAssetMenu(menuName = "Reward/Reward Type Settings")]
    public class RewardTypeSettings : ScriptableObject
    {

        public enum RewardType
        {
            CASH,
            GOLD,
            CHEST_BIG_NOLIGHT,
            CHEST_BRONZE_NOLIGHT,
            CHEST_GOLD_NOLIGHT,
            CHEST_SILVER_NOLIGHT,
            CHEST_SMALL_NOLIGHT,
            CHEST_STANDARD_NOLIGHT,
            CHEST_SUPER_NOLIGHT,
            MLE_BAYONET_EASTER_TIME,
            MLE_BAYONET_SUMMER_VICE,
            TIER1_SHOTGUN,
            CONS_GRENADE_M67,
            CONS_GRENADE_M26,
            TIER2_MLE,
            TIER2_RIFLE,
            TIER3_SHOTGUN,
            TIER3_SMG,
            TIER3_SNIPER,
            ARMOR_POINTS,
            KNIFE_POINTS,
            PISTOL_POINTS,
            RIFLE_POINTS,
            SHOTGUN_POINTS,
            SMG_POINTS,
            SNIPER_POINTS,
            SUBMACHINE_POINTS,
            VEST_POINTS,
            BASEBALL_CAP_EASTER,
            AVIATOR_GLASSES_EASTER,
            HELMET_PUMPKIN,
            MOLOTOV,
            HEALTHSHOT_2_REGENERATOR,
            HEALTHSHOT_2_NEUROSTIM,
            DEATH
        }

        [System.Serializable]
        public struct RewardTypeSprites
        {
            public RewardType type;
            public Sprite sprite;
        }

        public RewardTypeSprites[] rewardTypeSprites;

        public RewardTypeSprites GetSpriteOfRewardType(RewardType type)
        {

            // default sprite for spin
            RewardTypeSprites result = rewardTypeSprites[0];

            foreach (RewardTypeSprites wheelTypeSprite in rewardTypeSprites)
            {
                if (wheelTypeSprite.type == type)
                {
                    return wheelTypeSprite;
                }
            }

            return result;
        }
    }
}