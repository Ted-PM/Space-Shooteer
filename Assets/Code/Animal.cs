using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Animals : MonoBehaviour
{
    // IS THIS VISIBLE

    public Rigidbody2D myRigidbody2D;
    public GameObject projectilePrefab;
    public GameObject projectileSpawnPoint;
    public GameObject explosionPrefab;
    //public GameObject pointerPrefab;

    public GameObject trailPrefab; // --
    public GameObject trailSpawnPoint; // --

    /*
    public GameObject thrustPrefab;
    public GameObject thrustSpawnPoint;
    */

    public float acceleration;
    public float maxSpeed;
    public int maxArmor;
    public float fireRate;
    public float projectileSpeed;
    [HideInInspector] public float currentSpeed;
    [HideInInspector] public int currentArmor;
    protected bool canFire;

    protected bool canLeaveTrail; // --

    // public bool canGainHealth; // ----

    //[HideInInspector] ParticleSystem pollenParticles; // hidden in unity,
    //public ParticleSystem pollenPrefab;



    private void Awake()
    {
        currentArmor = maxArmor;
        canFire = true;
        canLeaveTrail = true; // --

        // canGainHealth = true; // ----

        //Debug.Log("Step1");
        //pollenParticles = GetComponentInChildren<ParticleSystem>();
        //pollenParticles = Instantiate(pollenPrefab, myRigidbody2D.transform.position, myRigidbody2D.transform.rotation);
        //pollenParticles.transform.parent = this.transform;



    }

    IEnumerator FireRateBuffer()
    {
        canFire = false; // disables projectiles
        yield return new WaitForSeconds(fireRate); // waits before can fire again
        canFire = true; // can fire again
    }

    IEnumerator TrailRateBuffer() // --
    {
        canLeaveTrail = false; // disables projectiles
        yield return new WaitForSeconds(0.5f); // waits before can fire again
        canLeaveTrail = true; // can fire again
    }


    public void LeaveTrail() // --
    {
        if (canLeaveTrail)
        {
            GameObject trail = Instantiate(trailPrefab, trailSpawnPoint.transform.position, transform.rotation); // creates game object, prefab

            //projectile.GetComponent<Projectile>().SetFiringShip(gameObject); // getcomponent finds out, from game object <projectile>, the ship which created it

            //projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed); //creates force on projectile

            Destroy(trail, 2); // destroys after 4 seconds

            StartCoroutine(TrailRateBuffer()); // waits for the delay before making new one
        }

    }

    public void Thrust()
    {


        myRigidbody2D.AddForce(transform.up * acceleration); // adds force to ship

        LeaveTrail(); // --

        //pollenParticles.Emit(1);

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

            Destroy(projectile, 4); // destroys after 4 seconds

            StartCoroutine(FireRateBuffer()); // waits for the delay before making new one
        }
       
    }

    public virtual void TakeDamage(int damageToTake)
    {
        currentArmor = currentArmor - damageToTake;


        if (currentArmor <= 0)
        {
            Expload();
        }

        
    }

    public void Expload()
    {
        //Debug.Log("Step1");

        if (GetComponent<PlayerBird>())
        {
            //Debug.Log("Step2");
            GameManager.Instance.GameOver();
        }

        //Debug.Log("Step5");


        ScreenShakeManager.Instance.ShakeScreen(); // calling class, find instance, instance only calls 1 this
        

        Instantiate(Resources.Load("Explosion"), transform.position, transform.rotation);  //Instantiate(explosionPrefab, transform.position, transform.rotation);


        FindObjectOfType<EnemyBeeSpawner>().CountEnemyBees();

        Destroy(gameObject);

      


    }


}
