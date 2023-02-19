using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class ClickButtonSettings : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    Volume_Slider_Singleton volume_Slider_Singleton;
    Difficulty_Controller_Singleton difficulty_Controller_Singleton;
   
   [SerializeField] TextMeshProUGUI textMeshProUGUI;
   [SerializeField] TextMeshProUGUI[] menuOptions; 
  
   [SerializeField] GameObject backButton;
   [SerializeField] GameObject volumeSlider;
   [SerializeField] GameObject difficultySlider;
   [SerializeField] GameObject DefaultsButton;
   bool volumeButtonPressed;
   bool difficultyButtonPressed;

     Color hoverColor = Color.yellow;
     Color normalColor = Color.white;
     

   AudioSource audioSource;
   [SerializeField] AudioClip audioClip;

   [SerializeField] AudioClip menuScrollingSounds;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        volume_Slider_Singleton = FindObjectOfType<Volume_Slider_Singleton>();
        difficulty_Controller_Singleton = FindObjectOfType<Difficulty_Controller_Singleton>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && textMeshProUGUI.color == Color.yellow)
        {
            transform.DOScale(1.3f,0.5f).SetEase(Ease.OutBack).SetUpdate(UpdateType.Fixed).OnComplete(ResetScale);
            
            if(DefaultsButton && !backButton)
            {
                audioSource.PlayOneShot(audioClip,0.5f);
              
                volume_Slider_Singleton.ResetToDefault();
                difficulty_Controller_Singleton.ResetToDefault();
                
                
            }
      



else if(backButton && !DefaultsButton)
            {
                audioSource.PlayOneShot(audioClip,0.5f);
               if(DefaultsButton != null)
               {
                StartCoroutine(BackToMenu());
                return;
               }
                
            
            }
            audioSource.PlayOneShot(audioClip,0.5f);
        }
    }



  
    IEnumerator BackToMenu()
    {
        if(!DefaultsButton)
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(0);
    }

    private void ResetScale()
    {
        transform.DOScale(1f,0.5f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
         if(textMeshProUGUI.color == Color.white)
        {
            return;
        }
       else
        {
            audioSource.PlayOneShot(audioClip,0.5f);
            transform.DOScale(1.5f,0.5f).SetEase(Ease.OutBack).SetUpdate(UpdateType.Fixed).OnComplete(ResetScale);
        }
       
       
       
      
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
    }
    
}
    
