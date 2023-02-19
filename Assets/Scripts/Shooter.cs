using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;
      GameObject projectiles;
    const string PROJECTILE_PARENT_NAME = "Projectiles";
   
    private void Start()
    {
        CreateProjectile();
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }
       private void CreateProjectile()
    {
        projectiles = GameObject.Find(PROJECTILE_PARENT_NAME);
          if(!projectiles)
          {
            projectiles = new GameObject(PROJECTILE_PARENT_NAME);
          } 
    }

    private void Update()
    {
        if(IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = 
                (Mathf.Abs(spawner.transform.position.y - transform.position.y) 
                <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire()
    {
       GameObject instansiateProjectile = Instantiate(projectile, gun.transform.position, transform.rotation) as GameObject;
       instansiateProjectile.transform.parent = projectiles.transform;
    }
    

}
