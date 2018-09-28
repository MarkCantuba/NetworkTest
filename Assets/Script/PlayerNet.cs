using UnityEngine;
using UnityEngine.Networking;

public class PlayerNet : NetworkBehaviour {
    [SyncVar] public Color color;

}
