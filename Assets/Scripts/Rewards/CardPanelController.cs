using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardPanelController : MonoBehaviour
{

    public Image rewardImage;
    public TextMeshProUGUI rewardAmountText;

    public void updateCardPanel (Sprite _rewardImage, int _rewardAmount)
    {
        rewardImage.sprite = _rewardImage;
        rewardAmountText.text = "x" + _rewardAmount;
    }
}
