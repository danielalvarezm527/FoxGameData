using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarPalanca : MonoBehaviour
{
    public PlayerMovement activa;
    public GameObject palanca;
    public GameObject fin;
    public AudioSource sonidoPalanca;
    public bool adentro = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            adentro = true;
            if (activa.activaPalanca && adentro)
            {
                fin.SetActive(true);
                palanca.SetActive(true);
                sonidoPalanca.Play();
                this.gameObject.SetActive(false);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            adentro = false;
        }
    }
}
