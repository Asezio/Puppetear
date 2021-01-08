using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class PathAI : EnemyBase
{
    public Transform[] listTrans;
    private Vector3[] listPosition;
    [SerializeField]
    private float duration;
    

    private Tweener tweener;
    private Vector3 initPosition;
    // Start is called before the first frame update
    void Start()
    {
        initPosition = transform.position;
        listPosition = listTrans.Select(u => u.position).ToArray();
        Tween moveTween = transform.DOPath(listPosition, duration);
        moveTween.SetLoops(-1, LoopType.Yoyo);
        moveTween.SetEase(Ease.Linear);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position , listTrans[listTrans.Length - 1].position) < 0.1f)
        {
            StartCoroutine(FlipTrue());
        }
        else if (Vector2.Distance(transform.position , initPosition) < 0.1f)
        {
            StartCoroutine(FlipFalse());
        }
        
        
    }

    IEnumerator FlipTrue()
    {
        yield return new WaitForSeconds(waitTime);
        sr.flipX = true;
    }
    IEnumerator FlipFalse()
    {
        yield return new WaitForSeconds(waitTime);
        sr.flipX = false;
    }
}
