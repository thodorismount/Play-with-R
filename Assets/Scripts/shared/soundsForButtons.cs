using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundsForButtons : MonoBehaviour
{
    public AudioSource source;
    public AudioClip hoverClip;

    public void hoverSound()
    {
            source.PlayOneShot(hoverClip);
    }

    public void hoverExit()
    {
        if (source != null)
        {
            source.Stop();
        }
    }
}