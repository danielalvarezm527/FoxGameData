using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileMapScript : MonoBehaviour
{
    public PlayerMovement salto;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            salto.puedeSaltar = true;
            salto.Player.SetBool("Salto", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            salto.puedeSaltar = false;
        }
    }
}
