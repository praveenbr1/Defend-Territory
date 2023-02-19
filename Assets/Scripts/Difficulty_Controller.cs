using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty_Controller : MonoBehaviour
{
    public static Difficulty_Controller instance;
     public float difficultySetting = 0;

    private void Awake() 
    {
        if(instance == null)
      
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            
        }

        else
        {
            Destroy(gameObject);
        }
    }
    public void SetDifficulty(float newDifficulty)
    {
        difficultySetting = newDifficulty;

    }

     
    // const string DIFFICULTY_KEY = "difficulty";

    // const float MIN_DIFFICULTY = 0f;
    // const float MAX_DIFFICULTY = 2f;

    

   

    // public static void SetDifficulty(float difficulty)
    // {
    //     if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
    //     {
    //         PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
    //     }
    //     else
    //     {
    //         Debug.LogError("Difficulty setting is not in range");
    //     }
    // }

    // public static float GetDifficulty()
    // {
    //     return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    // }
}
