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
        Debug.Log("StepB");
        Debug.Log(currentArmor);

        currentArmor = currentArmor - damageToTake;

        Debug.Log("StepC");
        Debug.Log(currentArmor);

        if (currentArmor <= 0)
        {
            Debug.Log("StepD");
            Debug.Log(currentArmor);
            Expload();
        }


    }

    public void Expload()
    {

        Debug.Log("StepE");
        Debug.Log(currentArmor);

        ScreenShakeManager.Instance.ShakeScreen(); // calling class, find instance, instance only calls 1 this


        Instantiate(Resources.Load("Explosion"), transform.position, transform.rotation);  //Instantiate(explosionPrefab, transform.position, transform.rotation);

        Destroy(gameObject);

        Debug.Log("StepD");
        Debug.Log(currentArmor);


    }



    private void Awake()
    {
      

        currentArmor = maxArmor;

        Debug.Log("StepA");
        Debug.Log(currentArmor);
    }

}
