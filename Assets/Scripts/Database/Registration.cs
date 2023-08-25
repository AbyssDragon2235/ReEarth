using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

public class Registration : MonoBehaviour
{
    public TMPro.TMP_InputField nameField;
    public TMP_InputField passwordField;

    public TMP_Text outputText;

    public Button submitButton;

    //readonly string getURL = "https://undeved.com/reearth/php/register.php";
    //readonly string postURL = "URLplaceholder";

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        outputText.text = "Loading...";
        UnityWebRequest request = UnityWebRequest.Get("https://undeved.com/reearth/php/register.php");
        
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                outputText.text = request.error;
            else{
                outputText.text = request.downloadHandler.text;
                Debug.Log("se conecto al php");
                StartCoroutine(PostRegistration());
            }
                //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        
    }

    IEnumerator PostRegistration()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        
        outputText.text = " Upload Loading...";
        UnityWebRequest request = UnityWebRequest.Post("https://undeved.com/ReEarth/PHP/register.php", form);
        
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                outputText.text = request.error;
                Debug.Log(request.error);
            }else{
                outputText.text = request.downloadHandler.text;
                Debug.Log("se subio la info");
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
    }

    // public void VerifyInputs(){
    //     submitButton.interactable = (nameField.text.Lenght <= 16 && passwordField.text.Length >= 8 
    //         && !(nameField.text.Contains("á"))
    //         && !(nameField.text.Contains("é"))
    //         && !(nameField.text.Contains("í"))
    //         && !(nameField.text.Contains("ó"))
    //         && !(nameField.text.Contains("ú"))
    //         && !(nameField.text.Contains("ñ"))
    //         && !(passwordField.text.Contains("á"))
    //         && !(passwordField.text.Contains("é"))
    //         && !(passwordField.text.Contains("í"))
    //         && !(passwordField.text.Contains("ó"))
    //         && !(passwordField.text.Contains("ú"))
    //         && !(passwordField.text.Contains("ñ")));
    // }
}
