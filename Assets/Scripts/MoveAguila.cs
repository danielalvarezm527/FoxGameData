using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAguila : MonoBehaviour
{
    float aguilaPos1 = 11.09f;
    float aguilaPos2 = 26.66f;
    float atacaAguilaPos1 = 9.27f;
    float atacaAguilaPos2 = 1.31f;

    bool escala = false;
    bool activaCorrutina = false;
    bool puedeAtacar = true;

    GameObject aguila;
    public GameObject realAguila;

    private void Start()
    {
        aguila = this.gameObject;
        StartCoroutine(movAguila());
    }

    private void Update()
    {
        if (activaCorrutina)
        {
            StartCoroutine(movAguila());
            activaCorrutina = false;
        }

        if (!escala)
            aguila.transform.localScale = new Vector2(-5, 5);
        if (escala)
            aguila.transform.localScale = new Vector2(5, 5);
    }

    IEnumerator movAguila()
    {
        while (aguilaPos1 < 26.66f)
        {
            aguilaPos1 += Time.fixedDeltaTime * 4;
            transform.position = new Vector2(aguilaPos1, aguila.transform.position.y);

            yield return null;
        }
        escala = true;
        aguilaPos1 = 11.09f;
        yield return new WaitForSeconds(.1f);

        while (aguilaPos2 > 11.09f)
        {
            aguilaPos2 -= Time.fixedDeltaTime * 4;
            transform.position = new Vector2(aguilaPos2, aguila.transform.position.y);

            yield return null;
        }
        escala = false;
        aguilaPos2 = 26.66f;
        activaCorrutina = true;
    }

    IEnumerator atacaAguila()
    {
        while (atacaAguilaPos1 > 1.31f)
        {
            atacaAguilaPos1 -= Time.fixedDeltaTime * 9;
            realAguila.transform.position = new Vector2(realAguila.transform.position.x, atacaAguilaPos1);
            yield return null;
        }
        atacaAguilaPos1 = 9.27f;

        while (atacaAguilaPos2 < 9.27f)
        {
            atacaAguilaPos2 += Time.fixedDeltaTime * 9;
            realAguila.transform.position = new Vector2(realAguila.transform.position.x, atacaAguilaPos2);
            yield return null;
        }
        atacaAguilaPos2 = 1.31f;
        puedeAtacar = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (puedeAtacar)
            {
                StartCoroutine(atacaAguila());
                puedeAtacar = false;
            }
        }
    }
}
