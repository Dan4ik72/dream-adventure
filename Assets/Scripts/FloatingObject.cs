using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatingObject : MonoBehaviour
{
    [SerializeField] private float _strength = 7;
    [SerializeField] private int _vibratto = 0;

    private void Start()
    {
        Shake();
    }

    private void Shake()
    {
        transform.DOShakePosition(15, strength: _strength, vibrato: _vibratto).SetEase(Ease.InSine).SetLoops(-1);
        transform.DOShakeRotation(10, strength: 20, vibrato: _vibratto).SetEase(Ease.InSine).SetLoops(-1);
    }
}
