using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] float damage = 50;
    [SerializeField] int rotateSpeed = -270;
  

	void Update ()
    {
        transform.position += (Vector3.right * projectileSpeed * Time.deltaTime);
        transform.Rotate(0,0,-rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Health health = otherCollider.GetComponent<Health>();
        Attacker attacker = otherCollider.GetComponent<Attacker>();

        if(attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }

    }
}
