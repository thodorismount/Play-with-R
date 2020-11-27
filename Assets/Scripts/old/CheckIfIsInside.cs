using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfIsInside : MonoBehaviour {
    public GameObject objectToDisable;
    //public GameObject otherObject;
    public static bool disabled = false;
    public GameObject audioToDisable;
    //public GameObject otherAudio;
    public static bool audioDisabled = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("red"))
        {
            objectToDisable.SetActive(false);
            audioToDisable.SetActive(false);
        }
        else
        {
            objectToDisable.SetActive(false);
            audioToDisable.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("red"))
        {
            objectToDisable.SetActive(true);
        }
        else
        {
            audioToDisable.SetActive(true);
        }
            }
    void OnTriggerExit2D()
    {
        objectToDisable.SetActive(false);
        audioToDisable.SetActive(false);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        AudioListener.volume = 1;
    }
}
