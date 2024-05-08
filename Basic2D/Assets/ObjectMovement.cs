using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = targetPosition;

        }
    }
}
