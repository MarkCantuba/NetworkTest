using UnityEngine;
using UnityEngine.Networking;

public class Network : NetworkManager {

    public GameObject[] playerFabs;


    public override void OnStartClient(NetworkClient client) {
        base.OnStartClient(client);
        foreach (GameObject character in playerFabs) {
            ClientScene.RegisterPrefab(character);
        }
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId) {
        GameObject player = GameObject.Instantiate(playerFabs[Random.Range(0,2)]) as GameObject;
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        return;
       
    }

}
