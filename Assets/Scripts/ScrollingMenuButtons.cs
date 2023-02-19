using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScrollingMenuButtons : MonoBehaviour
{
   //Here this below menuOptionsColorTest is used as a condition to check whether the text color is yellow or blue ,so that we can animate according to our text color in Scenes.. For further reference see the code..
    [SerializeField] GameObject menuOptionsColorTest_ColorYellow;
    [SerializeField] TextMeshProUGUI[] menuOptions; // array of TMP_Text objects representing menu options
    private int index = 0; // variable to keep track of the current menu option
    private bool keyDown; // flag to control user input

    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        
    }
    void Update ()
     {
		if(Input.GetAxis ("Vertical") != 0){
			if(!keyDown){
				if (Input.GetAxis ("Vertical") < 0) {
					if(index < menuOptions.Length - 1){
						index++;
					}else{
						index = 0;
					}
				} else if(Input.GetAxis ("Vertical") > 0){
					if(index > 0){
						index --; 
					}else{
						index = menuOptions.Length - 1;
					}
				}
				keyDown = true;
                audioSource.Play();
                
			}
		      for (int i = 0; i < menuOptions.Length; i++)
            {
                if (i == index)
                {
                    if(menuOptionsColorTest_ColorYellow)
                   { 
                    menuOptions[i].color = Color.yellow;
                    menuOptions[i].transform.localScale = new Vector3(1.2f,1.2f,1.2f);
                   }
                   else if(!menuOptionsColorTest_ColorYellow)
                   {
                    menuOptions[i].color = Color.blue;
                    menuOptions[i].transform.localScale = new Vector3(1.2f,1.2f,1.2f);
                   }

                }
                else
                {
                    menuOptions[i].color = Color.white;
                    menuOptions[i].transform.localScale = new Vector3(1f,1f,1f);
                   
                }
            }
        
        }else{
			keyDown = false;
		}
	}
   
    
}


