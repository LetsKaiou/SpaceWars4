using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
//using Player = Photon.Realtime.Player;

public class PhotonConnect : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI statusText;
    private const int MaxPlayerPerRoom = 2;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    private void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }

    //これをボタンにつける
    public void FindOponent()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }

    //Photonのコールバック
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to host");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"{cause}Error");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Create a room");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayerPerRoom });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined the room");
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        if (playerCount != MaxPlayerPerRoom)
        {
            statusText.text = "Waiting...";
        }
        else
        {
            statusText.text = "Opponent is coming. Battle start";
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayerPerRoom)
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;
                statusText.text = "Opponent is coming. Battle start";
                PhotonNetwork.LoadLevel("SampleScene");
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
