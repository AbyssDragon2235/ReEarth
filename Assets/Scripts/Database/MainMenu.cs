using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_Text playerDisplay;
    
    private void Start()
    {
        if(DBManager.LoggedIn)
        {
            playerDisplay.text = "Player: " + DBManager.username;
        }
    }
    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(3);
    }
    public void GoToLogin()
    {
        SceneManager.LoadScene(2);
    }
}
