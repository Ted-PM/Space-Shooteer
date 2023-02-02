using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ship : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public GameObject projectilePrefab;
    public GameObject projectileSpawnPoint;
    public GameObject explosionPrefab;
    public float acceleration;
    public float maxSpeed;
    public int maxArmor;
    public float fireRate;
    public float projectileSpeed;
    [HideInInspector] public float currentSpeed;
    [HideInInspector] public int currentArmor;
    protected bool canFire;

    private void Awake()
    {
        currentArmor = maxArmor;
        canFire = true;
    }

    IEnumerator FireRateBuffer()
    {
        canFire = false; // disables projectiles
        yield return new WaitForSeconds(fireRate); // waits before can fire again
        canFire = true; // can fire again
    }


    public void Thrust()
    {
        myRigidbody2D.AddForce(transform.up * acceleration); // adds force to ship
    }

    private void Update()
    {
        if (myRigidbody2D.velocity.magnitude > maxSpeed) // checks if ship faster than max speed
        {
            myRigidbody2D.velocity = myRigidbody2D.velocity.normalized * maxSpeed; // returns velocity to 1 then equals it to max speed
        }
    }

    public void FireProjectile()
    {
        if (canFire)
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.transform.position, transform.rotation); // creates game object, prefab

            projectile.GetComponent<Projectile>().SetFiringShip(gameObject); // getcomponent finds out, from game object <projectile>, the ship which created it

            projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed); //creates force on projectile

            StartCoroutine(FireRateBuffer()); // waits for the delay before making new one

            Destroy(projectile, 4); // destroys after 4 seconds
        }
       
    } 

    public void TakeDamage(int damageToTake)
    {
        currentArmor = currentArmor - damageToTake;
        if (currentArmor <= 0)
        {
            Expload();
        }
    }

    public void Expload()
    {
        //Instantiate(Resources.Load("Explosion"), transform.position, transform.rotation);
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        Destroy(gameObject);
    }

}
