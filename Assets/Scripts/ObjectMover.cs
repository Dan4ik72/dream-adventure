using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectMover : MonoBehaviour
{
    private Vector3 _startPosition;

    

    private void Awake()
    {
        _startPosition = transform.position;

        HideObject();
    }

    public void MoveToTargetPosition()
    {
        gameObject.SetActive(true);
        transform.DOMove(_startPosition, 5);
    }

    private void HideObject()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 80, transform.position.z);
        gameObject.SetActive(false);
    }
}
