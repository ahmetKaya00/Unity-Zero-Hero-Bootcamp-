using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mermi : MonoBehaviour
{
    public static int _cephane, yCephane;
    public int icCephane, YicCephane = 0;
    [SerializeField] GameObject Cephane, YCephane;

    private void Update()
    {
        icCephane = _cephane;
        Cephane.GetComponent<Text>().text = "" + icCephane;
        YicCephane = yCephane;
        YCephane.GetComponent<Text>().text = "" + YicCephane;
    }
}
