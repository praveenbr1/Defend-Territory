using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Range (0f, 5f)]
    [SerializeField]
    float walkSpeed = 1f;
    GameObject currentTarget;
    
    
    Animator animator;
    Attacker attacker;
    delegate void CheckingNull();
    

 private void Awake() 
 {
   FindObjectOfType<LevelController>().AttackerSpawned();
    
 }
    private void Start() 
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
        
    }
	
	void Update () {
        transform.position += Vector3.left * walkSpeed * Time.deltaTime;
        Setting_AnimationState();
	}

    private void Setting_AnimationState()
    {
        if(!currentTarget)
        {
            animator.SetBool("Attack",false);
        }
    }

    public void SetMovementSpeed (float speed)
    {
        walkSpeed = speed;
    }
  
 

 public void StrikingTarget(GameObject target)
 {
    animator.SetBool("Attack",true);
    currentTarget = target;
}

public void Striking_And_DestroyingTarget(float damage)
{
    if(!currentTarget)return;
    Health health = currentTarget.GetComponent<Health>();
    if(health)
    {
        health.DealDamage(damage);
    }
}
   private void OnDestroy()
    {
    LevelController levelController = FindObjectOfType<LevelController>();
        if(levelController != null)
        levelController.AttackerKilled();
    }
     
   
}
