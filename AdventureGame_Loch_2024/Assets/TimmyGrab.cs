using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimmyGrab : MonoBehaviour
{
    [SerializeField] private Image _berbImage;
    [SerializeField] private Animator _fadeAnimator;

    public void BerbDisappear()
    {
        _berbImage.enabled = false;
    }

    public void StartFade()
    {
        _fadeAnimator.SetTrigger("Fade");
    }
}
