using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLaRata : MonoBehaviour {

    public float DistanciaRata1 = 28.07f;
    public float DistanciaRata2 = 11.07f;
    public float golpe = 1000;

    public bool Ejecutar = true;
    public bool Escala = true;

    public GameObject Rata;

    public Rigidbody2D jugador;

    void Update()
    {
        if (Ejecutar == true)
        {
            StartCoroutine(LaRata());
            Ejecutar = false;

        }

        if (Escala == true)
        {
            Rata.transform.localScale = new Vector2(3, 3);
        }
        else if (Escala == false)
        {
            Rata.transform.localScale = new Vector2(-3, 3);
        }

    }

    IEnumerator LaRata()
    {
        while (DistanciaRata1 > 11.07f)
        {
            DistanciaRata1 -= Time.fixedDeltaTime;
            transform.position = new Vector2(DistanciaRata1, Rata.transform.position.y);

            yield return null;

        }
        DistanciaRata1 = 28.07f;
        Escala = false;
        yield return new WaitForSeconds(.1f);

        while (DistanciaRata2 < 28.07f)
        {
            DistanciaRata2 += Time.fixedDeltaTime;
            transform.position = new Vector2(DistanciaRata2, Rata.transform.position.y);

            yield return null;

        }
        DistanciaRata2 = 11.07f;
        Ejecutar = true;
        Escala = true;

    }
}
