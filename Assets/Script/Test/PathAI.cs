using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class PathAI : MonoBehaviour
{
    public Transform[] listTrans;
    [SerializeField]
    private float duration;
    private Tweener tweener;
    // Start is called before the first frame update
    void Start()
    {
        Vector3[] listPosition = listTrans.Select(u => u.position).ToArray();
        Tween moveTween = transform.DOPath(listPosition, duration);
        moveTween.SetLoops(-1, LoopType.Yoyo);
        moveTween.SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
