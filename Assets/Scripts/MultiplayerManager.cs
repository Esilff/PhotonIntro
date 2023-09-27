using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class MultiplayerManager : MonoBehaviourPunCallbacks
{
    private GameObject _currentPlayer;
    // Start is called before the first frame update
    
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = false;
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("TestRoom", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        _currentPlayer = PhotonNetwork.Instantiate("PlayerPrefab", Vector3.zero, Quaternion.identity);
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.Destroy(_currentPlayer);
    }
}
