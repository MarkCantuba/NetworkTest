using UnityEngine.Networking;
using UnityEngine;

public class PlayerController : NetworkBehaviour {

    Rigidbody2D player;
    [SerializeField] private float speed = 1.0f;

	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isLocalPlayer) {
            MovePlayer();
            LookAtMouse();
        }


    }

    void MovePlayer() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        player.AddForce(new Vector2(horizontal, vertical) * speed);
    }

    void LookAtMouse() {
        Vector3 getCursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 position = ((Vector2)getCursorPosition - player.position).normalized;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg);
    
    }
}
