using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SampleScene : MonoBehaviourPunCallbacks
{
    public GameObject countdown;

    private void Start()
    {
        // プレイヤー自身の名前を"Player"に設定する
        PhotonNetwork.NickName = "Player";

        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("set");
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        // "Room"という名前のルームに作成、参加する
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
        Debug.Log("callback");
    }

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        // 指定した座標に自身のアバター（ネットワークオブジェクト）を生成する
        var position = new Vector3(-20, 0, 0);
        PhotonNetwork.Instantiate("YamatoNet", position, Quaternion.identity);
        Debug.Log("Instantiate");
    }


}
