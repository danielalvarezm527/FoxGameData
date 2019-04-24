using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlataforma : MonoBehaviour {

    public float DistanciaPlataforma1 = 62.28f;
    public float DistanciaPlataforma2 = 69.36f;

    public bool Ejecutar = true;
    public bool Escala = true;

    public GameObject Plataforma;


    void Update()
    {
        if (Ejecutar == true)
        {
            StartCoroutine(LaMovPlat());
            Ejecutar = false;

        }

        if (Escala == true)
        {
            Plataforma.transform.localScale = new Vector2(1, 1);

        }
        else if (Escala == false)
        {
            Plataforma.transform.localScale = new Vector2(1, 1);

        }

    }

    IEnumerator LaMovPlat()
    {
        while (DistanciaPlataforma1 < 69.36f)
        {
            DistanciaPlataforma1 += Time.fixedDeltaTime;
            transform.position = new Vector2(DistanciaPlataforma1, Plataforma.transform.position.y);

            yield return null;

        }
        DistanciaPlataforma1 = 62.28f;
        Escala = false;
        yield return new WaitForSeconds(.1f);

        while (DistanciaPlataforma2 > 62.28f)
        {
            DistanciaPlataforma2 -= Time.fixedDeltaTime;
            transform.position = new Vector2(DistanciaPlataforma2, Plataforma.transform.position.y);

            yield return null;

        }
        DistanciaPlataforma2 = 69.36f;
        Ejecutar = true;
        Escala = true;

    }
}
