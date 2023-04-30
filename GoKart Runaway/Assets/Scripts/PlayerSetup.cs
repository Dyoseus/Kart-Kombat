using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSetup : MonoBehaviour
{
    public GoKartController goKartController;
    public FireRocket fireRocket;

    public GameObject camera;

    public void IsLocalPlayer(){
        fireRocket.enabled = true;
        goKartController.enabled = true;
        camera.SetActive(true);
    }
}
