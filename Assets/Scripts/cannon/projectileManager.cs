using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("spriteTrue"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = audioClips[0];
            audio.Play();
            yield return new WaitForSeconds(1);
            GameObject.Find("cannonManager").GetComponent<cannonImagesManager>().userSelectTrue();

            var velos = GameObject.FindGameObjectsWithTag("projectile");

            foreach (GameObject item in velos)
            {
                Destroy(item);
            }
        }
        else if (other.CompareTag("SpriteFalse"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = audioClips[1];
            audio.Play();
            yield return new WaitForSeconds(audio.clip.length);
            GameObject.Find("cannonManager").GetComponent<cannonImagesManager>().userSelectFalse();

            var velos = GameObject.FindGameObjectsWithTag("projectile");
            foreach (GameObject item in velos)
            {
                Destroy(item);
            }
        }
    }   
}