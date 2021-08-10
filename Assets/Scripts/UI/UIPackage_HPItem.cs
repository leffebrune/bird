using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPackage_HPItem : MonoBehaviour
{
    float width;
    float prevRatio = 0.0f;
    RectTransform maskTransform;

    void Awake()
    {
        width = GetComponent<RectTransform>().sizeDelta.x;

        maskTransform = Util.Find(gameObject, "Mask").GetComponent<RectTransform>();
    }

    public void Set(float ratio)
    {
        if (prevRatio == ratio)
            return;

        maskTransform.sizeDelta = new Vector2(width * Mathf.Clamp01(ratio), maskTransform.sizeDelta.y);
        prevRatio = ratio;
    }
}
