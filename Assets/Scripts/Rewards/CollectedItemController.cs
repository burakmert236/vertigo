using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using Helpers;

namespace Reward
{
    public class CollectedItemController : MonoBehaviour
    {
        public Image itemRewardImage;
        public TextMeshProUGUI rewardAmountText;
        public int currentItemAmount;

        private const float itemRewardImageLocalScaleFactor = 0.8f;

        public void UpdateItem(Sprite image, int amount)
        {
            itemRewardImage.sprite = image;
            rewardAmountText.text = "x" + amount;
            currentItemAmount = amount;

            AspectRatioHelper.AspectRatioFiltterGenerator(itemRewardImage, 1.0f);

            itemRewardImage.transform.localScale = new Vector3(itemRewardImageLocalScaleFactor, itemRewardImageLocalScaleFactor, 1f);
        }

        public void UpdateAmountOnly (int amount)
        {
            rewardAmountText.text = "x" + amount;
            currentItemAmount = amount;
        }
    }
}

