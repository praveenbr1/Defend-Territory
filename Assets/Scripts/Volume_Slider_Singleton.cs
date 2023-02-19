using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Volume_Slider_Singleton : MonoBehaviour
{
  float defaultVolume = 0.1f;
  float vibrate = 0f;
 
  bool hasClicked;
  bool vibrateButtonClikced;
   static float temp;
  public Slider volumeSlider;

 public bool Has_Clicked
 {
    get {return hasClicked;}
    set{ hasClicked = value;}

 }

private void Start()
{
    volumeSlider.value = VolumeControl.instance.volume;
}

public void OnValueChanged()
{
    VolumeControl.instance.SetVolume(volumeSlider.value);
}
   public void ResetToDefault()
    {
      
        volumeSlider.value = defaultVolume;
        VolumeControl.instance.SetVolume(volumeSlider.value);
        PlayerPrefs.SetFloat("Volume", defaultVolume);
       
    }
    public void Vibrate()
    {
       if(!vibrateButtonClikced)
       {
       
         temp = volumeSlider.value;
         volumeSlider.value = vibrate;
        VolumeControl.instance.SetVolume(volumeSlider.value);
        PlayerPrefs.SetFloat("Volume",vibrate);
        vibrateButtonClikced = true;
       }
       else
       {
       
        volumeSlider.value = temp;
        VolumeControl.instance.SetVolume(volumeSlider.value);
        PlayerPrefs.SetFloat("Volume",temp);
        vibrateButtonClikced = false;
       }
       
    }

    public void VolumeButtonPressedCheck()
    {
        if(!hasClicked)
        {
            volumeSlider.gameObject.SetActive(true);
            hasClicked = true;
        }
        else  if(hasClicked)
        {
            volumeSlider.gameObject.SetActive(false);
            hasClicked = false;
        }

      
    } 

  

    
    //   [SerializeField] Slider volumeSlider;
    //     [SerializeField] float defaultVolume = 0.8f;

    // 	// Use this for initialization
    // 	void Start ()
    //     {
    //         volumeSlider.value = VolumeControl.GetMasterVolume();
    // 	}

    // 	// Update is called once per frame
    // 	void Update ()
    //     {
    //         var musicPlayer = FindObjectOfType<MusicPlayer>();
    //         if (musicPlayer)
    //         {
    //             musicPlayer.SetVolume(volumeSlider.value);
    //         }
    //         else
    //         {
    //             Debug.LogWarning("No music player found... did you start from splash screen?");
    //         }
    // 	}

    //     public void SaveAndExit()
    //     {
    //         VolumeControl.SetMasterVolume(volumeSlider.value);
    //       //  FindObjectOfType<LevelLoader>().LoadMainMenu();
    //     }

    //     public void SetDefaults()
    //     {
    //         volumeSlider.value = defaultVolume;
    //     }

}
