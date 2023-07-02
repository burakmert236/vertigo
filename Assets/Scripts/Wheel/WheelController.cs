using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Reward;

namespace Wheel
{
    public class WheelController : MonoBehaviour
    {

        public WheelTypeSettings _wheelTypeSettings;
        public WheelTypeSettings _wheelIndicatorSettings;

        public Image wheelImage;
        public Image indicatorImage;
        public TextMeshProUGUI wheelText;

        [System.Serializable]
        public struct Slot
        {
            public int slotNumber;
            public Reward.RewardTypeSettings.RewardType rewardType;
            public int rewardAmount;
        }

        [System.Serializable]
        public struct Zone
        {
            public int zoneNumber;
            public Slot[] slot;
        }

        public Zone[] zones;

        private int currentZoneNumber;
        private WheelTypeSettings.WheelType zoneType;

        // Start is called before the first frame update
        void Start()
        {
            currentZoneNumber = 1;
            zoneType = WheelTypeSettings.WheelType.NORMAL;
        }

        public void updateZoneForSuccess()
        {
            currentZoneNumber++;

            if(currentZoneNumber % 30 == 0)
            {
                zoneType = WheelTypeSettings.WheelType.GOLD;
            } else if (currentZoneNumber % 5 == 0)
            {
                zoneType = WheelTypeSettings.WheelType.SILVER;
            } else
            {
                zoneType = WheelTypeSettings.WheelType.NORMAL;
            }

            updateUIElementsForZone(zoneType);
        }

        public void updateZoneForReset()
        {
            currentZoneNumber = 1;
            zoneType = WheelTypeSettings.WheelType.NORMAL;

            updateUIElementsForZone(zoneType);
        }

        private void updateUIElementsForZone (WheelTypeSettings.WheelType type)
        {
            WheelTypeSettings.WheelTypes newWheelType = _wheelTypeSettings.GetSpriteOfWheelType(type);
            WheelTypeSettings.WheelTypes newWheelIndicator = _wheelIndicatorSettings.GetSpriteOfWheelType(type);

            wheelImage.sprite = newWheelType.sprite;
            wheelText.color = newWheelType.color;
            wheelText.text = newWheelType.text;

            indicatorImage.sprite = newWheelIndicator.sprite;
        }
    }
}
