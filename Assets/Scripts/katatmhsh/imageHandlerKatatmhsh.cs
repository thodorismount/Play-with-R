using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class imageHandlerKatatmhsh : MonoBehaviour
{
    public syllabesKatatmhsh[] syllabes;
    public static int x = 0;
    public GameObject[] greenSlots;
    public GameObject[] redSlots;
    int greenCounter = 0, redCounter = 0;
    public GameObject topPanel;
    public GameObject secondPanel;
    public GameObject PreviousButton;
    public GameObject finalMessage;
    public GameObject correctAnswer;
    public AudioSource audioSource;
    public Text wordCounter;

    public int maxNumber = 10;
    void Start()
    {
        random();
        greenCounter = 0;
        redCounter = 0;
        x = 0;
        FirstImage(GameObject.Find("Image").GetComponent<Image>());        
        moveSlotsToPanel();
        wordCounter.text = (x + 1) + " / " + (maxNumber).ToString();
    }

    void Update()
    {
        if (x == 0)
        {
            PreviousButton.SetActive(false);
        }
         else   PreviousButton.SetActive(true);
    }

    public void random()
    {
        // Knuth shuffle algorithm
        for (int t = 0; t < syllabes.Length; t++)
        {
            syllabesKatatmhsh tmp1 = syllabes[t];
            int r = Random.Range(t, syllabes.Length);
            syllabes[t] = syllabes[r];
            syllabes[r] = tmp1;
        }
        x = 0;
    }
    public void FirstImage(Image myImageToUpdate)
    {
        myImageToUpdate.sprite = syllabes[0].image;
    }

    public void nextKatatmhshWord()
    {        
        if (x < maxNumber - 1)
        {
            x++;
            removeSlotsFromPanel();
            moveSlotsToPanel();
            wordCounter.text = (x + 1) + " / " + (maxNumber).ToString();
            redSlotHandler.counter = 0;
        }
        else
        {
            finalMessage.SetActive(true);
        }
    }

    public void previousKatatmhshWord()
    {     
        if (x >0)
        {
            x--;
            removeSlotsFromPanel();
            moveSlotsToPanel();
            wordCounter.text = (x + 1) + " / " + (maxNumber).ToString();
            redSlotHandler.counter = 0;
        }        
    }

    public void nextImage(Image myImageToUpdate)
    {
        if (x < maxNumber)
        {
            myImageToUpdate.sprite = syllabes[x].image;
        }
    }

    public void previousImage(Image myImageToUpdate)
    {
       if (x > -1)
        { 
            myImageToUpdate.sprite = syllabes[x].image;
        }
    }

    public void moveSlotsToPanel()
    {
        for (int j = 0; j < syllabes[x].syllabesArray.Length; j++)
        {
            if (syllabes[x].syllabesArray[j] == 2)
            {
                {
                    redSlots[redCounter].transform.SetParent(topPanel.transform, false);
                    redCounter++;
                }
            }
            else
            {
                greenSlots[greenCounter].transform.SetParent(topPanel.transform, false);
                greenCounter++;
            }
        }
        redCounter = 0;
        greenCounter = 0;
    }

    public void removeSlotsFromPanel()
    {
        for (int i = 0; i < greenSlots.Length; i++)
        {
            greenSlots[i].transform.SetParent(secondPanel.transform, false);
            foreach (Transform child in greenSlots[i].transform)
                Destroy(child.gameObject);
        }
        for (int i = 0; i < redSlots.Length; i++)
        {
            redSlots[i].transform.SetParent(secondPanel.transform, false);
            foreach (Transform child in redSlots[i].transform)
                Destroy(child.gameObject);
        }
    }

    public void removeCirclesFromTopPanel()
    {
        for (int i = 0; i < greenSlots.Length; i++)
        {
            foreach (Transform child in greenSlots[i].transform)
                Destroy(child.gameObject);
        }
        for (int i = 0; i < redSlots.Length; i++)
        {
            foreach (Transform child in redSlots[i].transform)
                Destroy(child.gameObject);
        }
        correctAnswer.SetActive(false);
        redSlotHandler.counter = 0;
    }

    public void playClip()
    {
        audioSource.clip = syllabes[x].wordClip;
        audioSource.Play();
    }
}