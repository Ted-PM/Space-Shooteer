using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;
    public int numberOfStars;
    public int maxX;
    public int maxY;
    public int maxZ;
    public int minZ;



    void Start()
    {
        for (int i = 0; i<numberOfStars; i++)
        {
            float X = Random.Range(-maxX, maxX);
            float Y = Random.Range(-maxY, maxY);
            float Z = Random.Range(minZ, maxZ);

            Vector3 spawnPosition = new Vector3(X, Y, Z);

            Instantiate(starPrefab, spawnPosition, transform.rotation, transform);
        }
        
    }

}
