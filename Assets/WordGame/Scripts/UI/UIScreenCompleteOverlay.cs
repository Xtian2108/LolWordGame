using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace BizzyBeeGames.WordGame
{
	public class UIScreenCompleteOverlay : UIScreen
	{
		#region Inspector Variables

		[Space]

		[SerializeField] private Image		categoryIconImage;
		[SerializeField] private Text		categoryNameText;
		[SerializeField] private Text		categoryLevelText;
		[SerializeField] private GameObject	plusOneHintText;
        [SerializeField] private ProgressRing progressRing;

        #endregion

        #region Public Methods

        public override void OnShowing(object data)
		{
			base.OnShowing(data);

			CategoryInfo categoryInfo = GameManager.Instance.GetCategoryInfo(GameManager.Instance.ActiveCategory);

			categoryIconImage.sprite	= GameSingleton.Instance.divisonActual;
			categoryNameText.text		= categoryInfo.displayName;

            

            if (GameManager.Instance.ActiveCategory == GameManager.dailyPuzzleId)
			{
				categoryLevelText.gameObject.SetActive(false);
			}
			else
			{
				categoryLevelText.gameObject.SetActive(true);
				categoryLevelText.text = "Level " + (GameManager.Instance.ActiveLevelIndex + 1).ToString();
			}

			plusOneHintText.SetActive((bool)data);

            int totalNumberOfLevels = 0;
            int totalNumberOfCompletedLevels = 0;

            for (int i = 0; i < GameManager.Instance.CategoryInfos.Count; i++)
            {
                CategoryInfo categoryInfos = GameManager.Instance.CategoryInfos[i];

                // Only include levels that are not part of the paily puzzle category
                if (categoryInfo.name != GameManager.dailyPuzzleId)
                {
                    totalNumberOfLevels += categoryInfo.levelInfos.Count;
                    totalNumberOfCompletedLevels += GameManager.Instance.GetCompletedLevelCount(categoryInfos);
                }
            }
            GameSingleton.Instance.porcentajecompletado = Mathf.RoundToInt((float)totalNumberOfCompletedLevels / (float)totalNumberOfLevels * 100f);

            Tween.ScaleX(categoryIconImage.GetComponent<RectTransform>(), Tween.TweenStyle.EaseOut, 0f, 1f, 1050f);
            Tween.ScaleY(categoryIconImage.GetComponent<RectTransform>(), Tween.TweenStyle.EaseOut, 0f, 1f, 1050f);
            StartCoroutine(Regresar());
        }

        #endregion

        public IEnumerator Regresar()
        {
            yield return new WaitForSeconds(2.0f);
            Tween.ScaleX(categoryIconImage.GetComponent<RectTransform>(), Tween.TweenStyle.EaseOut, 1f, 0f, 1050f);
            Tween.ScaleY(categoryIconImage.GetComponent<RectTransform>(), Tween.TweenStyle.EaseOut, 1f, 0f, 1050f);
        }
    }

    
}
