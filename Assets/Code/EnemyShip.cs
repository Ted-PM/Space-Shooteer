using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship
{
    
    private Transform target; // transform is variable tag: size, position rotation
    public bool canFireAtPlayer;

    void Start()
    {
        target = FindObjectOfType<PlayerShip>().transform; // finds PlayerShip, x y
        

    }

     void FlyToPlayer()
    {

        Vector2 directionToFace = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y); // creates vector between EnemyShip and PlayerShip

        transform.up = directionToFace; // makes Enemy Face Player
        Thrust(); // Activates thrust function (in Ship)

    }
    
    void Update()
    {

        FlyToPlayer();

        if (canFireAtPlayer)
        {
            FireProjectile();
        }





  

       
    }

   
}
