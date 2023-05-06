using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Rocket : MonoBehaviourPunCallbacks
{
    public int damage = 10; // Amount of damage the rocket inflicts

    private GameObject owner; // Reference to the game object that instantiated the rocket

    // Set the owner of the rocket
    public void SetOwner(GameObject obj)
    {
        owner = obj;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider belongs to a player and is not the owner of the rocket
        if (other.CompareTag("Player") && other.gameObject != owner)
        {
            // Reduce the other player's health
            other.GetComponent<Health>().TakeDamage(damage);

            // Destroy the rocket
            if (photonView && photonView.IsMine)
            {
                photonView.RPC("DestroyRocket", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    void DestroyRocket()
    {
        if (photonView && photonView.IsMine)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
