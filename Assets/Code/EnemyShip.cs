using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship
{
    
    private Transform target; // transform is variable tag: size, position rotation
    public bool canFireAtPlayer;

    public float thrustRate;
    public bool quickThrust;

    Color colorRed = new Color(1.0f, 0.0f, 0.0f, 1.0f);

    Color colorGreen = new Color(0.0f, 1.0f, 0.5f, 1.0f);


    void Start()
    {
        target = FindObjectOfType<PlayerShip>().transform; // finds PlayerShip, x y
   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            

        if (collision.gameObject.GetComponent<PlayerShip>() && canFire)
        {  
            collision.gameObject.GetComponent<PlayerShip>().TakeDamage(1);
            Expload();
            target.GetComponent<SpriteRenderer>().color = colorGreen;
        }
    }

    IEnumerator ThrustBuffer()
    {
        yield return new WaitForSeconds(thrustRate); 
        quickThrust = false; 
        target.GetComponent<SpriteRenderer>().color = colorRed;
    }

    void FlyToPlayer()
    {

        Vector2 directionToFace = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y); // creates vector between EnemyShip and PlayerShip

        transform.up = directionToFace; // makes Enemy Face Player

        if (!quickThrust)
        {
            Thrust();
        }
        else
        {
            StartCoroutine(ThrustBuffer());
        }
         // Activates thrust function (in Ship)

    }



    void Update()
    {

        FlyToPlayer();
        target.GetComponent<SpriteRenderer>().color = colorGreen;


        if (canFireAtPlayer)
        {
            FireProjectile();
        }

       
    }

   
}
