using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class PlayerName : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        var nameLabel = GetComponent<TextMeshPro>();
        // プレイヤー名とプレイヤーIDを表示する
        nameLabel.text = $"{photonView.Owner.NickName}({photonView.OwnerActorNr})";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
