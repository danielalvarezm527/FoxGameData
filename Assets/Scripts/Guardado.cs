using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;

public class Guardado : MonoBehaviour
{
    public Botones play;
    public Botones instructions1;
    public Botones instructions2;
    public GameObject panel2;
    public GameObject panel1;
    public GameObject boton1;
    public GameObject boton2;

    public void Update()
    {
        if (play.isPressed)
        {
            SceneManager.LoadScene(1);
        }
        if (instructions1.isPressed)
        {
            boton1.SetActive(false);
            boton2.SetActive(true);
            panel2.SetActive(true);
            panel1.SetActive(false);            
        }

        if (instructions2.isPressed)
        {
            boton2.SetActive(false);
            boton1.SetActive(true);
            panel1.SetActive(true);
            panel2.SetActive(false);
        }
    }
}
