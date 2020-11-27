using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cannonImagesManager : MonoBehaviour {

	public question[] questions;
	public static List<question> unansweredQuestions;
    public falseQuestion[] falseQuestions;
    public static List<falseQuestion> unansweredfalseQuestions;
    public int x = 0;
    public static int position;
    private question currentQuestion;
    private falseQuestion currentfalseQuestion;
    public int numberOfImages;
    public GameObject cannon;
    public GameObject cannonBase;
    public GameObject finishMessage;
    public GameObject tryAgainPanel;
    public Text wordCounter;
    public static int mistakesScore;
    public Transform[] waypoints;

    [SerializeField]
    private SpriteRenderer spriteTrue;

    [SerializeField]
    private SpriteRenderer spriteFalse;
    
    void Start()
	{
        randomOrder();
        mistakesScore = 0;
		unansweredQuestions = questions.ToList<question> ();
        unansweredfalseQuestions = falseQuestions.ToList<falseQuestion>();
        x = 0;
        
        x++;
        wordCounter.text = (x) + " / " + (numberOfImages - 1).ToString();
        SetCurrentQuestion ();
    }

    void Update()
    {
        Vector2 spriteTrueBoxCollider = spriteTrue.GetComponent<SpriteRenderer>().sprite.bounds.size;
        spriteTrue.GetComponent<BoxCollider2D>().size = spriteTrueBoxCollider;

        Vector2 spriteFalseBoxCollider = spriteFalse.GetComponent<SpriteRenderer>().sprite.bounds.size;
        spriteFalse.GetComponent<BoxCollider2D>().size = spriteFalseBoxCollider;
    }

	void SetCurrentQuestion()
	{
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<question>();
            unansweredfalseQuestions = falseQuestions.ToList<falseQuestion>();
        }

		int randomQuestionsIndex = Random.Range (0,unansweredQuestions.Count);
        int randomFalseQuestionsIndex = Random.Range (0,unansweredQuestions.Count);
		currentQuestion = unansweredQuestions [randomQuestionsIndex];
        currentfalseQuestion = unansweredfalseQuestions [randomFalseQuestionsIndex];

        spriteTrue.sprite = currentQuestion.image;
        spriteFalse.sprite = currentfalseQuestion.image2;
    }

	public void TranstionToNextQuestion()
	{
		unansweredQuestions.Remove (currentQuestion);
        unansweredfalseQuestions.Remove(currentfalseQuestion);
        x++;
      
        if (x >= numberOfImages)
        {
            disableFire();
            GameObject.Find("spriteTrue").SetActive(false);
            GameObject.Find("spriteFalse").SetActive(false);
            if (mistakesScore >= 3)
            {
                tryAgainPanel.SetActive(true);
            }
            else
            {
                finishMessage.SetActive(true);
                cannonBase.SetActive(false);
            }
        }
        else
        {
            wordCounter.text = (x) + " / " + (numberOfImages - 1).ToString();
            SetCurrentQuestion();
            randomOrder();
        }
    }

	public void userSelectTrue()
	{
        if (unansweredQuestions.Count >= 1)
        {
            TranstionToNextQuestion();
        }
    }

	public void userSelectFalse()
	{
        mistakesScore++;
        if (unansweredQuestions.Count >= 1)
        {
            TranstionToNextQuestion();
        }
    }

    public void randomOrder()
    {
        position = Random.Range(0, 2);
        if (position == 0)
        {
            spriteTrue.transform.position = waypoints[0].transform.position;
            spriteFalse.transform.position = waypoints[1].transform.position;
        }
        else if (position == 1)
        {
            spriteTrue.transform.position = waypoints[1].transform.position;
            spriteFalse.transform.position = waypoints[0].transform.position;
        }
    }

    public void enableFire()
    {
        cannon.GetComponent<BarrelScript>().enabled = true;
        cannon.GetComponent<RotateToMouse>().enabled = true;
    }

    public void disableFire()
    {
        var projectile = GameObject.FindGameObjectsWithTag("projectile");

        foreach (GameObject item  in projectile)
        {
            Destroy(item);
        }
                
        cannon.GetComponent<BarrelScript>().enabled = false;
        cannon.GetComponent<RotateToMouse>().enabled = false;
    }
}