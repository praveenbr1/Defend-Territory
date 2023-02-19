using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Pause_Button_Animation : MonoBehaviour
{
   [SerializeField] Button retryButton;
   [SerializeField] Button pauseButton;
   [SerializeField] Button menuButton;

   Transform retryTransform;
   Transform pauseTransform;
   Transform menuTransform;
   private Vector3 retryInitialScale;
   private Vector3 pauseInitialScale;
   private Vector3 menuInitialScale;


   private void Start() 
   {
      retryTransform = retryButton.GetComponent<Transform>();
      retryInitialScale = retryTransform.localScale;

      pauseTransform = pauseButton.GetComponent<Transform>();
      pauseInitialScale = pauseTransform.localScale;

      menuTransform = menuButton.GetComponent<Transform>();
      menuInitialScale = menuTransform.localScale;
   }


   public void OnPressed()
   {
    retryTransform.DOScale(retryInitialScale,2f).SetEase(Ease.OutBack).SetUpdate(UpdateType.Manual);
    pauseTransform.DOScale(pauseInitialScale,2f).SetEase(Ease.OutBack).SetDelay(0.5f).SetUpdate(UpdateType.Manual);
    menuTransform.DOScale(menuInitialScale,2f).SetEase(Ease.OutBack).SetDelay(1f).SetUpdate(UpdateType.Manual);

   }

   public void OnpressedTwice()
   {
          retryTransform.DOScale(retryInitialScale * 0f,2f).SetUpdate(UpdateType.Manual);
          pauseTransform.DOScale(pauseInitialScale * 0f,2f).SetDelay(0.5f).SetUpdate(UpdateType.Manual);
          menuTransform.DOScale(menuInitialScale * 0f,2f).SetDelay(1f).SetUpdate(UpdateType.Manual);
   }

  

   private void Update() 
   {  
        DOTween.ManualUpdate(Time.unscaledDeltaTime, Time.unscaledDeltaTime);
   }

}
