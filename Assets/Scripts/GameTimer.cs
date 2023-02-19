using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")]
    [SerializeField] float levelTime = 10;

     [SerializeField] Slider spawnLimitSlider;

     [SerializeField] LevelController levelController;
    bool timeOut = false;
    Animator animator;
    private void Start() 
    {
        animator = GetComponent<Animator>();
        spawnLimitSlider = GetComponent<Slider>();
        levelController = FindObjectOfType<LevelController>();
    }

	// Update is called once per frame
	void Update () {
        if(timeOut) return;
        spawnLimitSlider.value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            levelController.LevelTimerFinished();
            timeOut = true;
            animator.SetBool("TimerEnd",true);
        }
	}
}
