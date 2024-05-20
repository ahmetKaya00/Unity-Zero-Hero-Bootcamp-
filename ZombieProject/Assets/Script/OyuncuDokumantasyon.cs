using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuDokumantasyon : MonoBehaviour
{
    public static float HedefMesafe;
    public float Hedef;

    private void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit))
        {
            Hedef = hit.distance;
            HedefMesafe = Hedef;
        }
    }
}
