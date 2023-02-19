using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    Lifes_Of_Player lifes_Of_Player_Script;
    [SerializeField] private Image image;
    [SerializeField] private Sprite pressedButoon,unpressedButton;
     [SerializeField] AudioClip compressClip,uncompressClip;
   
     AudioSource audioSource;
     [SerializeField] GameObject retryButton;
     [SerializeField] GameObject menuButton;
     [SerializeField] GameObject playButton;
     [SerializeField] GameObject levelCanvas;
     [SerializeField] float waitTime = 1f;
     int currentSceneIndex;
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        audioSource = GetComponent<AudioSource>();
        lifes_Of_Player_Script = FindObjectOfType<Lifes_Of_Player>();
    }
   
    public void OnPointerDown(PointerEventData eventData)
    {
        image.sprite = pressedButoon;
        audioSource.PlayOneShot(compressClip);
        if(retryButton && retryButton != null)
        {
            
            StartCoroutine(RetryButtonPressed());
        }
        else if(menuButton && menuButton != null)
        {
            
            StartCoroutine(MenuButtonPressed());
           
        }
        else if (playButton && playButton != null)
        {
           
           StartCoroutine(PauseButtonPressed());
            
            Debug.Log("Pause key is pressed");
        }
     
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        image.sprite = unpressedButton;
        audioSource.PlayOneShot(uncompressClip);
    }

IEnumerator RetryButtonPressed()
{
     yield return new WaitForSecondsRealtime(waitTime);
     SceneManager.LoadScene(currentSceneIndex);
     Time.timeScale = 1f;
 
}
IEnumerator MenuButtonPressed()
{
    yield return new WaitForSecondsRealtime(waitTime);
    SceneManager.LoadScene("Start Screen");
    Time.timeScale = 1f;
}
IEnumerator PauseButtonPressed()
{
    yield return new WaitForSecondsRealtime(waitTime);
    levelCanvas.SetActive(false);
    Time.timeScale = 1f;
    lifes_Of_Player_Script.Escape_Key_Pressed = false;
    
    
   
    
}
}
