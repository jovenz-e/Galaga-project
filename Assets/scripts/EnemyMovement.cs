using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D enemyRb;

    public float speed = 5f;

    public float changeTime = 3;

    float timer;

    int direction = 1;

    public GameObject projcetilePrefab;

    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
      timer -= Time.deltaTime;

        if(timer < 0)
        {
          direction = -direction;
          
          timer = changeTime;
        }
        
    }
    void FixedUpdate()
    {
        Vector2 position = enemyRb.position;
	   
       position.x = position.x + speed * Time.deltaTime * direction;

       enemyRb.MovePosition(position);

       Launch();
    }
    void Launch()
    {
      // Spawn in a bullet and set it equal to a projectileObject variable
		GameObject projectileObject = Instantiate(projcetilePrefab, enemyRb.position + Vector2.down * 1.5f, Quaternion.identity);

		// Load the script from the spawned bullet
		Projectile projectile = projectileObject.GetComponent<Projectile>();

		// Call the Launch method from the Projectile script
		projectile.Launch(Vector2.down, 500);
  
    }
    // called when this object touches another object    
    void OnCollisionEnter2D(Collision2D other)
    {
    //GameObject enemyObject =  Instantiate(projcetilePrefab, enemyRb.position + Vector2.down, enemyPrefab.transform.rotation );
    }

}
