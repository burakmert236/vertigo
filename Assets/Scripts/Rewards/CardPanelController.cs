using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Reward;

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

        AspectRatioFitter aspectRatioFitter = rewardImage.gameObject.AddComponent<AspectRatioFitter>();
        aspectRatioFitter.aspectMode = AspectRatioFitter.AspectMode.FitInParent;

        float nativeAspectRatio = rewardImage.sprite.rect.width / rewardImage.sprite.rect.height;
        aspectRatioFitter.aspectRatio = nativeAspectRatio;

        RectTransform rectTransform = rewardImage.rectTransform;
        rectTransform.anchorMin = new Vector2(0, rectTransform.anchorMin.y);
        rectTransform.anchorMax = new Vector2(1f, rectTransform.anchorMax.y);
        rectTransform.offsetMin = new Vector2(0, rectTransform.offsetMin.y);
        rectTransform.offsetMax = new Vector2(0, rectTransform.offsetMax.y);

        rewardImage.transform.localScale = new Vector3(0.7f, 0.7f, 1);

        rewardAmountText.text = "x" + _rewardAmount;

        if(_rewardType == RewardTypeSettings.RewardType.DEATH)
        {
            cardBackground.color = Color.red;
            warningText.text = "You got the bomb! You lost everthing!\nTap to start again";
        }
    }
}
