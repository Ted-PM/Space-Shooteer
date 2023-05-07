using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    public List<GameObject> flowerPrefabs;

    //public GameObject flowerPrefab;
    public int numberOfFlowers;
    public int maxX;
    public int maxY;
    public int maxZ;
    public int minZ;



    void Start()
    {
        for (int i = 0; i<numberOfFlowers; i++)
        {
            float X = Random.Range(-maxX, maxX);
            float Y = Random.Range(-maxY, maxY);
            float Z = Random.Range(minZ, maxZ);

            Vector3 spawnPosition = new Vector3(X, Y, Z);

            //Quaternion spawnRotation = new Quaternion(Random.Ran)

            int rand = Random.Range(0, flowerPrefabs.Count);

            Instantiate(flowerPrefabs[rand], spawnPosition, Quaternion.Euler((float)0.0, (float)0.0, Random.Range((float)0.0, (float) 360.0)), transform);
        }
        
    }

}
