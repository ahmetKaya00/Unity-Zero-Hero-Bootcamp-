using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman : MonoBehaviour
{
    [SerializeField] int DusmanSagligi = 10;
    public GameObject zombi;

    
    public void dusman(int HasarMiktari)
    {
        DusmanSagligi -= HasarMiktari;
    }

    private void Update()
    {
        if(DusmanSagligi <= 0)
        {
            zombi.GetComponent<Animator>().SetBool("Dyling", true);
            zombi.GetComponent<Animator>().SetBool("Walking", false);
            zombi.GetComponent<Animator>().SetBool("Attacking", false);
            Invoke("ZombiOlum", 3);
        }
    }

    void ZombiOlum()
    {
        Destroy(gameObject);
    }
}
