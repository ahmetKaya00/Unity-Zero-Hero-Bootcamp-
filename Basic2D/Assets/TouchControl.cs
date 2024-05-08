using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //Dokunma iþlemi baþladýðýnda
            if(touch.phase == TouchPhase.Began)
            {
                Debug.Log("Ekrana dokunulan yerin koordinatlarý: " + touch.position);
            }
            //Parmak sürüklendiðinde
            if(touch.phase == TouchPhase.Moved)
            {
                Debug.Log("Parmak sürükleniyor. Hareket Miktarý: " + touch.deltaPosition);
            }

            //Dokunma devam ederken
            if(touch.phase == TouchPhase.Stationary)
            {
                Debug.Log("Dokunma devam ediyor");
            }


            //Dokunma bittiðinde

            if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                Debug.Log("Dokunma bitti");
            }
        }
        if(Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            float distance = Vector2.Distance(touch1.position, touch2.position);

            Debug.Log("Ýki parmak arasýndaki mesafe: " + distance);
        }
    }
}
