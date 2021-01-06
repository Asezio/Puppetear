using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posion_01 : MonoBehaviour
{

    [SerializeField]
    AudioClip m_collectSFX = null;

    private AudioSource m_source = null;

    private void Po()
    {
        if (GetComponent<AudioSource>() != null)
        {
            m_source = GetComponent<AudioSource>();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if ((m_collectSFX != null))
            {
                Camera.main.GetComponent<AudioSource>().PlayOneShot(m_collectSFX);
            }

            ScoreManager.score++;
            Destroy(this.gameObject);
        }
    }

}
