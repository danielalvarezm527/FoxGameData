using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaSecreta1 : MonoBehaviour
{
    public PlayerMovement activa;

    // Update is called once per frame
    void Update()
    {
        if (activa.activaPalanca)
        {
            transform.position = Vector2.Lerp(this.gameObject.transform.position, new Vector2(139.53f, -10.68402f), 0.02f * 0.3f);
        }
    }
}
