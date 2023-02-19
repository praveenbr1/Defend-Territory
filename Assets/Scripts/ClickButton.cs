using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class ClickButton : MonoBehaviour ,IPointerClickHandler,
   IPointerEnterHandler, IPointerExitHandler
{
   [SerializeField] TextMeshProUGUI textMeshProUGUI;
    
    [SerializeField] TextMeshProUGUI[] menuOptions; 
     AudioSource audioSource;

     [SerializeField] AudioClip menuScrollingSounds;
     [SerializeField] AudioClip buttonClickSounds;
     Color hoverColor = Color.blue;
     Color normalColor = Color.white;
     [SerializeField] GameObject quitButton;
     [SerializeField] GameObject settingsButton;
     
     int currentSceneIndex;
    
    private void Start()
     {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        audioSource = GetComponent<AudioSource>();
    }
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)&& textMeshProUGUI.color == Color.blue )
        {
            transform.DOScale(1.5f, 0.5f).SetEase(Ease.OutBack).SetUpdate(UpdateType.Fixed).OnComplete(ResetScale);
            if(!quitButton && !settingsButton)
            {
                audioSource.PlayOneShot(buttonClickSounds,1f);
                PlayingGame();
            }
            else if(settingsButton)
            {
                audioSource.PlayOneShot(buttonClickSounds,0.5f);
                StartCoroutine(SettingsButton());
            }
            
        }
    }

    IEnumerator SettingsButton()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("Settings");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(textMeshProUGUI.color == Color.white)
        {
            return;
        }
      else  if(!quitButton && !settingsButton)
        {
            audioSource.PlayOneShot(buttonClickSounds,1f);
        }
    
       else if(settingsButton)
       {
        audioSource.PlayOneShot(buttonClickSounds,0.5f);
       }
          transform.DOScale(1.5f,0.5f).SetEase(Ease.OutBack).SetUpdate(UpdateType.Fixed).OnComplete(ResetScale);
    }
      public void PlayingGame()
      {
           StartCoroutine(PlayGame());
      }
     IEnumerator PlayGame()
    {   
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level 1");
        
    }

    public void ResetScale()
    {
        transform.DOScale(1f,0.5f);
    }


    

    public void OnPointerEnter(PointerEventData eventData)
    {
        textMeshProUGUI.color = hoverColor;
        
        audioSource.PlayOneShot(menuScrollingSounds,1);
        for (int i = 0; i < menuOptions.Length; i++)
        {
            menuOptions[i].transform.localScale = new Vector3(1.2f,1.2f,1.2f);
            if (menuOptions[i] != this.textMeshProUGUI)
            {
                menuOptions[i].color = normalColor;
                menuOptions[i].transform.localScale = new Vector3(1f,1f,1f);
                
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    { 
        textMeshProUGUI.color = normalColor;
        textMeshProUGUI.transform.localScale = new Vector3(1f,1f,1f);
        
    }
}


    
    

