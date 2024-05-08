using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleFollow : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;

    public GameObject player1, player2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            VirtualCamera.Follow = player1.transform;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            VirtualCamera.Follow = player2.transform;

        }
    }
}
