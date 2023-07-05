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

        public void updateItem(Sprite _image, int _amount)
        {
            itemRewardImage.sprite = _image;
            rewardAmountText.text = "x" + _amount;
            currentItemAmount = _amount;

            AspectRatioHelper.aspectRatioFiltterGenerator(itemRewardImage, 1.0f);

            itemRewardImage.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
        }

        public void updateAmountOnly (int _amount)
        {
            rewardAmountText.text = "x" + _amount;
            currentItemAmount = _amount;
        }
    }
}

