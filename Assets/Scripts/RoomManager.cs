using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class RoomManager : MonoBehaviourPunCallbacks
{
   

    public static RoomManager instance;
    public GameObject player;
    public GameObject enemy;

    float x;
    float y;
    float z;
    Vector3 pos;
    Vector3 pos1;


    bool joined=false;

    int joined1=5;

    [Space]
    public Transform  spawnPoint;

    [Space]
    public GameObject roomCam;

    

    [Space]
    public GameObject nameUI;
    public GameObject connectingUI;
    public GameObject GameOver;

    private string nickname =  "unnamed";

    [HideInInspector]
    public int Kills = 0;
    [HideInInspector]
    public int deaths = 0;

    // Start is called before the first frame update

    void Awake() {
        instance = this;
    }

    void Update()
    {

        if(joined){
            joined1+=5;
            Invoke("Respawnenemy", joined1);
        }

    }

    public void ChangeNickname(string _name) {
        nickname = _name;
    }
    public void JoinRoomButtonPressed() {
        Debug.Log("Connecting...");

        PhotonNetwork.ConnectUsingSettings();

        GameOver.SetActive(false);
        nameUI.SetActive(false);
        connectingUI.SetActive(true);
    }
    void Start()
    {
    
    }


    public override void OnConnectedToMaster() {
        base.OnConnectedToMaster();

        Debug.Log("Connected To Server!");

        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        PhotonNetwork.JoinOrCreateRoom("test", null ,null);

        Debug.Log("We're Connected and in a room now!");

        Invoke("RespawnPlayer", 3);
        Invoke("Respawnenemy", joined1);

        joined=true;

    }
    
    /*public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 4 });
    }*/

     /*void PhotonInit() {

      roomCam.SetActive(false);
       GameObject _player = PhotonNetwork.Instantiate (player.name, spawnPoint.position,Quaternion.identity);
       _player.GetComponent<PlayerSetup>().IsLocalPlayer();
    }*/

     public void RespawnPlayer() {

        x = Random.Range(-13, 580);
        y = 10;
        z = Random.Range(-26, 510);
        pos1 = new Vector3(x, y, z);

        roomCam.SetActive(false);
        GameObject _player = PhotonNetwork.Instantiate (player.name, spawnPoint.position,Quaternion.identity);

        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        _player.GetComponent<Health>().isLocalPlayer = true;


        _player.GetComponent<PhotonView>().RPC("SetNickname",RpcTarget.AllBuffered, nickname);
        PhotonNetwork.LocalPlayer.NickName = nickname;

    }


    public void Respawnenemy() {

        // for(int i=0;i<=50;i++){
            x = Random.Range(-13, 580);
            y = 10;
            z = Random.Range(-26, 510);
            pos1 = new Vector3(x, y, z);

            // roomCam.SetActive(false);
            GameObject _playert = PhotonNetwork.Instantiate (enemy.name, pos1,Quaternion.identity);

    }


}
