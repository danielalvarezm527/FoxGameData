using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class canvas : MonoBehaviour
{
    public int numeroGemas;
    public TextMeshProUGUI numGemas;

    void Update()
    {
        numGemas.text = numeroGemas.ToString();
    }
}
