using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
  
  int currentSceneIndex = 0;
 // AudioSource audioSource;

//   private void Awake()
  
//    {
//          int numberOfThings = FindObjectsOfType<LoadScenes>().Length;
//          if(numberOfThings > 1)
//          {
//             gameObject.SetActive(false);
//             Destroy(gameObject);
//          }
//          else
//          {
//                DontDestroyOnLoad(gameObject);
//          }
//   }


//   public void MusicPlayer()
//   {
//     audioSource = GetComponent<AudioSource>();
//   }
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void BackButton()
    {
        StartCoroutine(BackButtonPressed());
    }

    public void SettingsButton()
    {
        StartCoroutine(SettingsButtonPressed());
    }

    IEnumerator SettingsButtonPressed()
    {
       yield return new WaitForSeconds(1f);
       SceneManager.LoadScene("Settings");
    }

    IEnumerator BackButtonPressed()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Start Screen");
    }

    public void QuitGame()
    {
        StartCoroutine(QuitIt());
        
    }

    IEnumerator QuitIt()
    {
       yield return new WaitForSecondsRealtime(1f);
       Application.Quit();

    }
}
