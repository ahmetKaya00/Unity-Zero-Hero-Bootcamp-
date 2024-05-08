using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource m_AudioSource;
    public AudioClip m_AudioClip;
    private Transform Kamera;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.clip = m_AudioClip;
        Kamera = Camera.main.transform;
    }

    private void Update()
    {
        float mesafe = Vector3.Distance(transform.position, Kamera.position);


        float maxMesafe = 10f;
        float normalMesafe = Mathf.Clamp01(mesafe / maxMesafe);
        m_AudioSource.volume = 1f - normalMesafe;
    }


}
