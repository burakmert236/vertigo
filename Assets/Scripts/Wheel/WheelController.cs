using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Reward;
using Zone;

namespace Wheel
{
    public class WheelController : MonoBehaviour
    {

        [System.Serializable]
        public struct WheelSlot
        {
            public int slotNumber;
            public RewardTypeSettings.RewardType rewardType;
            public int rewardAmount;
        }

        [System.Serializable]
        public struct Zone
        {
            public int zoneNumber;
            public WheelSlot[] slot;
        }

        public WheelTypeSettings _wheelTypeSettings;
        public WheelTypeSettings _wheelIndicatorSettings;
        public RewardTypeSettings _rewardTypeSettings;

        public Image wheelImage;
        public Image indicatorImage;
        public TextMeshProUGUI wheelText;

        public Transform rootUITransform;
        public Transform itemsContainer;
        public Transform zoneIndicator;

        private CollectedItemsContainerController itemsContainerScript;
        private ZoneIndicatorController zoneIndicatorScript;

        public Zone[] zones;

        public Transform[] slotTransforms;

        private int currentZoneNumber;
        private WheelTypeSettings.WheelType zoneType;

        public List<WheelSlot> collectedItems;

        // Start is called before the first frame update
        void Start()
        {
            currentZoneNumber = 1;

            zoneType = WheelTypeSettings.WheelType.NORMAL;

            UpdateUIElementsForZone(currentZoneNumber, zoneType);

            collectedItems = new List<WheelSlot>();

            itemsContainerScript = itemsContainer.GetComponent<CollectedItemsContainerController>();
            zoneIndicatorScript = zoneIndicator.GetComponent<ZoneIndicatorController>();

            zoneIndicatorScript.UpdateZones(currentZoneNumber);
        }

        public void UpdateZoneForSuccess()
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

            UpdateUIElementsForZone(currentZoneNumber, zoneType);
            wheelImage.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        public void UpdateZoneForReset()
        {
            currentZoneNumber = 1;
            zoneType = WheelTypeSettings.WheelType.NORMAL;

            UpdateUIElementsForZone(currentZoneNumber, zoneType);
            wheelImage.transform.rotation = Quaternion.Euler(0, 0, 0);
            collectedItems = new List<WheelSlot>();
        }

        private void UpdateUIElementsForZone (int zoneNumber, WheelTypeSettings.WheelType type)
        {
            WheelTypeSettings.WheelTypes newWheelType = _wheelTypeSettings.GetSpriteOfWheelType(type);
            WheelTypeSettings.WheelTypes newWheelIndicator = _wheelIndicatorSettings.GetSpriteOfWheelType(type);

            wheelImage.sprite = newWheelType.sprite;
            wheelText.color = newWheelType.color;
            wheelText.text = newWheelType.text;

            indicatorImage.sprite = newWheelIndicator.sprite;

            if(zones.Length >= zoneNumber)
            {
                Zone currentZone = zones[zoneNumber - 1];
                WheelSlot[] currentSlots = currentZone.slot;

                for(int i = 0; i<currentSlots.Length; i++)
                {
                    WheelSlot currentSlot = currentSlots[i];
                    Transform currentSlotTransform = slotTransforms[i];
                    RewardTypeSettings.RewardTypeSprites rewardTypeSprite = _rewardTypeSettings.GetSpriteOfRewardType(currentSlot.rewardType);

                    WheelSlotController _wheelSlotController = currentSlotTransform.GetComponent<WheelSlotController>();
                    _wheelSlotController.UpdateSlotUIElements(rewardTypeSprite.sprite, currentSlot.rewardAmount);
                }
            }
        
        }

        public void HandleRotationEnd(float roundedEndAngle)
        {
            int slotNum = ((int)roundedEndAngle) % 8;

            Zone currentZone = zones[currentZoneNumber - 1];
            WheelSlot[] currentSlots = currentZone.slot;
            WheelSlot slot = currentSlots[slotNum];

            RewardTypeSettings.RewardType rewardType = slot.rewardType;
            int rewardAmount = slot.rewardAmount;
            RewardTypeSettings.RewardTypeSprites rewardTypeSprite = _rewardTypeSettings.GetSpriteOfRewardType(rewardType);

            CardPanelCreator rootUITransformScript = rootUITransform.GetComponent<CardPanelCreator>();
            rootUITransformScript.CreateCardPanel(rewardTypeSprite.sprite, rewardAmount, rewardType);

            if(rewardType == RewardTypeSettings.RewardType.DEATH)
            {
                UpdateZoneForReset();
            }
            else
            {
                UpdateZoneForSuccess();
            }

            zoneIndicatorScript.UpdateZones(currentZoneNumber);

            AddItemToCollectedList(rewardType, rewardAmount);
        }

        private void AddItemToCollectedList(RewardTypeSettings.RewardType rewardType, int rewardAmount)
        {
            bool found = false;

            for(int i = 0; i<collectedItems.Count; i++)
            {
                WheelSlot item = collectedItems[i];

                if (item.rewardType == rewardType)
                {
                    item.rewardAmount += rewardAmount;
                    found = true;
                    itemsContainerScript.UpdateITems(rewardType, rewardAmount);
                    break;
                }
            }

            if(!found)
            {
                WheelSlot newSlot = new WheelSlot();
                newSlot.rewardType = rewardType;
                newSlot.rewardAmount = rewardAmount;

                itemsContainerScript.UpdateITems(rewardType, rewardAmount);

                collectedItems.Add(newSlot);
            }
        }
    }
}
