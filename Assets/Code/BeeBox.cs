using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BeeBox : MonoBehaviour
{
    public int maxArmor;
    [HideInInspector] public int currentArmor;
    public Rigidbody2D myRigidbody2D;
    public GameObject explosionPrefab;

    //public AudioClip beeBuzzing;

    public AudioSource beeBuzzing;


    public float duration; // --
    public float strength; // --
    public int vibrato; // --
    public float randomness; // --

    public void ShakeBeeBox() // -- 
    {

        transform.DOShakePosition(duration, strength, vibrato, randomness, false, true); // shakes it's own object // --

        // Instantiate(beeBuzzing);

        beeBuzzing.Play();

        //beeBuzzing.SetScheduledEndTime(AudioSettings.dspTime + (14.57f - 13.21f));


        //Debug.Log(beeBuzzing);

        //Instantiate(beeBuzzing);

        //AudioSource.PlayClipAtPoint(beeBuzzing, new Vector3(1, 1, 1));
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
        ScreenShakeManager.Instance.ShakeScreen(); // calling class, find instance, instance only calls 1 this

        Instantiate(Resources.Load("Explosion"), transform.position, transform.rotation);  //Instantiate(explosionPrefab, transform.position, transform.rotation);

        Destroy(gameObject);

        GameManager.Instance.GameOver();

    }



    private void Awake()
    {
      

        currentArmor = maxArmor;

        //beeBuzzing = gameObject.GetComponent<AudioSource>();


        Debug.Log(currentArmor);
    }

}
