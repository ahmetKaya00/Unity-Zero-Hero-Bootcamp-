using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman : MonoBehaviour
{
    [SerializeField] int DusmanSagligi = 10;
    
    public void dusman(int HasarMiktari)
    {
        DusmanSagligi -= HasarMiktari;
    }

    private void Update()
    {
        if(DusmanSagligi <= 0)
        {
            Invoke("ZombiOlum", 2);
        }
    }

    void ZombiOlum()
    {
        Destroy(gameObject);
    }
}
