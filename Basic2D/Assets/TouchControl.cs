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

            //Dokunma i�lemi ba�lad���nda
            if(touch.phase == TouchPhase.Began)
            {
                Debug.Log("Ekrana dokunulan yerin koordinatlar�: " + touch.position);
            }
            //Parmak s�r�klendi�inde
            if(touch.phase == TouchPhase.Moved)
            {
                Debug.Log("Parmak s�r�kleniyor. Hareket Miktar�: " + touch.deltaPosition);
            }

            //Dokunma devam ederken
            if(touch.phase == TouchPhase.Stationary)
            {
                Debug.Log("Dokunma devam ediyor");
            }


            //Dokunma bitti�inde

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

            Debug.Log("�ki parmak aras�ndaki mesafe: " + distance);
        }
    }
}
