using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Reward;

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

            AspectRatioFitter aspectRatioFitter = slotImage.gameObject.GetComponent<AspectRatioFitter>();
            aspectRatioFitter.aspectMode = AspectRatioFitter.AspectMode.FitInParent;

            float nativeAspectRatio = slotImage.sprite.rect.width / slotImage.sprite.rect.height;
            aspectRatioFitter.aspectRatio = nativeAspectRatio;

            RectTransform rectTransform = slotImage.rectTransform;
            rectTransform.anchorMin = new Vector2(0, rectTransform.anchorMin.y);
            rectTransform.anchorMax = new Vector2(1f, rectTransform.anchorMax.y);
            rectTransform.offsetMin = new Vector2(0, rectTransform.offsetMin.y);
            rectTransform.offsetMax = new Vector2(0, rectTransform.offsetMax.y);

            slotImage.transform.localScale = new Vector3(0.8f, 0.8f, 1);
        }
    }
}
