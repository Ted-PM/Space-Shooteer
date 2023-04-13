using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtBeeBox : MonoBehaviour
{

    private Transform target;
    //public Transform playerPoint;
    //public Transform playerPivot;
    //public Rigidbody2D myRigidbody2D;
    //public float angleToBox;

    void Start()
    {
        target = FindObjectOfType<BeeBox>().transform;
    }

    void FaceBeeBox()
    {

        Vector2 directionToFace = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y); // creates vector between EnemyShip and PlayerShip

        transform.up = directionToFace;

        //myRigidbody2D.AddForce(transform.up);

        //transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime);

        //float angle = Vector3.Angle(transform.position, target.position);

        //transform.RotateAround(target.position, directionToFace, angle);

        //playerPivot.eulerAngles = directionToFace;
    }

    void Update()
    {
        FaceBeeBox();
    }
}
