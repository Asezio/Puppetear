using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    SpriteRenderer sr;
    public Material outlineMaterial;
    public Material defaultMaterial;
    public Transform textPosition;

    public GameObject TextUI;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        defaultMaterial = sr.material;
        TextUI.SetActive(false);
    }

    //碰到玩家时，给outline
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player_Controller>() != null)
        {
            sr.material = outlineMaterial;
            TextUI.transform.position = textPosition.position;
            TextUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player_Controller>() != null)
        {
            sr.material = defaultMaterial;
            TextUI.SetActive(false);
        }
    }
}