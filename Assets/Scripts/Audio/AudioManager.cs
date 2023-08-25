using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip creditsSound;
    public AudioClip mainMenuBG;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.buildIndex == 3 && instance != null)
        {
            Destroy(instance);
            }else
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else{
            Destroy(gameObject);
        }}

    public void Start()
    {
        musicSource.clip = mainMenuBG;
        musicSource.Play();
    }

}
