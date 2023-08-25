using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public AudioManager audioManager;
    public AudioClip creditsSound;
    
    public Animator transition;
    public int sceneToLoad;

    public float transitionTime = 1f;

    void Awake()
    {
        audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
    }
    
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 3)
        {
            StartCoroutine(LoadGameDelayed(sceneToLoad));
        }
    }

    public void PlayGame()
    {
        StartCoroutine(LoadGame(sceneToLoad));

    }

    IEnumerator LoadGame(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadGameDelayed(int levelIndex)
    {
        audioManager.musicSource.clip = creditsSound;
        
        yield return new WaitForSeconds(6f);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
