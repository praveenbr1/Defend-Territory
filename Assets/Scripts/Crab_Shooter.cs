using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab_Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    Animator animator;
    [SerializeField] List<GameObject> enemies;
    
    
     void Start()
    {
       animator = GetComponent<Animator>();
       enemies = new List<GameObject>(enemies); 
    }

    // Update is called once per frame
    void Update()
    {
        //bool enemyInLane = false;
        foreach(GameObject enemy in enemies)
        {
            if(Mathf.Abs(enemy.transform.position.y - transform.position.y) <= Mathf.Epsilon)
            {
                  bool enemyInLane = true;
                  animator.SetBool("Attack",enemyInLane);
                  break;
            
            }
        }
        
        
    }

   public void OnEnemyDestroy(GameObject enemy)
    {
        enemies.Remove(enemy);

        if(enemies.Count == 0)
        {
            animator.SetBool("Attack",false);
        }
    }
    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
}
