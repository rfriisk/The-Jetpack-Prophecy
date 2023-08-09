using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //[SerializeField]
    //private Transform player;
    GameObject player;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }

    }
}
