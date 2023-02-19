using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class GearIcon : MonoBehaviour,IPointerClickHandler
{
     Volume_Slider_Singleton volume_Slider_Singleton;
  [SerializeField] Button audioButton;
   
    [SerializeField] Button vibrateButton;

    [SerializeField] GameObject volumeSlider;

    RectTransform audioButtonRect;
    RectTransform vibrateButtonRect;
    [SerializeField] float gearRotateAngle = 180f;
    [SerializeField] float duration = 4;
    [SerializeField] float delay = 0.5f;
    [SerializeField] float destinationX = -650;
    [SerializeField] float originalPositionX = -1020;

    bool hasClicked = false;

    private void Start()
    {
        volume_Slider_Singleton = FindObjectOfType<Volume_Slider_Singleton>();
        audioButtonRect = audioButton.GetComponent<RectTransform>();
        vibrateButtonRect = vibrateButton.GetComponent<RectTransform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!hasClicked)
        {
            
            MoveButtonsIn();
            RotateGearIn();
        }
        else
        {
            
            MoveButtonsOut();
            RotateGearOut();
        }
    }

    private void MoveButtonsOut()
    {
        VolumeSliderActivation();
        audioButtonRect.DOAnchorPosX(originalPositionX, duration).SetEase(Ease.OutBack).SetUpdate(UpdateType.Manual);
        vibrateButtonRect.DOAnchorPosX(originalPositionX, duration).SetEase(Ease.OutBack).SetDelay(delay).SetUpdate(UpdateType.Manual);
        hasClicked = false;
    }

    public void VolumeSliderActivation()
    {
        volumeSlider.SetActive(false);
        volume_Slider_Singleton.Has_Clicked = false;
    }

    private void MoveButtonsIn()
    {
        audioButtonRect.DOAnchorPosX(destinationX, duration).SetEase(Ease.OutBack).SetUpdate(UpdateType.Manual);
        vibrateButtonRect.DOAnchorPosX(destinationX, duration).SetEase(Ease.OutBack).SetDelay(delay).SetUpdate(UpdateType.Manual);
        hasClicked = true;
    }
   private void RotateGearIn()
   {
     transform.DORotate(new Vector3(0f,0f,-gearRotateAngle),0.5f).SetUpdate(UpdateType.Manual);

   }
   private void RotateGearOut()
   {
     transform.DORotate(new Vector3(0f,0f,0f),0.5f).SetUpdate(UpdateType.Manual);

   }
    private void Update()
    {
          
    {
         DOTween.ManualUpdate(Time.unscaledDeltaTime, Time.unscaledDeltaTime);
        
    }
    }

    
}

