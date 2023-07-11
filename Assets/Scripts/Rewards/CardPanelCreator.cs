using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Reward
{
    public class CardPanelCreator : MonoBehaviour
    {
        public GameObject cardPanelPrefab;
        public Button backButton;
        public Button spinButton;

        private GameObject cardPanel;
        private Button closeButton;

        private void OnDestroy() 
        {
            closeButton.onClick.RemoveListener(DestroyCard);
        }

        public void CreateCardPanel(Sprite rewardImage, int rewardAmount, RewardTypeSettings.RewardType rewardType)
        {
            cardPanel = Instantiate(cardPanelPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            cardPanel.GetComponent<CardPanelController>().UpdateCardPanel(rewardImage, rewardAmount, rewardType);

            cardPanel.transform.parent = transform;
            cardPanel.transform.localScale = new Vector3(1, 1, 1);

            RectTransform cardPanelRect = cardPanel.GetComponent<RectTransform>();
            cardPanelRect.offsetMin = new Vector2(0, 0);
            cardPanelRect.offsetMax = new Vector2(0, 0);

            closeButton = cardPanel.GetComponent<Button>();
            closeButton.onClick.AddListener(DestroyCard);
        }

        private void DestroyCard()
        {
            Destroy(cardPanel);
            backButton.interactable = true;
            spinButton.interactable = true;
        }
    }
}
