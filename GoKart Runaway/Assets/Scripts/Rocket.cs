using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float life = 20;

    void Awake(){
        Destroy(gameObject, life);
    }

   /* void OnCollisionEnter(Collision collision){
        // enable this if u want to destroy  what it hits Destroy(collision.gameObject);
        Destroy(gameObject);
    }*/
}