using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gema : MonoBehaviour
{
    public canvas gemas;
    public AudioSource sonidoGema;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gemas.numeroGemas += 1;
            sonidoGema.Play();
            gameObject.SetActive(false);
        }
    }
}
