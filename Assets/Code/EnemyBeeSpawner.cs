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

    /*

    public GameObject enemyShip1;
    public GameObject enemyShip2;

    public Transform spawnPoint1;
    public Transform spawnPoint2;

    int shipCounter = 0;
    */

    private void Awake()
    {
        SpawnEnemyBee();

    }



    /*public void SpawnEnemyShip()
    {

        Instantiate(enemyShip1, spawnPoint1.position, transform.rotation, null);
        Instantiate(enemyShip2, spawnPoint2.position, transform.rotation, null);  
    }*/

    public void SpawnEnemyBee()
    {
        int enemyBeesToSpawn = startingNumberOfBees + currentWave;

        

        for (int i = 0; i <enemyBeesToSpawn; i++)
        {
            int rand = Random.Range(0, enemyBeePrefab.Count);
            float zRotation = Random.Range(0, 360);

            spawnPivot.eulerAngles = new Vector3(0, 0, zRotation);
            Instantiate(enemyBeePrefab[rand], spawnPoint.position, transform.rotation, null);

            
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
            

            SpawnEnemyBee();

            if (currentWave > PlayerPrefs.GetInt("highestWave"))
            {
                PlayerPrefs.SetInt("highestWave", currentWave);
            }

        }
       

    }
    
}
