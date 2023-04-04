using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    void Awake()
    {
        Instance = this;
    }

 
    public void GameOver()
    {
        //SceneManager.LoadScene(0);
        //Debug.Log("Step3");

        StartCoroutine(DelayGameOver());
    }
    
    private IEnumerator DelayGameOver()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);

        //Debug.Log("Step4");

    }

}
