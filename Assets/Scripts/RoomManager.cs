using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public GameObject player;

    [Space]
    public Transform  spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connecting...");

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster(){
        base.OnConnectedToMaster();
        Debug.Log("Connected To Server.");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby(){
        base.OnJoinedLobby();
        
        PhotonNetwork.JoinOrCreateRoom("RoomOfWeapon" ,null , null);

        Debug.Log("We're connected and in a room now! ");

         Invoke("PhotonInit", 5);
    }
    void PhotonInit() {


       GameObject _player = PhotonNetwork.Instantiate (player.name, spawnPoint.position,Quaternion.identity);

      }
}
