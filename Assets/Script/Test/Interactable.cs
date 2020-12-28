using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    SpriteRenderer sr;
    public Material outlineMaterial;
    public Material defaultMaterial;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        defaultMaterial = sr.material;
    }

    //碰到玩家时，给outline
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player_Controller>() != null)
        {
            sr.material = outlineMaterial;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player_Controller>() != null)
        {
            sr.material = defaultMaterial;
        }
    }
}