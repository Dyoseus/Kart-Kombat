using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{

    public static RoomManager instance;

    public GameObject player;
    public Transform spawnPoint;

    [Space]
    public GameObject roomCam; 

    [Space]
    public GameObject nameUI;

    public GameObject connectingUI;

    private string nickname = "Guest";

    void Awake()
    {
        instance = this;
    }

    public void ChangeNickname(string _name){
        nickname = _name;
    }

    public void JoinRoomButtonPressed(){
        Debug.Log("Connecting...");

        PhotonNetwork.ConnectUsingSettings();

        nameUI.SetActive(false);
        connectingUI.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    { 
        
    }

    public override void OnConnectedToMaster(){
        base.OnConnectedToMaster();

        Debug.Log("Connected to Server");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby(){
        base.OnJoinedLobby();

        Debug.Log("Connected to server");

        PhotonNetwork.JoinOrCreateRoom("test", null, null);
        
    }

    public override void OnJoinedRoom(){
        base.OnJoinedRoom();

        Debug.Log("We're connected and in a room now");

        roomCam.SetActive(false);

        SpawnPlayer();
    }

    public void SpawnPlayer(){
        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        _player.GetComponent<Health>().isLocalPlayer = true;

        _player.GetComponent<PhotonView>().RPC("SetNickname", RpcTarget.AllBuffered, nickname);
    }
}
