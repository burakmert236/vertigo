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

        [System.Serializable]
        public struct Slot
        {
            public int slotNumber;
            public RewardTypeSettings.RewardType rewardType;
            public int rewardAmount;
        }

        [System.Serializable]
        public struct Zone
        {
            public int zoneNumber;
            public Slot[] slot;
        }

        public Zone[] zones;

        public Transform[] slotTransforms;

        private int currentZoneNumber;
        private WheelTypeSettings.WheelType zoneType;

        public List<Slot> collectedItems;

        // Start is called before the first frame update
        void Start()
        {
            currentZoneNumber = 1;

            zoneType = WheelTypeSettings.WheelType.NORMAL;

            updateUIElementsForZone(currentZoneNumber, zoneType);

            collectedItems = new List<Slot>();

            itemsContainerScript = itemsContainer.GetComponent<CollectedItemsContainerController>();
            zoneIndicatorScript = zoneIndicator.GetComponent<ZoneIndicatorController>();

            zoneIndicatorScript.updateZones(currentZoneNumber);
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

            updateUIElementsForZone(currentZoneNumber, zoneType);
            wheelImage.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        public void updateZoneForReset()
        {
            currentZoneNumber = 1;
            zoneType = WheelTypeSettings.WheelType.NORMAL;

            updateUIElementsForZone(currentZoneNumber, zoneType);
            wheelImage.transform.rotation = Quaternion.Euler(0, 0, 0);
            collectedItems = new List<Slot>();
        }

        private void updateUIElementsForZone (int zoneNumber, WheelTypeSettings.WheelType type)
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
                Slot[] currentSlots = currentZone.slot;

                for(int i = 0; i<currentSlots.Length; i++)
                {
                    Slot currentSlot = currentSlots[i];
                    Transform currentSlotTransform = slotTransforms[i];
                    RewardTypeSettings.RewardTypeSprites rewardTypeSprite = _rewardTypeSettings.GetSpriteOfRewardType(currentSlot.rewardType);

                    WheelSlotController _wheelSlotController = currentSlotTransform.GetComponent<WheelSlotController>();
                    _wheelSlotController.updateSlotUIElements(rewardTypeSprite.sprite, currentSlot.rewardAmount);
                }
            }
        
        }

        public void handleRotationEnd(float roundedEndAngle)
        {
            int slotNum = ((int)roundedEndAngle) % 8;

            Zone currentZone = zones[currentZoneNumber - 1];
            Slot[] currentSlots = currentZone.slot;
            Slot slot = currentSlots[slotNum];

            RewardTypeSettings.RewardType rewardType = slot.rewardType;
            int rewardAmount = slot.rewardAmount;
            RewardTypeSettings.RewardTypeSprites rewardTypeSprite = _rewardTypeSettings.GetSpriteOfRewardType(rewardType);

            CardPanelCreator rootUITransformScript = rootUITransform.GetComponent<CardPanelCreator>();
            rootUITransformScript.createCardPanel(rewardTypeSprite.sprite, rewardAmount, rewardType);

            if(rewardType == RewardTypeSettings.RewardType.DEATH)
            {
                updateZoneForReset();
            }
            else
            {
                updateZoneForSuccess();
            }

            zoneIndicatorScript.updateZones(currentZoneNumber);

            addItemToCollectedList(rewardType, rewardAmount);
        }

        private void addItemToCollectedList(RewardTypeSettings.RewardType _rewardType, int _rewardAmount)
        {
            bool found = false;

            for(int i = 0; i<collectedItems.Count; i++)
            {
                Slot item = collectedItems[i];

                if (item.rewardType == _rewardType)
                {
                    item.rewardAmount += _rewardAmount;
                    found = true;
                    itemsContainerScript.updateITems(_rewardType, _rewardAmount);
                    break;
                }
            }

            if(!found)
            {
                Slot newSlot = new Slot();
                newSlot.rewardType = _rewardType;
                newSlot.rewardAmount = _rewardAmount;

                itemsContainerScript.updateITems(_rewardType, _rewardAmount);

                collectedItems.Add(newSlot);
            }
        }
    }
}
