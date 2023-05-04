using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeeSpawner : MonoBehaviour
{
    public List<EnemyBee> enemyBeePrefab;

    public Transform spawnPoint;
    public Transform spawnPivot;

    [HideInInspector] public int currentWave = 1;
    /*[HideInInspector] */public int startingNumberOfBees;

    //public BeeBox beebox; //--


    public float spawnRate; // --
    //protected bool canSpawnEnemies; // --

    /*

    public GameObject enemyShip1;
    public GameObject enemyShip2;

    public Transform spawnPoint1;
    public Transform spawnPoint2;

    int shipCounter = 0;
    */

    private void Awake()
    {
        //canSpawnEnemies = true; // --
        SpawnEnemyBee();

        //beebox = GameObject.FindWithTag("BeeBox");
        //beebox.canTakeDamage = false;

    }



    /*public void SpawnEnemyShip()
    {

        Instantiate(enemyShip1, spawnPoint1.position, transform.rotation, null);
        Instantiate(enemyShip2, spawnPoint2.position, transform.rotation, null);  
    }*/

    IEnumerator BeeSpawnBuffer() // --
    {
        //beebox.canTakeDamage = false;

        FindObjectOfType<BeeBox>().DamageBool(); // --

        FindObjectOfType<BeeBox>().ShakeBeeBox(); // --
        //canSpawnEnemies = false; // disables projectiles
        yield return new WaitForSeconds(spawnRate); // waits before can fire again
        //canSpawnEnemies = true; // can fire again
        SpawnEnemyBee();
        FindObjectOfType<BeeBox>().DamageBool(); // --


        //beebox.canTakeDamage = true;

    }

    public void SpawnEnemyBee()
    {
        int enemyBeesToSpawn = startingNumberOfBees + currentWave;

        //Debug.Log("Step 4");

        

        //Debug.Log("Step 5");

        for (int i = 0; i <enemyBeesToSpawn; i++)
        {
            //Debug.Log("Step 6");
            int rand = Random.Range(0, enemyBeePrefab.Count);
            float zRotation = Random.Range(0, 360);

            spawnPivot.eulerAngles = new Vector3(0, 0, zRotation);
            Instantiate(enemyBeePrefab[rand], spawnPoint.position, transform.rotation, null);
            //Debug.Log("Step 7");



        }


    }

    /*public void SpawnEnemyShip()
    {
 

        if (shipCounter < 1)
        {
            Instantiate(enemyShip1, spawnPoint1.position, transform.rotation, null);
            shipCounter = 2;
        }
        else if (shipCounter >1)
        {
            Instantiate(enemyShip2, spawnPoint2.position, transform.rotation, null);
            shipCounter = 0;
        }
        
    }*/
    public void CountEnemyBees()
    {
        int numberOfEnemyBees = FindObjectsOfType<EnemyBee>().Length;

        print(numberOfEnemyBees);

        if (numberOfEnemyBees == 1)
        {
            currentWave++;

            //FindObjectOfType<PlayerShip>().HealthBoost(); // ----

            HUD.Instance.DisplayWave(currentWave);

            //Debug.Log("Step 1");

            StartCoroutine(BeeSpawnBuffer()); // --

            //Debug.Log("Step B");

            //canSpawnEnemies = false; // --



            //SpawnEnemyBee();



            if (currentWave > PlayerPrefs.GetInt("highestWave"))
            {
                PlayerPrefs.SetInt("highestWave", currentWave);
            }

        }
       

    }
    
}
