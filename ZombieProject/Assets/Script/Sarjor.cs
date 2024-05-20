using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sarjor : MonoBehaviour
{
    [SerializeField] AudioSource ses;
    public GameObject triger, mermi;
    public int sarjor, ySarjor, yEkran;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        sarjor = Mermi._cephane;
        ySarjor = Mermi.yCephane;

        if(ySarjor == 0)
        {
            yEkran = 0;
        }
        else
        {
            yEkran = 10 - sarjor;
        }
        if(sarjor <= 0)
        {
            triger.GetComponent<AtesEtme>().enabled = false;
            mermi.GetComponent<Mermi>().enabled = false;
            animator.SetBool("isTrigger", false);
        }
        else
        {
            triger.GetComponent <AtesEtme>().enabled = true;
            mermi.GetComponent <Mermi>().enabled = true;
        }
        if (Input.GetButtonDown("Sarjor"))
        {
            if(yEkran >= 1)
            {
                animator.SetBool("Sarjor", true);
                if(ySarjor <= yEkran)
                {
                    Mermi._cephane += ySarjor;
                    Mermi.yCephane -= ySarjor;
                    ActionReload();
                }
                else
                {
                    Mermi._cephane += yEkran;
                    Mermi.yCephane -= yEkran;
                    ActionReload();
                }
            }
            StartCoroutine(EnableScript());
        }
    }

    IEnumerator EnableScript()
    {
        yield return new WaitForSeconds(1.1f);
        triger.SetActive(true);
        animator.SetBool("Sarjor", false);
    }

    void ActionReload()
    {
        triger.SetActive (false);
        ses.Play();
    }
}
