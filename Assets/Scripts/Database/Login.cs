using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

public class Login : MonoBehaviour
{
    public TMPro.TMP_InputField nameField;
    public TMP_InputField passwordField;

    public TMP_Text outputText;

    public Button submitButton;

    //readonly string getURL = "https://undeved.com/reearth/php/register.php";
    //readonly string postURL = "URLplaceholder";

    public void CallLogin()
    {
        StartCoroutine(LoginRequest());
    }

    IEnumerator LoginRequest()
    {
        outputText.text = "Loading...";
        UnityWebRequest request = UnityWebRequest.Get("https://undeved.com/reearth/php/login.php");
        
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                outputText.text = request.error;
            else{
                outputText.text = request.downloadHandler.text;
                Debug.Log("se conecto al php");
                StartCoroutine(PostLogin());
            }
                //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        
    }

    IEnumerator PostLogin()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        
        outputText.text = " Upload Loading...";
        UnityWebRequest request = UnityWebRequest.Post("https://undeved.com/ReEarth/PHP/login.php", form);
        
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                outputText.text = request.error;
                Debug.Log(request.error);
            }else{
                outputText.text = request.downloadHandler.text;
                Debug.Log("se subio la info");
                DBManager.username = nameField.text;
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
    }}