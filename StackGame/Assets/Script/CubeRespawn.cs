using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeRespawn : MonoBehaviour
{
    [SerializeField] private MovingCube cubePrefab;
    [SerializeField] private MoveDirection MoveDirection;

    public void SpawnCube()
    {
        var cube = Instantiate(cubePrefab);

        if(MovingCube.LastCube != null && MovingCube.LastCube.gameObject != GameObject.Find("Start"))
        {
            float x = MoveDirection == MoveDirection.X ? transform.position.x : MovingCube.LastCube.transform.position.x;   
            float z = MoveDirection == MoveDirection.Z ? transform.position.z : MovingCube.LastCube.transform.position.z;   
            cube.transform.position = new Vector3(x, MovingCube.LastCube.transform.position.y + cubePrefab.transform.localScale.y, z);
        }
        else
        {
            cube.transform.position = transform.position;
        }
        cube.MoveDirection = MoveDirection;
    }
}

public enum MoveDirection
{
    X,
    Z
}
