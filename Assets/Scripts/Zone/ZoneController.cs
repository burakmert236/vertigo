using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Wheel;

namespace Zone
{
    public class ZoneController : MonoBehaviour
    {
        public TextMeshProUGUI zoneNumberText;
        public bool isCurrent;
        public Image currentZoneBorderImage;
        public WheelTypeSettings _wheelTypeSettings;

        public void updateZone(int zoneNumber)
        {

            bool setActive = zoneNumber > 0;
            transform.gameObject.SetActive(setActive);

            if (!setActive) return;

            zoneNumberText.text = zoneNumber.ToString();

            if(isCurrent)
            {
                HandleBorderImage(zoneNumber);
            }
        }

        private void HandleBorderImage (int zoneNumber)
        {
            WheelTypeSettings.WheelType type = WheelTypeSettings.WheelType.NORMAL;

            if (zoneNumber % 30 == 0)
            {
                type = WheelTypeSettings.WheelType.GOLD;
            } else if (zoneNumber % 5 == 0)
            {
                type = WheelTypeSettings.WheelType.SILVER;
            }

            WheelTypeSettings.WheelTypes wheelTypesObject = _wheelTypeSettings.GetSpriteOfWheelType(type);
            currentZoneBorderImage.color = wheelTypesObject.color;
        }
    }
}