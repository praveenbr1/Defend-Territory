using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.UI;

public class Lifes_Of_Player : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] int playerLife;
    
    float currentLife;
   
   [SerializeField] int damageAmount;
   [SerializeField] GameObject looseScreenCanvas;
   
   [SerializeField] GameObject pauseButton;
   [SerializeField] GameObject retryButton;
   [SerializeField] Collider2D colliderTest;

   Pause_Button_Animation pause_Button_Animation;

   bool escapeKeyPressed = false;

   public bool Escape_Key_Pressed
   {
       get{return escapeKeyPressed;}
       set{escapeKeyPressed = value;}
   }

 private void Awake() 
 {
    looseScreenCanvas.SetActive(false);
   
    pause_Button_Animation = GetComponent<Pause_Button_Animation>();
 }
    
   
    private void Start()
    {
       
        currentLife = playerLife - Difficulty_Controller.instance.difficultySetting;
        
        //pauseButton.onClick.AddListener(HandlePauseButtonClick);
         
    }

    // public void HandlePauseButtonClick()
    // {
    //    if(isPaused)
    //    {
    //      ResumeGame();
    //    }
    //    else
    //    {
    //      PauseGame();
    //    }
    // }

    // private void PauseGame()
    // {
    //     isPaused = true;
    //     Time.timeScale = 0f;
    //     pauseButton.enabled = false;
    //     looseScreenCanvas.SetActive(false);
    // }

    // private void ResumeGame()
    // {
    //     isPaused = false;
    //     Time.timeScale = 1f;
    //     pauseButton.enabled = true;
    //     looseScreenCanvas.SetActive(true);

    // }

    private void Update()
    {
        textMeshPro.text = currentLife.ToString();
        // if(Input.GetKeyDown(KeyCode.Escape))
        // {
        //     HandlePauseButtonClick();
        // }
        
        
      {
       if(Input.GetKeyDown(KeyCode.Escape) && currentLife > 0 && !escapeKeyPressed)
            {
                pause_Button_Animation.OnPressed();
               StartCoroutine(EscapeKeyPressed());   

            }
            else if(Input.GetKeyDown(KeyCode.Escape) && currentLife > 0 && escapeKeyPressed)
            {   
                pause_Button_Animation.OnpressedTwice();
              StartCoroutine(EscapeKeyPressedTwice());
            }
        }
       { if(currentLife <= 0)
        {
            pauseButton.SetActive(false);
            looseScreenCanvas.SetActive(true);
        }
        else if(currentLife > 0)
        {
            colliderTest.enabled = true;
        }
       }
    }

    IEnumerator EscapeKeyPressed()
    {  
         Time.timeScale = 0f;
        looseScreenCanvas.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        escapeKeyPressed = true;
        
      
        
    }

    IEnumerator EscapeKeyPressedTwice()
    {
         yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
        escapeKeyPressed = false;
        looseScreenCanvas.SetActive(false);
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
         TakeDamage(other);
         Destroy(other.gameObject,2f);

        // textMeshPro.text = currentLife.ToString();
        if(currentLife == 0)
        {
            
            Time.timeScale = 0f;
            colliderTest.enabled = false;
        }
         

        
    }

    private void TakeDamage(Collider2D other)
    {
        currentLife -=damageAmount;
        
    }

}
