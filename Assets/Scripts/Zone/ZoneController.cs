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

        public void updateZone(int _zoneNumber)
        {

            bool setActive = _zoneNumber > 0;
            transform.gameObject.SetActive(setActive);

            if (!setActive) return;

            zoneNumberText.text = _zoneNumber.ToString();

            if(isCurrent)
            {
                handleBorderImage(_zoneNumber);
            }
        }

        private void handleBorderImage (int _zoneNumber)
        {
            WheelTypeSettings.WheelType type = WheelTypeSettings.WheelType.NORMAL;

            if (_zoneNumber % 30 == 0)
            {
                type = WheelTypeSettings.WheelType.GOLD;
            } else if (_zoneNumber % 5 == 0)
            {
                type = WheelTypeSettings.WheelType.SILVER;
            }

            WheelTypeSettings.WheelTypes wheelTypesObject = _wheelTypeSettings.GetSpriteOfWheelType(type);
            currentZoneBorderImage.color = wheelTypesObject.color;
        }
    }
}