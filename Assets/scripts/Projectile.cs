using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D projectileRb;


    void Awake()
    {
        projectileRb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        // Destroy bullet if it passes outside the screen
        if(transform.position.magnitude > 10.0f)
	  {
	      Destroy(gameObject);
	  }
    }

    public void Launch(Vector2 direction, float force)
    {
        // Use the bullet's rigidbody to add force to the bullet
        projectileRb.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
{
	// Destroy what the bullet collides with
	Destroy(other.gameObject);
	
	// Destroy the bullet itself
	Destroy(gameObject);
}

}

