using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    [SerializeField] private Image fadeImage;

    private bool fadeIn = false;
    private bool fadeOut = false;
    private float alpha = 0f;

    private void OnEnable()
    {
        EventsManager.onResetState += ResetState;
    }
    private void OnDestroy()
    {
        EventsManager.onResetState -= ResetState;
    }
    private void FadeIn()
    {
        fadeIn = true;
    }
    private void FadeOut()
    {
        fadeOut = true;
    }
    private void Update()
    {
        if(fadeIn)
        {
            if(alpha < 1)
            {
                alpha += Time.deltaTime;
                fadeImage.color = new Color(0, 0, 0, alpha);
                if (alpha >= 1)
                    fadeIn = false;
            }
        }

        if (fadeOut)
        {
            if (alpha >= 0)
            {
                alpha += Time.deltaTime;
                fadeImage.color = new Color(0, 0, 0, alpha);
                if (alpha == 0)
                    fadeOut = false;
            }
        }
    }
    private void ResetState()
    {
        StartCoroutine(StartFading());
    }
    private IEnumerator StartFading()
    {
        FadeIn();
        yield return new WaitForSeconds(2f);
        FadeOut();
    }
}
