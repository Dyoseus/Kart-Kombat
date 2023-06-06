using UnityEngine;
using System.Collections.Generic;


public class PowerUpCrate : MonoBehaviour
{
    public GameObject fireBallPrefab;
    public GameObject mine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<FireFireBall>().GiveFireBallAbility(fireBallPrefab);
            other.GetComponent<dropLandmines>().hasMines = true;
            Destroy(gameObject);
        }
    }
}