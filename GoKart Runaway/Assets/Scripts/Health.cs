using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Health : MonoBehaviourPunCallbacks
{
    public int health;
    public bool isLocalPlayer;

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
            if (isLocalPlayer){
                RoomManager.instance.SpawnPlayer();
            }
            
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
