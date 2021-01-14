using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public float WeaponRange;       //检测范围
    public bool isAvailable = false;//是否已拥有
    public float cooldown;
    public float timer;
    //protected bool canInteract= false;
    public LayerMask enemylayers;
    public LayerMask itemlayers;

    protected SpriteRenderer playerSr;
    protected Animator anim;
    protected Transform playerTrans;
    public Transform attackPoint;

    protected GameObject test;


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
        playerSr = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();


        test = GameObject.Find("FirstAttached");

        enemyDic = new Dictionary<float, GameObject>();//初始化       
        enemyList = new List<float>();

        itemDic = new Dictionary<float, GameObject>();//初始化       
        itemList = new List<float>();

    }




    protected void DetectEnemy()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, WeaponRange, enemylayers);
        //Debug.Log(hitEnemies.Length);
        if (hitEnemies.Length > 0)
        {
            for (int i = 0; i < hitEnemies.Length; i++)
            {
                float dis = Vector3.Distance(hitEnemies[i].gameObject.transform.position, playerTrans.position);
                enemyDic.Add(dis, hitEnemies[i].gameObject);
                //Debug.Log(dis);
                if (!enemyList.Contains(dis))
                {
                    enemyList.Add(dis);
                }
            }
            enemyList.Sort();//对距离进行排序
            //Debug.Log("***" + enemyList[0]);
            GameObject obj;
            enemyDic.TryGetValue(enemyList[0], out obj);//获取距离最近的对象
            //Debug.Log(obj.name);
            //若检测物体发生改变，上一检测目标取消描边
            if (test != obj)
            {
                test.GetComponent<Interactable>().ExitMiaobian();
            }

            if ((playerTrans.position.x < obj.transform.position.x && playerSr.flipX == true && obj.GetComponent<SpriteRenderer>().flipX == false)
                || (playerTrans.position.x > obj.transform.position.x && playerSr.flipX == false && obj.GetComponent<SpriteRenderer>().flipX == true))
            {
                //当前物体描边
                obj.GetComponent<Interactable>().MiaoBian();

                //将检测物体设置为当前选中物体
                test = obj;
                //检测武器是否在冷却状态中
                if (BaseUnit.isWeapon1Active == true)
                {
                    if (Input.GetButtonDown("Interact") || Input.GetMouseButtonDown(0))
                    {
                        anim.SetTrigger("Interact");
                        obj.GetComponent<Interactable>().ExitMiaobian();
                        obj.GetComponent<EnemyBase>().Die();
                        test.GetComponent<Interactable>().ExitMiaobian();
                        //GameObject.Find("UI_Weapon1").GetComponent<UIweapon>().Cooldown(gameObject);
                        //测试物体失去目标，将其指定为初始物体
                        test = GameObject.Find("FirstAttached");
                        BaseUnit.isWeapon1Active = false;
                    }
                }
            }


            //重置字典与列表
            enemyList.Clear();
            enemyDic.Clear();
        }
        else
        {
            if (test != null)
            {
                test.GetComponent<Interactable>().ExitMiaobian();
            }
            else
            {
                test = GameObject.Find("FirstAttached");
            }
        }
    }

    protected void DetectItem()
    {

        Collider2D[] hitItems = Physics2D.OverlapCircleAll(attackPoint.position, WeaponRange, itemlayers);
        //Debug.Log(hitItems.Length);
        if (hitItems.Length > 0)
        {
            for (int i = 0; i < hitItems.Length; i++)
            {
                float dis = Vector3.Distance(hitItems[i].gameObject.transform.position, playerTrans.position);
                itemDic.Add(dis, hitItems[i].gameObject);
                //Debug.Log(dis);
                if (!itemList.Contains(dis))
                {
                    itemList.Add(dis);
                }
            }
            itemList.Sort();//对距离进行排序
            //Debug.Log("***" + itemList[0]);
            GameObject obj;
            itemDic.TryGetValue(itemList[0], out obj);//获取距离最近的对象
            //Debug.Log(obj.name);
            if (test != obj)
            {
                test.GetComponent<Interactable>().ExitMiaobian();
            }
            if ((playerTrans.position.x < obj.transform.position.x && playerSr.flipX == true)
                || (playerTrans.position.x > obj.transform.position.x && playerSr.flipX == false))
            {
                //当前物体描边
                obj.GetComponent<Interactable>().MiaoBian();

                //将检测物体设置为当前选中物体
                test = obj;

                if (Input.GetButtonDown("Interact") || Input.GetMouseButtonDown(0))
                {
                    anim.SetTrigger("Interact");
                }
            }
            itemList.Clear();
            itemDic.Clear();

        }
        else
        {
            test.GetComponent<Interactable>().ExitMiaobian();
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, WeaponRange);
    }

}