using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class randomSceneManager : MonoBehaviour
{
   public static  int[] numbers = new int[] { 2, 3, 4, 5, 6 }; //contains all build indexs of katatmhsh scenes
    public static int[] newNumbers = new int[3]; // contains certain build indexes of katatmhsh scenes
    int i = 0;
    int z = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void random()
    {
        //int[] numbers;
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < numbers.Length; t++)
        {
            int tmp = numbers[t];
            int r = Random.Range(t, numbers.Length);
            numbers[t] = numbers[r];
            numbers[r] = tmp;
        }
         Debug.Log("arxh");
        for (i = 0; i <= 3; i++)
        {
             //Debug.Log(numbers[i]);
        }
          Debug.Log("telos");
       // return numbers;
    }

    public static int[] returnArray()
    {
        Debug.Log("arxh");
        for (int t = 0; t < 3; t++)
        {
            newNumbers[t] = numbers[t];
            Debug.Log(newNumbers[t]);
        }
        Debug.Log("telos");
        return newNumbers;
    }

    public void NextRandomScene()
    {
        z = z + 1;
        Debug.Log(numbers[z]);
        SceneManager.LoadScene(numbers[z + 1]);
        //  Debug.Log("aris");
    }

    // Update is called once per frame
    // void Awake()
    // {
    //     numbers = new int[] { 2, 3, 4, 5 };
    // }
}
