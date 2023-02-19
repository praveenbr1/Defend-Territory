using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] AudioClip audioSource;
  
  
    private void Start() 
    {
      //  crab_Shooter = GetComponent<Crab_Shooter>();
      
      
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
           if(audioSource!= null)
            {
              AudioSource.PlayClipAtPoint(audioSource,transform.position,1f);
            }
            TriggerDeathVFX(); 
          //  FindObjectOfType<Crab_Shooter>().OnEnemyDestroy(gameObject);
            Destroy(gameObject);
        }
    }
    
    private void TriggerDeathVFX()
    {
        if(!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }
   

 
}
