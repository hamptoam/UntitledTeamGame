using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    private void Start()
    {
        offset = new Vector3(1.1f, 2.3f, -2.8f);
        transform.Rotate(15, 0, 0);
    }
    void Update()
    {
        transform.position = player.position + offset;
    }
}
