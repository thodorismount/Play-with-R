using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class imagesManager : MonoBehaviour {

	public question[] questions;
	public static List<question> unansweredQuestions;

    public falseQuestion[] falseQuestions;
    public static List<falseQuestion> unansweredfalseQuestions;

    public static int x = 0;
    public static int position;
    private question currentQuestion;
    private falseQuestion currentfalseQuestion;
    public GameObject dice;

    [SerializeField]
    private Image imageComp;

    [SerializeField]
    private Image imageComp2;

    [SerializeField]
	private float timeBetweenQuestions = 1.0f ;
    
    void Start()
	{
        randomOrder();
		unansweredQuestions = questions.ToList<question> ();
        unansweredfalseQuestions = falseQuestions.ToList<falseQuestion>();

        x++;
        SetCurrentQuestion ();
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

        imageComp.sprite= currentQuestion.image;
        imageComp2.sprite = currentfalseQuestion.image2;        
    }

	void TranstionToNextQuestion()
	{        
        unansweredQuestions.Remove (currentQuestion);
        unansweredfalseQuestions.Remove(currentfalseQuestion);
        SetCurrentQuestion();
        randomOrderAfterAnswer();
        randomOrder();
    }

	public void userSelectTrue()
	{
        if (unansweredQuestions.Count >= 1)
        {
            TranstionToNextQuestion();
            dice.SetActive(true);
            GameObject.Find("Image1").SetActive(false);
            GameObject.Find("Image2").SetActive(false);
        }
    }

	public void userSelectFalse()
	{
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
            imageComp.transform.SetParent(GameObject.FindGameObjectWithTag("Panel").transform, false);
            imageComp2.transform.SetParent(GameObject.FindGameObjectWithTag("Panel").transform, false);
        }
        else if (position == 1)
        {
            imageComp2.transform.SetParent(GameObject.FindGameObjectWithTag("Panel").transform, false);
            imageComp.transform.SetParent(GameObject.FindGameObjectWithTag("Panel").transform, false);
        }
    }

    public void randomOrderAfterAnswer()
    {
        imageComp.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        imageComp2.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
    }
}