using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public static MovingCube CurrentCube { get; private set; }
    public static MovingCube LastCube { get; private set; }

    [SerializeField] private float moveSpeed = 1f;

    private void OnEnable()
    {
        if (LastCube == null)
            LastCube = GameObject.Find("Start").GetComponent<MovingCube>();
        CurrentCube = this;
    }
    internal void Stop()
    {
        moveSpeed = 0f; 
        float breakZ = transform.position.z - LastCube.transform.position.z;

        float direction = breakZ > 0 ? 1f : -1f;
        SplitCobeOnZ(breakZ, direction);
    }

    private void SplitCobeOnZ(float breakZ, float direction)
    {
       float newSize = LastCube.transform.localScale.z - Mathf.Abs(breakZ);
       float fallingBlockSize = transform.position.z - newSize;
       float newPosition = LastCube.transform.localPosition.z + (breakZ / 2);
       transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newSize);
        transform.position = new Vector3(transform.position.x, transform.position.y, newPosition);
    }

    private void DropCube()
    {

    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }
}
