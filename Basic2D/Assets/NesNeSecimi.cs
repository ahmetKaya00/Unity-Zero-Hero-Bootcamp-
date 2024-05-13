using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NesNeSecimi : MonoBehaviour
{
    [SerializeField] private GameObject Panel, APrafab, BPrefab;
    [SerializeField] private Text selectionText;

    private int ACount = 0, BCount = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hit.collider != null)
            {
                if (hit.collider.CompareTag("Apple"))
                {
                    ACount++;
                    Destroy(hit.collider.gameObject);
                    UpdateSelectionText();
                }
                if (hit.collider.CompareTag("Break"))
                {
                    BCount++;
                    Destroy(hit.collider.gameObject);
                    UpdateSelectionText();
                }
            }
        }
    }
    void UpdateSelectionText()
    {
        if(selectionText != null)
        {
            selectionText.text = "Elma: " + ACount + "\nEkmek: " + BCount; 
        }
    }

    void CreateObject()
    {
        for(int i = 0; i < ACount; i++)
        {
            GameObject Elma = Instantiate(APrafab, RandomPosition(), Quaternion.identity);
            Elma.transform.localScale = Vector3.one * 0.5f;
        }
        for(int i = 0; i < BCount; i++)
        {
            GameObject Ekmek = Instantiate(BPrefab, RandomPosition(), Quaternion.identity);
            Ekmek.transform.localScale = Vector3.one * 0.5f;
        }
    }

    Vector3 RandomPosition()
    {
        float x = Random.Range(-5f, 5f);
        float y = Random.Range(-3f, 3f);
        return new Vector3(x, y, 0);
    }

    public void Createandclose()
    {
        Panel.SetActive(false);
        CreateObject();
    }
}
