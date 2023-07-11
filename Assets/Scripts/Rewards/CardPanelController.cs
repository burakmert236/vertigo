using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Reward;
using Helpers;

namespace Reward
{
    public class CardPanelController : MonoBehaviour
    {

        public Image rewardImage;
        public Image cardBackground;
        public TextMeshProUGUI rewardAmountText;
        public TextMeshProUGUI warningText;

        private const float rewardImageScaleFactor = 0.7f;

        private void Restart()
        {
            Destroy(gameObject);
        }

        public void UpdateCardPanel (Sprite rewardImageSprite, int rewardAmount, RewardTypeSettings.RewardType rewardType)
        {
            rewardImage.sprite = rewardImageSprite;

            AspectRatioHelper.AspectRatioFiltterGenerator(rewardImage, 1.0f);

            rewardImage.transform.localScale = new Vector3(rewardImageScaleFactor, rewardImageScaleFactor, 1);

            rewardAmountText.text = "x" + rewardAmount;

            if(rewardType == RewardTypeSettings.RewardType.DEATH)
            {
                cardBackground.color = Color.red;
                warningText.text = "You got the bomb! You lost everthing!\nTap to start again";
            }
        }
    }
}
