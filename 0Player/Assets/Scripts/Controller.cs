using UnityEngine;

public class Controller : MonoBehaviour
{

    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            player.position = MoveOnY(player.position, 1f);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            player.position = MoveOnX(player.position, -1f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            player.position = MoveOnY(player.position, -1f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            player.position = MoveOnX(player.position, 1f);
        }

    }

    private Vector3 MoveOnY(Vector3 pos, float movement)
    {
        return new Vector3(pos.x, pos.y + movement, pos.z);
    }

    private Vector3 MoveOnX(Vector3 pos, float movement)
    {
        return new Vector3(pos.x + movement, pos.y, pos.z);
    }
}
