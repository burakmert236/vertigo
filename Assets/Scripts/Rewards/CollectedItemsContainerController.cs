using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Wheel;
using static Reward.RewardTypeSettings;

namespace Reward
{
	public class CollectedItemsContainerController : MonoBehaviour
	{

		public RewardTypeSettings _rewardTypeSettings;
        public GameObject itemPrefab;

		public Dictionary<RewardTypeSettings.RewardType, GameObject> itemsDict;

        private void Start()
        {
            itemsDict = new Dictionary<RewardTypeSettings.RewardType, GameObject>();
        }

        public void UpdateITems(Reward.RewardTypeSettings.RewardType rewardType, int rewardAmount)
		{

            if(rewardType == Reward.RewardTypeSettings.RewardType.DEATH)
            {
                itemsDict = new Dictionary<RewardTypeSettings.RewardType, GameObject>();
                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }
            } else if(itemsDict.ContainsKey(rewardType))
            {
                GameObject existingItem = itemsDict[rewardType];
                CollectedItemController existingItemScript = existingItem.GetComponent<CollectedItemController>();
                existingItemScript.UpdateAmountOnly(existingItemScript.currentItemAmount + rewardAmount);
            } else
            {
                GameObject newItem = Instantiate(itemPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                newItem.transform.parent = transform;
                CollectedItemController newItemScript = newItem.GetComponent<CollectedItemController>();

                RewardTypeSprites rewardTypeSprite = _rewardTypeSettings.GetSpriteOfRewardType(rewardType);
                newItemScript.UpdateItem(rewardTypeSprite.sprite, rewardAmount);

                newItem.transform.localScale = new Vector3(1f, 1f, 1f);

                itemsDict.Add(rewardType, newItem);
            }
        }
	}
}

