using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MovingCube : MonoBehaviour
{
    public static MovingCube CurrentCube { get; private set; }
    public static MovingCube LastCube { get; private set; }
    public MoveDirection MoveDirection { get; set; }

    [SerializeField] private float moveSpeed = 1f;

    private void OnEnable()
    {
        if (LastCube == null)
            LastCube = GameObject.Find("Start").GetComponent<MovingCube>();
        CurrentCube = this;
        GetComponent<Renderer>().material.color = GetRandomColor();

        transform.localScale = new Vector3(LastCube.transform.localScale.x, transform.localScale.y, LastCube.transform.localScale.z);
    }

    private Color GetRandomColor()
    {
        return new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }
    internal void Stop()
    {
        moveSpeed = 0f;
        float breakZ = GetBreak();
        float max = MoveDirection == MoveDirection.X ? LastCube.transform.localScale.z : LastCube.transform.localScale.x;
        if (Mathf.Abs(breakZ) >= max)
        {
            LastCube = null;
            CurrentCube = null;
            SceneManager.LoadScene(0);
        }

        float direction = breakZ > 0 ? 1f : -1f;
        if(MoveDirection == MoveDirection.Z)
            SplitCobeOnZ(breakZ, direction);
        else
            SplitCobeOnX(breakZ, direction);
        LastCube = this;
    }
    private float GetBreak()
    {
        if(MoveDirection == MoveDirection.Z)
          return transform.position.z - LastCube.transform.position.z;
        else
            return transform.position.x - LastCube.transform.position.x;
    }

    private void SplitCobeOnZ(float breakZ, float direction)
    {
       float newSize = LastCube.transform.localScale.z - Mathf.Abs(breakZ);
       float fallingBlockSize = transform.localScale.z - newSize;
       float newPosition = LastCube.transform.localPosition.z + (breakZ / 2);
       transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newSize);
       transform.position = new Vector3(transform.position.x, transform.position.y, newPosition);

        float cubeEgde = transform.position.z + (newSize / 2 * direction);
        float fallingBlockZPos = cubeEgde + fallingBlockSize / 2f * direction;

        DropCube(fallingBlockZPos, fallingBlockSize);

    }
    private void SplitCobeOnX(float breakZ, float direction)
    {
       float newXSize = LastCube.transform.localScale.x - Mathf.Abs(breakZ);
       float fallingBlockSize = transform.localScale.x - newXSize;
       float newPosition = LastCube.transform.localPosition.x + (breakZ / 2);
       transform.localScale = new Vector3(newXSize, transform.localScale.y, transform.localScale.z);
       transform.position = new Vector3(newPosition,transform.position.y, transform.position.z );

        float cubeEgde = transform.position.x + (newXSize / 2 * direction);
        float fallingBlockXPos = cubeEgde + fallingBlockSize / 2f * direction;

        DropCube(fallingBlockXPos, fallingBlockSize);

    }

    private void DropCube(float fallingBlockZPos, float fallingBlockSize)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        if(MoveDirection == MoveDirection.Z)
        {

        cube.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, fallingBlockSize);
        cube.transform.position = new Vector3(transform.position.x,transform.position.y,fallingBlockZPos);
        }
        else
        {
            cube.transform.localScale = new Vector3(fallingBlockSize,transform.localScale.y, transform.localScale.z);
            cube.transform.position = new Vector3(fallingBlockZPos,transform.position.y, transform.position.z);
        }

        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
        Destroy(cube.gameObject, 1f);

    }

    private void Update()
    {
        if(MoveDirection == MoveDirection.Z)
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        else
            transform.position += transform.right * Time.deltaTime * moveSpeed;
    }
}
