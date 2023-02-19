using DG.Tweening;
using UnityEngine;

public class ShakeObject : MonoBehaviour
{
    [SerializeField] float duration = 0.5f;
    [SerializeField] float strength = 0.1f;
    [SerializeField] int vibrate = 10;
    [SerializeField] float randomness = 90f;
    [SerializeField] bool fadeOut = true;
    [SerializeField] bool snapping = true; 
    private RectTransform rectTransform; 
  
   private void Awake() 
   {
      rectTransform = GetComponent<RectTransform>();
   }
    public void Shake()
    {
        rectTransform.DOShakePosition(duration, strength, vibrate, randomness, snapping, fadeOut).SetUpdate(UpdateType.Manual);
    }

    private void Update() 
    {
        DOTween.ManualUpdate(Time.unscaledDeltaTime,Time.unscaledDeltaTime);
    }
}
