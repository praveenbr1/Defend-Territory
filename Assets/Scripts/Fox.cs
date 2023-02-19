 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if(otherObject.GetComponent<Block>())
        {
            GetComponent<Animator>().SetTrigger("isJumping");
        }

        else if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().StrikingTarget(otherObject);
        }
    }

}
   

