using UnityEngine;
using System.Collections.Generic;


public class PowerUpCrate : MonoBehaviour
{
    public GameObject rocketPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<FireRocket>().GiveRocketAbility(rocketPrefab);
            Destroy(gameObject);
        }
    }
}