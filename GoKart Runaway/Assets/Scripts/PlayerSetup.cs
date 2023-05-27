using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;


public class PlayerSetup : MonoBehaviour
{
    public GoKartController goKartController;
    public FireFireBall fireFireBall;
    public Health health;

    public GameObject camera;

    public string nickname;

    public TextMeshPro nicknameText;

    public void IsLocalPlayer(){
        fireFireBall.enabled = true;
        goKartController.enabled = true;
        camera.SetActive(true);
        health.enabled = true;
    }

    [PunRPC]
    public void SetNickname(string _name){
        nickname = _name;

        nicknameText.text = nickname;
    }
}
