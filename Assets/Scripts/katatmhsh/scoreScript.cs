using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreScript : MonoBehaviour
{
    static public int value=0;
   // static public bool flag = false;
   // AudioSource audioSource;
    public GameObject okLogo;
    public GameObject panwpanel;
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        //value = -1;
        //  value++;
        //Debug.Log(value);
    }
    void OnEnable()
    {
        //audioSource = GetComponent<AudioSource>();
        //value++;
        // Debug.Log(value);
        /* if (audioSource.isPlaying)
         {
             value++;
             Debug.Log("lathoi:  ");*/
      //  value++;
        /**  Debug.Log("aaaa");
          Debug.Log(panwpanel.transform.childCount);
          Debug.Log(value);*/
        //panwpanel = GameObject.Find("panwPanel");
       /* if (value == panwpanel.transform.childCount)
        {
            okLogo.SetActive(true);
            GameObject.Find("Image").GetComponent<panwPanelKatatmhsh>().playClip();
            value = 0;
        }*/
        /*}*/
    }
    // Update is called once per frame
   // void Update()
        
       // GameObject panwpanel = GameObject.Find("panwpanel");
       // Debug.Log(panwpanel.transform.childCount);
        /*if(redSlotHandler.counter / 24== panwpanel.transform.childCount)
        {
            okLogo.SetActive(true);
            GameObject.Find("Image").GetComponent<imageHandlerKatatmhsh>().playClip();
            redSlotHandler.counter = 0;
        }*/
   // }

  /*  public void resetScore()
    {
        value = 0;
        redSlotHandler.counter = 0;
        okLogo.SetActive(false);
    }*/
   // {
        //value += (Time.deltaTime * 1.5f);

        //if(Input.GetKeyDown(KeyCode.T))
        //{
        //GameObject.Find("AudioSourceFalse");
       // if (GameObject.Find("AudioSourceFalse").activeSelf == true)
       // {
           /* if (audioSource.isPlaying)
            {
                value++;
                Debug.Log(value);
            }*/
        //}
    
}
