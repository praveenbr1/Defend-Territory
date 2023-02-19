using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty_Controller_Singleton : MonoBehaviour
{
    float defaultDifficulty;

    [SerializeField] Slider difficultySlider;
    void Start()
    {
        difficultySlider.value = Difficulty_Controller.instance.difficultySetting;
    }
  
  public void OnValueChanged()
  {
    Difficulty_Controller.instance.SetDifficulty(difficultySlider.value);
  }

  public void ResetToDefault()
  {
     difficultySlider.value = defaultDifficulty;
     Difficulty_Controller.instance.SetDifficulty(difficultySlider.value);
     PlayerPrefs.SetFloat("Difficulty",defaultDifficulty);
  }

    
   
  //   [SerializeField] Slider difficultySlider;
  //   [SerializeField] float defaultDifficulty = 0f;

  //   // Use this for initialization
  //   void Start ()
  //   {
       
  //       difficultySlider.value = Difficulty_Controller.GetDifficulty();
  //   }

  //   // Update is called once per frame
  //   void Update ()
  //   {
     
	// }

  //   public void SaveAndExit()
  //   {
      
  //       Difficulty_Controller.SetDifficulty(difficultySlider.value);
        
  //   }

  //   public void SetDefaults()
  //   {
        
  //       difficultySlider.value = defaultDifficulty;
  //   }
}
