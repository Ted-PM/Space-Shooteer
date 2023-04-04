using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ScreenShakeManager : MonoBehaviour
{

    public static ScreenShakeManager Instance; // static shared by whole class, not specific to individual object. counter of num of objects, shared variable has type of class
    public float duration;
    public float strength;
    public int vibrato;
    public float randomness;

    private void Awake()
    {
        Instance = this;
    }

    public void ShakeScreen()
    {
        transform.DOShakePosition(duration, strength, vibrato, randomness, false, true); // shakes it's own object

    }

   
}
