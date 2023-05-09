using UnityEngine;
using System.Collections.Generic;


public class PowerUpCrate : MonoBehaviour
{
    public GameObject fireBallPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<FireFireBall>().GiveFireBallAbility(fireBallPrefab);
            Destroy(gameObject);
        }
    }
}