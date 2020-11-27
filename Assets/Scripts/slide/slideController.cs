using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class slideController : MonoBehaviour
{
    public Sprite[] spriteList;
    static int x;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public GameObject finalMessage;
    public int maxNumber;
    public Text wordCounter;

    void Start()
    {
        random();
        x = -1;
        nextImage(GameObject.Find("Image").GetComponent<Image>());
        wordCounter.text = (x+1)+ " / " + (maxNumber+1).ToString();
    }

    public void random()
    {
        // Knuth shuffle algorithm
        for (int t = 0; t < spriteList.Length; t++)
        {
            Sprite tmp1 = spriteList[t];
            AudioClip tmp2 = audioClips[t];
            int r = Random.Range(t, spriteList.Length);
            spriteList[t] = spriteList[r];
            spriteList[r] = tmp1;
            audioClips[t] = audioClips[r];
            audioClips[r] = tmp2;
        }
    }

    public void playClip()
    {
        audioSource.clip = audioClips[x];
        audioSource.Play();
    }
      
    public void nextImage(Image myImageToUpdate)
    {
        if (x < maxNumber)
        {
            x = x + 1;
            wordCounter.text = (x + 1) + " / " + (maxNumber + 1).ToString();
        }
        else if (x >= maxNumber)
        {
            finalMessage.SetActive(true);
        }
        myImageToUpdate.sprite = spriteList[x];
    }

    public void previousImage(Image myImageToUpdate)
    {
        if (x > 0)
        {
            x = x - 1;
            wordCounter.text = (x + 1) + " / " + (maxNumber + 1).ToString();
            myImageToUpdate.sprite = spriteList[x];
        }
    }
}