using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class redSlotHandler : MonoBehaviour
{
    public GameObject AudioSourceTrue;
    public GameObject AudioSourceFalse;
    public GameObject prasino;
    public static GameObject kokkino;
    public GameObject correctAnswer;
    GameObject prasinoSlot;
    GameObject kokkinoSlot;
    public static int counter;

    void Start()
    {
        prasino = GameObject.FindGameObjectWithTag("greenCircle");
        kokkino = GameObject.Find("kokkinosKyklos");
        prasinoSlot = GameObject.FindGameObjectWithTag("prasinoSlot");
        kokkinoSlot = GameObject.FindGameObjectWithTag("kokkinoSlot");
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("red"))
        {
            AudioSourceTrue.SetActive(false);
            AudioSourceFalse.SetActive(false);
            Instantiate(kokkino, transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("kokkinoSlot").transform);
            kokkino.tag = "kokkinosPanwKyklos";
            kokkino.GetComponent<DragHandler>().enabled = false;
            kokkino = GameObject.FindGameObjectWithTag("red");

            if (kokkinoSlot.transform.childCount > 1)
            {
                for (int i = 0; i < kokkinoSlot.transform.childCount - 1; i++)
                {
                    Destroy(kokkinoSlot.transform.GetChild(i).gameObject);
                }
            }
        }
        else if(other.CompareTag("greenCircle"))
        {
            AudioSourceTrue.SetActive(false);
            AudioSourceFalse.SetActive(false);
        }        
    }

    IEnumerator OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("kokkinosPanwKyklos"))
        {
            AudioSourceTrue.SetActive(true);
            counter++;
            if (counter / 24 == GameObject.Find("topPanel").transform.childCount)
            {
                correctAnswer.SetActive(true);
                GameObject.Find("Image").GetComponent<imageHandlerKatatmhsh>().playClip();
                redSlotHandler.counter = 0;
            }
            yield return new WaitForSeconds(1f);            
        }
        else if (other.CompareTag("greenCircle"))
        {
            AudioSourceFalse.SetActive(true);
            yield return new WaitForSeconds(0.35f);
            prasino = GameObject.FindGameObjectWithTag("greenCircle");
            prasino.transform.SetParent(GameObject.FindGameObjectWithTag("prasinoSlot").transform, false);            
        }
        yield return new WaitForSeconds(1f);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        AudioSourceTrue.SetActive(false);
        AudioSourceFalse.SetActive(false);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
}