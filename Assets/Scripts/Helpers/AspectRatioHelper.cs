using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Helpers
{
    public class AspectRatioHelper
    {
        public static void AspectRatioFiltterGenerator(Image imageComponent, float scaleY)
        {
            AspectRatioFitter aspectRatioFitter = imageComponent.gameObject.GetComponent<AspectRatioFitter>();
            aspectRatioFitter.aspectMode = AspectRatioFitter.AspectMode.FitInParent;

            float nativeAspectRatio = imageComponent.sprite.rect.width / imageComponent.sprite.rect.height;
            aspectRatioFitter.aspectRatio = nativeAspectRatio;

            RectTransform rectTransform = imageComponent.rectTransform;
            rectTransform.anchorMin = new Vector2(0, rectTransform.anchorMin.y);
            rectTransform.anchorMax = new Vector2(scaleY, rectTransform.anchorMax.y);
            rectTransform.offsetMin = new Vector2(0, rectTransform.offsetMin.y);
            rectTransform.offsetMax = new Vector2(0, rectTransform.offsetMax.y);
        }
    }
}

