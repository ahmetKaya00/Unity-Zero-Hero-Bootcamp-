using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HedefGoster : MonoBehaviour
{
    public float Mesafe = OyuncuDokumantasyon.HedefMesafe;
    public GameObject YaziGoster;

    private void Update()
    {
        Mesafe = OyuncuDokumantasyon.HedefMesafe;
    }
    private void OnMouseOver()
    {
        if(Mesafe < 8)
        {
            YaziGoster.GetComponent<Text>().text = "Silahý Al!";
        }
    }
    private void OnMouseExit()
    {
        YaziGoster.GetComponent<Text>().text = "";
    }
}
