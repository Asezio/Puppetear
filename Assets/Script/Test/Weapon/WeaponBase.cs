using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public float WeaponRange;       //检测范围
    public bool isAvailable = false;//是否已拥有
    public float cooldown;
    public float timer;
    public bool isActive;           //是否已冷却
    public LayerMask enemylayers;
    public LayerMask itemlayers;

    protected Animator anim;
    protected Transform playerTrans;
    public Transform attackPoint;

    //protected GameObject[] enemyArr;
    protected List<float> enemyList;
    protected Dictionary<float, GameObject> enemyDic;

    protected List<float> itemList;
    protected Dictionary<float, GameObject> itemDic;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


        enemyDic = new Dictionary<float, GameObject>();//初始化       
        enemyList = new List<float>();

        itemDic = new Dictionary<float, GameObject>();//初始化       
        itemList = new List<float>();

    }




    protected void DetectEnemy()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, WeaponRange, enemylayers);
        Debug.Log(hitEnemies.Length);
        if(hitEnemies.Length > 0)
        {
            for (int i = 0; i < hitEnemies.Length; i++)
            {
                float dis = Vector3.Distance(hitEnemies[i].gameObject.transform.position, playerTrans.position);
                enemyDic.Add(dis, hitEnemies[i].gameObject);
                Debug.Log(dis);
                if (!enemyList.Contains(dis))
                {
                    enemyList.Add(dis);
                }
            }
            enemyList.Sort();//对距离进行排序
            Debug.Log("***" + enemyList[0]);
            GameObject obj;
            enemyDic.TryGetValue(enemyList[0], out obj);//获取距离最近的对象
            Debug.Log(obj.name);
            enemyList.Clear();
            enemyDic.Clear();
        } 
    }

    protected void DetectItem()
    {

        Collider2D[] hitItems = Physics2D.OverlapCircleAll(attackPoint.position, WeaponRange, itemlayers);
        Debug.Log(hitItems.Length);
        if (hitItems.Length > 0)
        {
            for (int i = 0; i < hitItems.Length; i++)
            {
                float dis = Vector3.Distance(hitItems[i].gameObject.transform.position, playerTrans.position);
                itemDic.Add(dis, hitItems[i].gameObject);
                Debug.Log(dis);
                if (!itemList.Contains(dis))
                {
                    itemList.Add(dis);
                }
            }
            itemList.Sort();//对距离进行排序
            Debug.Log("***" + itemList[0]);
            GameObject obj;
            itemDic.TryGetValue(itemList[0], out obj);//获取距离最近的对象
            Debug.Log(obj.name);
            itemList.Clear();
            itemDic.Clear();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, WeaponRange);
    }
}