using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

namespace Reward
{
    public class CollectedItemController : MonoBehaviour
    {
        public Image itemRewardImage;
        public TextMeshProUGUI rewardAmountText;
        public int currentItemAmount;

        public void updateItem(Sprite _image, int _amount)
        {
            itemRewardImage.sprite = _image;
            rewardAmountText.text = "x" + _amount;
            currentItemAmount = _amount;

            AspectRatioFitter aspectRatioFitter = itemRewardImage.gameObject.AddComponent<AspectRatioFitter>();
            aspectRatioFitter.aspectMode = AspectRatioFitter.AspectMode.FitInParent;

            float nativeAspectRatio = itemRewardImage.sprite.rect.width / itemRewardImage.sprite.rect.height;
            aspectRatioFitter.aspectRatio = nativeAspectRatio;

            RectTransform rectTransform = itemRewardImage.rectTransform;
            rectTransform.anchorMin = new Vector2(0, rectTransform.anchorMin.y);
            rectTransform.anchorMax = new Vector2(1f, rectTransform.anchorMax.y);
            rectTransform.offsetMin = new Vector2(0, rectTransform.offsetMin.y);
            rectTransform.offsetMax = new Vector2(0, rectTransform.offsetMax.y);

            itemRewardImage.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
        }

        public void updateAmountOnly (int _amount)
        {
            rewardAmountText.text = "x" + _amount;
            currentItemAmount = _amount;
        }
    }
}

