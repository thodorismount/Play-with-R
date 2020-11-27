using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenSlotHandler : MonoBehaviour
{
    public GameObject AudioSourceFalse;
    public GameObject AudioSourceTrue;
    public static GameObject prasino;
    public GameObject kokkino;
    public GameObject correctAnswer;
    GameObject prasinoSlot;
    GameObject kokkinoSlot;

    void Start()
    {
        prasino = GameObject.Find("prasinosKyklos");
        kokkino = GameObject.FindGameObjectWithTag("red");
        prasinoSlot = GameObject.FindGameObjectWithTag("prasinoSlot");
        kokkinoSlot = GameObject.FindGameObjectWithTag("kokkinoSlot");
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("red"))
        {
            AudioSourceFalse.SetActive(false);
            AudioSourceTrue.SetActive(false);
        }
        else if ((other.CompareTag("greenCircle")))
        {
            AudioSourceFalse.SetActive(false);
            AudioSourceTrue.SetActive(false);
            Instantiate(prasino, transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("prasinoSlot").transform);
            prasino.tag = "prasinosPanwKyklos";
            prasino.GetComponent<DragHandler>().enabled = false;
            prasino = GameObject.FindGameObjectWithTag("greenCircle");
            if (prasinoSlot.transform.childCount > 1)
            {
                for (int i = 0; i < prasinoSlot.transform.childCount-1; i++)
                {
                    Destroy(prasinoSlot.transform.GetChild(i).gameObject);
                }
            }
        }
    }

    IEnumerator OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("red"))
        {
            AudioSourceFalse.SetActive(true);
            yield return new WaitForSeconds(0.35f);
            kokkino = GameObject.FindGameObjectWithTag("red");
            kokkino.transform.SetParent(GameObject.FindGameObjectWithTag("kokkinoSlot").transform, false);
        }
        else if (other.CompareTag("prasinosPanwKyklos"))
        {
            AudioSourceTrue.SetActive(true);
            redSlotHandler.counter++;
            if (redSlotHandler.counter / 24 == GameObject.Find("topPanel").transform.childCount)
            {
                correctAnswer.SetActive(true);
                GameObject.Find("Image").GetComponent<imageHandlerKatatmhsh>().playClip();
                redSlotHandler.counter = 0;
            }
            yield return new WaitForSeconds(1f);           
        }       
    }
    void OnTriggerExit2D(Collider2D other)
    {
        AudioSourceFalse.SetActive(false);
        AudioSourceTrue.SetActive(false);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
}