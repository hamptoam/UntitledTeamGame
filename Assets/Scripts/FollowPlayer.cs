using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    private void Start()
    {
        transform.Rotate(8, 0, 0);
    }
    void Update()
    {
        transform.position = player.position + offset;
    }
}
