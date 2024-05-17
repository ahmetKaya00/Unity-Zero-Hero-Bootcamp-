using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtesEtme : MonoBehaviour
{
    [SerializeField] int hasarMiktari = 5;
    [SerializeField] float HedefUzakligi, VerilenUzaklik = 15f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit Atis;

            if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out Atis))
            {
                HedefUzakligi = Atis.distance;

                if(HedefUzakligi < VerilenUzaklik)
                {
                    Atis.transform.SendMessage("dusman", hasarMiktari);
                }
            }
        }
    }
}
