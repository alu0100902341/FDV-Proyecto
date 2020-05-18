using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    private void Start()
    {
        target = GameObject.Find("Boy").GetComponent<Transform>();
        offset = new Vector3(0.0f, 0.0f, -2.0f);
    }

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
