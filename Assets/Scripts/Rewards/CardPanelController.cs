using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Reward;
using Helpers;

public class CardPanelController : MonoBehaviour
{

    public Image rewardImage;
    public Image cardBackground;
    public TextMeshProUGUI rewardAmountText;
    public TextMeshProUGUI warningText;

    private void Restart()
    {
        Destroy(gameObject);
    }

    public void updateCardPanel (Sprite _rewardImage, int _rewardAmount, RewardTypeSettings.RewardType _rewardType)
    {
        rewardImage.sprite = _rewardImage;

        AspectRatioHelper.aspectRatioFiltterGenerator(rewardImage, 1.0f);

        rewardImage.transform.localScale = new Vector3(0.7f, 0.7f, 1);

        rewardAmountText.text = "x" + _rewardAmount;

        if(_rewardType == RewardTypeSettings.RewardType.DEATH)
        {
            cardBackground.color = Color.red;
            warningText.text = "You got the bomb! You lost everthing!\nTap to start again";
        }
    }
}
