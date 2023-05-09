using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSetup : MonoBehaviour
{
    public GoKartController goKartController;
    public FireFireBall fireFireBall;
    public Health health;

    public GameObject camera;

    public void IsLocalPlayer(){
        fireFireBall.enabled = true;
        goKartController.enabled = true;
        camera.SetActive(true);
        health.enabled = true;
    }
}
