﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace BizzyBeeGames.WordGame
{
	public class CategoryListItem : MonoBehaviour
	{
		#region Inspector Variables

		[SerializeField] private Text	categoryText;
		[SerializeField] private Text	infoText;
		[SerializeField] private Image	iconImage;
		[SerializeField] private Image	completedImage;

		#endregion

		#region Member Variables

		private string categoryName;

		#endregion

		#region Public Methods

		public void Setup(CategoryInfo categoryInfo)
		{
			this.categoryName = categoryInfo.name;

			float numberOfLevels			= categoryInfo.levelInfos.Count;
			float numberOfCompletedLevels	= GameManager.Instance.GetCompletedLevelCount(categoryInfo);

			categoryText.text	= categoryInfo.displayName.ToUpper();
			infoText.text		= string.Format("- LEVELS: {0}/{1}", numberOfCompletedLevels, numberOfLevels);
			iconImage.sprite	= categoryInfo.icon;

			completedImage.enabled = (numberOfLevels == numberOfCompletedLevels);
		}

		public void OnClick()
		{
			// Show the category levels screen
			UIScreenController.Instance.Show(UIScreenController.CategoryLevelsScreenId, false, true, false, Tween.TweenStyle.EaseOut, null, categoryName);
            RateGame.Instance.ShowRatePopup();
		}

		#endregion
	}
}
