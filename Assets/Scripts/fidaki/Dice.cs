using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {
    public GameObject Image1;
    public GameObject Image2;
    public AudioSource audioSource;
    public AudioClip diceRollClip;
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private bool coroutineAllowed = true;
    AudioSource audioData;

    private void Start () {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
        audioSource.clip = diceRollClip;
    }
    
    private IEnumerator OnMouseDown()
    {
        if (!SnakeGameControl.gameOver && coroutineAllowed)
        {
            StartCoroutine("RollTheDice");
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
        }
    }
  
    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        SnakeGameControl.diceSideThrown = randomDiceSide + 1;
        yield return new WaitForSeconds(1f);
        SnakeGameControl.MovePlayer();
        coroutineAllowed = true;
        GameObject.Find("Dice").SetActive(false);

        Image1.SetActive(true);
        Image2.SetActive(true);
    }
}