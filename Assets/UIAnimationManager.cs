using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class UIAnimationManager : MonoBehaviour
{
    public GameObject button;
    public Vector3 shrinkSize, enlargeSize;
    public float animationDuration;
    public Vector3 finalPosition, initialPosition, rotation;


    public Ease easing;
    public void ShrinkUI()
    {
        button.transform.DOScale(shrinkSize, animationDuration).OnComplete(() => button.transform.DOScale(Vector3.one, animationDuration));
    }

    public void EnlargeUI()
    {
        button.transform.DOScale(enlargeSize, animationDuration);
    }

    public void MoveButton()
    {

        button.transform.DOLocalMove(finalPosition, animationDuration).SetEase(easing).OnComplete(()=> ReversePositionButton());
    }

    public void ReversePositionButton()
    {
        button.transform.DOLocalMove(initialPosition, animationDuration).SetEase(easing).OnComplete(()=> MoveButton()); ;
    }

    public void ShakeButton()
    {
        //float duration, strength 1 = minimum, vibrato 10 = min, randomness = 90 min
        button.transform.DOShakePosition(5, 500, 10, 90);
    }

    public void FadeButton()
    {
        Image colorButton;
        colorButton = button.GetComponent<Image>();
        colorButton.DOFade(0, animationDuration);
    }

    public void RotateButton()
    {
        //Vector3, duration, rotate mode (Search it up)
        button.transform.DOLocalRotate(rotation, animationDuration, RotateMode.FastBeyond360);
    }
}
