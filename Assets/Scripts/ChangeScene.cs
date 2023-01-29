using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject howToPlayMenu;
    public GameObject thisPage;
    public GameObject nextPage;

    public void ChangeToScene(string s)
    {
        SceneManager.LoadScene(s);
    }

    public void OpenHowToPlayMenu()
    {
        howToPlayMenu.SetActive(true);
    }

    public void CloseHowToPlayMenu()
    {
        howToPlayMenu.SetActive(false);
    }

    public void GoToNextPage()
    {
        nextPage.SetActive(true);
        thisPage.SetActive(false);
    }
}
