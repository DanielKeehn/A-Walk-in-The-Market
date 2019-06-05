using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    private void Start()
    {
        AudioSource audio = FindObjectOfType<AudioSource>();
        audio.Play();
    }
}