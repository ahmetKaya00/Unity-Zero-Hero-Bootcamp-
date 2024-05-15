using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField] TMP_Text panelText;
    [SerializeField] string[] texts;
    private int currentIndex = 0;
    [SerializeField] private float delay = 0.1f;
    private Coroutine typingCorutine;

    private void Start()
    {
        StartTyping();
    }

    public void StartTyping()
    {
        if(typingCorutine != null)
        {
            StopCoroutine(typingCorutine);
        }

        typingCorutine = StartCoroutine(ShowText());
    }
    IEnumerator ShowText()
    {
        string fullText = texts[currentIndex];

        for(int i = 0;i<= fullText.Length; i++)
        {
            string currentText = fullText.Substring(0,i);
            panelText.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
    public void ChangeText()
    {
        currentIndex = (currentIndex + 1) % texts.Length;
        StartTyping();
    }
}
