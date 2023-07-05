using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Reward;
using Helpers;

namespace Wheel
{
    public class WheelSlotController : MonoBehaviour
    {
        public Image slotImage;
        public TextMeshProUGUI rewardAmountText;

        public void updateSlotUIElements(Sprite newImage, int newRewardAmount)
        {
            slotImage.sprite = newImage;
            rewardAmountText.text = "x" + newRewardAmount;

            AspectRatioHelper.aspectRatioFiltterGenerator(slotImage, 1.0f);

            slotImage.transform.localScale = new Vector3(0.8f, 0.8f, 1);
        }
    }
}
