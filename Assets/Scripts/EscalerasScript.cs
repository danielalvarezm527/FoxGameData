using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalerasScript : MonoBehaviour
{
    PlayerMovement escalera;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            escalera = collision.GetComponent<PlayerMovement>();
            escalera.escaleras = true;
            Rigidbody2D player = collision.GetComponent<Rigidbody2D>();
            player.gravityScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            escalera = collision.GetComponent<PlayerMovement>();
            escalera.escaleras = false;
            Rigidbody2D player = collision.GetComponent<Rigidbody2D>();
            player.gravityScale = 3;
            player.velocity = new Vector2(0, 0);
        }
    }
}
