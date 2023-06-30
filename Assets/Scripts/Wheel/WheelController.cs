using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Wheel
{
    public class WheelController : MonoBehaviour
    {

        public WheelTypeSettings _wheelTypeSettings;
        public Image wheelImage;

        private int zoneNumber;
        private WheelTypeSettings.WheelType zoneType;

        // Start is called before the first frame update
        void Start()
        {
            wheelImage = gameObject.GetComponent<Image>();
            zoneNumber = 1;
            zoneType = WheelTypeSettings.WheelType.NORMAL;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void updateZoneForSuccess()
        {
            zoneNumber++;

            if(zoneNumber % 30 == 0)
            {
                zoneType = WheelTypeSettings.WheelType.GOLD;
            } else if (zoneNumber % 5 == 0)
            {
                zoneType = WheelTypeSettings.WheelType.SILVER;
            } else
            {
                zoneType = WheelTypeSettings.WheelType.NORMAL;
            }

            Debug.Log(zoneType);
            Sprite newWheelSprite = _wheelTypeSettings.GetSpriteOfWheelType(zoneType);
            // wheelImage.sprite = newWheelSprite;
        }

        public void updateZoneForReset()
        {
            zoneNumber = 1;
            zoneType = WheelTypeSettings.WheelType.NORMAL;
        }
    }
}
