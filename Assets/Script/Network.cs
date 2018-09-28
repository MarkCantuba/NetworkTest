using UnityEngine;
using UnityEngine.Networking;

public class Network : NetworkManager {

    public GameObject[] playerFabs;

    void Awake() {
        //playerPrefab = playerFabs[Random.Range(0, 2)];
    }
        
    
    public override void OnStartClient(NetworkClient client) {
        base.OnStartClient(client);
        foreach (GameObject character in playerFabs) {
            ClientScene.RegisterPrefab(character);
        }
       
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId) {
        if (playerControllerId == 0) {
            GameObject player = GameObject.Instantiate(playerFabs[1]) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);

        }
        else {
            GameObject player = GameObject.Instantiate(playerFabs[0]) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
       
    }

}
