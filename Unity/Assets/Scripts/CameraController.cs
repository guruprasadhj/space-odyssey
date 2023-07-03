using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   [SerializeField] private Transform player;
   [SerializeField] private Vector3 offset;
   [SerializeField] private float speed;
    void Update()
    {
        // transform.position = new Vector3(player.position.x,player.position.y,transform.position.z); 
        Vector3 desiredPos = player.position + offset;  
        transform.position = Vector3.Lerp(transform.position,desiredPos,speed * Time.deltaTime);
        
    }
}
