using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPosition : MonoBehaviour
{
    public GameObject objectToDisable;
    public GameObject otherObject;
    public static bool disabled = false;
    public GameObject audioToDisable;
    public GameObject otherAudio;
    public static bool audioDisabled = false;
    public int position;

    void OnTriggerEnter2D(Collider2D other)
    {
        //otherObject.transform.position = transform.TransformPoint(0, 0, 0);
        Debug.Log("Object Entered the trigger");

        if (position==1)
        {
            if (other.CompareTag("first"))
            {
                objectToDisable.SetActive(false);
                audioToDisable.SetActive(false);
                // objectToDisable.SetActive(true);
            }
            else
            {
                objectToDisable.SetActive(false);
                audioToDisable.SetActive(false);
                //audioToDisable.SetActive(true);
            }
        }

        if (position == 2)
        {
            if (other.CompareTag("second"))
            {
                objectToDisable.SetActive(false);
                audioToDisable.SetActive(false);
                // objectToDisable.SetActive(true);
            }
            else
            {
                objectToDisable.SetActive(false);
                audioToDisable.SetActive(false);
                //audioToDisable.SetActive(true);
            }
        }

        if (position == 3)
        {
            if (other.CompareTag("third"))
            {
                objectToDisable.SetActive(false);
                audioToDisable.SetActive(false);
                // objectToDisable.SetActive(true);
            }
            else
            {
                objectToDisable.SetActive(false);
                audioToDisable.SetActive(false);
                //audioToDisable.SetActive(true);
            }
        }

        if (position == 4)
        {
            if (other.CompareTag("fourth"))
            {
                objectToDisable.SetActive(false);
                audioToDisable.SetActive(false);
                // objectToDisable.SetActive(true);
            }
            else
            {
                objectToDisable.SetActive(false);
                audioToDisable.SetActive(false);
                //audioToDisable.SetActive(true);
            }
        }
    }
   
    void OnTriggerStay2D(Collider2D other)
    {
        if (position == 1)
        {
            if (other.CompareTag("first"))
            {
                //objectToDisable.SetActive(false);
                //audioToDisable.SetActive(false);
                objectToDisable.SetActive(true);
            }
            else
            {
                //objectToDisable.SetActive(false);
                // audioToDisable.SetActive(false);
                audioToDisable.SetActive(true);
            }
        }

        if (position == 2)
        {
            if (other.CompareTag("second"))
            {
                //objectToDisable.SetActive(false);
                //audioToDisable.SetActive(false);
                objectToDisable.SetActive(true);
            }
            else
            {
                //objectToDisable.SetActive(false);
                // audioToDisable.SetActive(false);
                audioToDisable.SetActive(true);
            }
        }

        if (position == 3)
        {
            if (other.CompareTag("third"))
            {
                //objectToDisable.SetActive(false);
                //audioToDisable.SetActive(false);
                objectToDisable.SetActive(true);
            }
            else
            {
                //objectToDisable.SetActive(false);
                // audioToDisable.SetActive(false);
                audioToDisable.SetActive(true);
            }
        }

        if (position == 4)
        {
            if (other.CompareTag("fourth"))
            {
                //objectToDisable.SetActive(false);
                //audioToDisable.SetActive(false);
                objectToDisable.SetActive(true);
            }
            else
            {
                //objectToDisable.SetActive(false);
                // audioToDisable.SetActive(false);
                audioToDisable.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D()
    {
        Debug.Log("Object Exited the trigger");
        objectToDisable.SetActive(false);
        audioToDisable.SetActive(false);
    }
    
}
