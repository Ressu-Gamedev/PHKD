using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject credits;
    public bool notTitleScreen = false;
    public Animator menuController;
    public Animation startingUp;

    // Start is called before the first frame update
    void Start()
    {
        credits.SetActive(false);
    }
    public void StartPlayAnimation()
    {
        menuController.Play("StartingUpGame", 0);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {

        if(!notTitleScreen)
        {
            Application.Quit();
        }
        else
        {
            notTitleScreen = false;
            titleScreen.SetActive(true);
            credits.SetActive(false);
        }
    }
    public void Credits()
    {
        if (notTitleScreen)
        {
            notTitleScreen = false;
            titleScreen.SetActive(true);
            credits.SetActive(false);
        }

        else
        {
            notTitleScreen = true;
            titleScreen.SetActive(false);
            credits.SetActive(true);
        }
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
