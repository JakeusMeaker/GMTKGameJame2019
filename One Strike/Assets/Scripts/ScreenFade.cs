using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public Image blackOut;
    float fadeLength = 1.0f;

    public void FadeOut()
    {
        blackOut.canvasRenderer.SetAlpha(1.0f);
        blackOut.CrossFadeAlpha(0.0f, fadeLength, false);
    }

    public void FadeIn()
    {
        blackOut.canvasRenderer.SetAlpha(0.0f);
        blackOut.CrossFadeAlpha(0.0f, fadeLength, false);
    }
}
