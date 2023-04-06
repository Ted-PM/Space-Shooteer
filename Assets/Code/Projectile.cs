using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    int damageToGive = 1;
    GameObject firingShip;

    public void SetFiringShip(GameObject firer)
    {
        firingShip = firer;

    }

    private void OnTriggerEnter2D(Collider2D collision) // when to objects collide
    {
        Ship otherObject = collision.GetComponent<Ship>(); // take ship component of collision (finds ship which made projectile)

        BeeBox otherObject2 = collision.GetComponent<BeeBox>();

        if (otherObject && collision.gameObject != firingShip) // if it is a ship and not the ship that shot
        {
            otherObject.TakeDamage(damageToGive); // other object (Ship from L17) takes damage

            Destroy(gameObject); // destroy itself
        }
        if(otherObject2 != null)
        {
            otherObject2.TakeDamage(damageToGive);
            Destroy(gameObject);
        }
        
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
