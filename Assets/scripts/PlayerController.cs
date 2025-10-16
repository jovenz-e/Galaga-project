using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D  rb;

    private Vector2 movementInput;

    public float moveSpeed = 5f;

    public GameObject projcetilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        
        movementInput = new Vector2(moveX,0).normalized;

         if(Input.GetKeyDown(KeyCode.Space))
    {
        Launch();  
    }

    }
    void FixedUpdate()
    {
        rb.velocity = movementInput * moveSpeed;
    }

    void Launch()
    {
      // Spawn in a bullet and set it equal to a projectileObject variable
		GameObject projectileObject = Instantiate(projcetilePrefab, rb.position + Vector2.up * 1.5f, Quaternion.identity);

		// Load the script from the spawned bullet
		Projectile projectile = projectileObject.GetComponent<Projectile>();

		// Call the Launch method from the Projectile script
		projectile.Launch(Vector2.up, 500);
    }
}