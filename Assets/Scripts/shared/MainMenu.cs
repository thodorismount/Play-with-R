using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    
    public void goToMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void goToSlide()
    {
        SceneManager.LoadScene("slideEpiloghEpipedou");
    }

    public void goToSlide1()
    {
        SceneManager.LoadScene("slide1");
    }

    public void goToSlide2()
    {
        SceneManager.LoadScene("slide2");
    }

    public void goToSlide3()
    {
        SceneManager.LoadScene("slide3");
    }

    public void goToSlide4()
    {
        SceneManager.LoadScene("slide4");
    }

    public void goToKatatmhsh()
    {
        SceneManager.LoadScene("katatmhshScene");
    }

    public void goToSnake()
    {
        SceneManager.LoadScene("snakeScene");
    }
    public void goToCannon()
    {
        SceneManager.LoadScene("cannonScene");
    }

    public void reloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }    

    public void QuitGame()
    {
        Application.Quit();
    }        
}