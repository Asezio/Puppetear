using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{

    public Vector3 tweenPosition;
    public float duration;

    // Use this for initialization
    void Start()
    {
        Tweener moveTween = transform.DOMove(tweenPosition, duration);
        moveTween.SetLoops(-1, LoopType.Yoyo);
        moveTween.SetEase(Ease.InOutQuad);
    }

    private void OnCollisionEnter2D(Collision2D collObject)
    {
        if (collObject.gameObject.GetComponent<PlayerController>() != null)
        {
            collObject.gameObject.transform.parent = this.gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collObject)
    {
        if (collObject.gameObject.GetComponent<PlayerController>() != null)
        {
            collObject.gameObject.transform.parent = null;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
