using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    Transform player;


    void Start()
    {
        player = FindObjectOfType<PlayerShip>().transform; // finds player ship location at start
    }


    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10); // places cam over player, -10 is for Z position
    }
}
