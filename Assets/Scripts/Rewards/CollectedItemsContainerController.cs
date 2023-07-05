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

        public void updateITems(Reward.RewardTypeSettings.RewardType _rewardType, int _rewardAmount)
		{

            if(_rewardType == Reward.RewardTypeSettings.RewardType.DEATH)
            {
                itemsDict = new Dictionary<RewardTypeSettings.RewardType, GameObject>();
                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }
            } else if(itemsDict.ContainsKey(_rewardType))
            {
                GameObject existingItem = itemsDict[_rewardType];
                CollectedItemController existingItemScript = existingItem.GetComponent<CollectedItemController>();
                existingItemScript.updateAmountOnly(existingItemScript.currentItemAmount + _rewardAmount);
            } else
            {
                GameObject newItem = Instantiate(itemPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                newItem.transform.parent = transform;
                CollectedItemController newItemScript = newItem.GetComponent<CollectedItemController>();

                RewardTypeSprites rewardTypeSprite = _rewardTypeSettings.GetSpriteOfRewardType(_rewardType);
                newItemScript.updateItem(rewardTypeSprite.sprite, _rewardAmount);

                newItem.transform.localScale = new Vector3(1f, 1f, 1f);

                itemsDict.Add(_rewardType, newItem);
            }
        }
	}
}

