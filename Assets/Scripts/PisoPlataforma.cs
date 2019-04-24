using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisoPlataforma : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.SetParent(gameObject.transform);

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.transform.SetParent(null);

    }
}
