using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Health : MonoBehaviourPunCallbacks
{
    public int health;

    [PunRPC]
    public void TakeDamage(int _damage){
        health -= _damage;

        if (health <= 0){
            photonView.RPC("Die", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    void Die(){
        if(photonView.IsMine){
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
