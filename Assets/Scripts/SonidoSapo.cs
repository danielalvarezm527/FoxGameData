using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoSapo : MonoBehaviour {

    public AudioSource SonidoDelSapo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SonidoDelSapo.Play();
        }
    }
}
