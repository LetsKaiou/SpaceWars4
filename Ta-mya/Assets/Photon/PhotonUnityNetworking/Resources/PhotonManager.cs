using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        //マスターサーバーに接続
        PhotonNetwork.ConnectUsingSettings();
    }

    //マスターサーバーに接続成功した時に呼ばれる
    public override void OnConnectedToMaster()
    {
        //Roomという名前のルームを作成する、既存の場合は参加する
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    //ルームへの接続が成功したら呼ばれる
    public override void OnJoinedRoom()
    {
        //Playerを生成する座量をランダムに決める
        var position = new Vector3(Random.Range(-3f, 3f), 0.5f, Random.Range(-3f, 3f));

        //Resourcesフォルダから"Player"を探してきてそれを生成
        PhotonNetwork.Instantiate("Player", position, Quaternion.identity);
    }
}
