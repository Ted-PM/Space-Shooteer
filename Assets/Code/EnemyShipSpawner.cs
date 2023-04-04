using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipSpawner : MonoBehaviour
{
    public List<EnemyShip> enemyShipPrefabs;

    public Transform spawnPoint;
    public Transform spawnPivot;

    [HideInInspector] public int currentWave = 1;
    [HideInInspector] public int startingNumberOfShips;

    /*

    public GameObject enemyShip1;
    public GameObject enemyShip2;

    public Transform spawnPoint1;
    public Transform spawnPoint2;

    int shipCounter = 0;
    */

    private void Awake()
    {


    }



    /*public void SpawnEnemyShip()
    {

        Instantiate(enemyShip1, spawnPoint1.position, transform.rotation, null);
        Instantiate(enemyShip2, spawnPoint2.position, transform.rotation, null);  
    }*/

    public void SpawnEnemyShip()
    {
        int enemyShipsToSpawn = startingNumberOfShips + currentWave;

        for (int i = 0; i <enemyShipsToSpawn; i++)
        {
            int rand = Random.Range(0, enemyShipPrefabs.Count);
            float zRotation = Random.Range(0, 360);

            spawnPivot.eulerAngles = new Vector3(0, 0, zRotation);
            Instantiate(enemyShipPrefabs[rand], spawnPoint.position, transform.rotation, null);
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
    public void CountEnemyShips()
    {
        int numberOfEnemyShips = FindObjectsOfType<EnemyShip>().Length;

        print(numberOfEnemyShips);

        if (numberOfEnemyShips == 1)
        {
            currentWave++;

            //FindObjectOfType<PlayerShip>().HealthBoost(); // ----

            HUD.Instance.DisplayWave(currentWave);
            

            SpawnEnemyShip();

            if (currentWave > PlayerPrefs.GetInt("highestWave"))
            {
                PlayerPrefs.SetInt("highestWave", currentWave);
            }

        }
       

    }
    
}
