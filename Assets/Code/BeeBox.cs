using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBox : MonoBehaviour
{
    public int maxArmor;
    [HideInInspector] public int currentArmor;
    public Rigidbody2D myRigidbody2D;
    public GameObject explosionPrefab;

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
        ScreenShakeManager.Instance.ShakeScreen(); // calling class, find instance, instance only calls 1 this

        Instantiate(Resources.Load("Explosion"), transform.position, transform.rotation);  //Instantiate(explosionPrefab, transform.position, transform.rotation);

        Destroy(gameObject);

        GameManager.Instance.GameOver();

    }



    private void Awake()
    {
      

        currentArmor = maxArmor;

        
        Debug.Log(currentArmor);
    }

}
