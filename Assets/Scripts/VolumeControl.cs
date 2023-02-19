using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
 {
   public static VolumeControl instance;

    public AudioSource audioSource;
    public float volume = 0.1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float newVolume)
    {
        volume = newVolume;
        audioSource.volume = volume;
    }



    // const string MASTER_VOLUME_KEY = "master volume";
    // const string DIFFICULTY_KEY = "difficulty";

    // const float MIN_VOLUME = 0f;
    // const float MAX_VOLUME = 1f;

    // public static void SetMasterVolume(float volume)
    // {
    //     if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
    //     {
    //         Debug.Log("Master volume set to " + volume);
    //         PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
    //     }
    //     else
    //     {
    //         Debug.LogError("Master volume is out of range");
    //     }
    // }

    // public static float GetMasterVolume()
    // {
    //     return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    // }
   
}


