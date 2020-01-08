using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("速度"), Range(0, 10)]
    public float speed = 3;

    private Transform target;

    private void Start()
    {
        target = GameObject.Find("Jasmine").transform;
    }

    private void LateUpdate()
    {
        Vector3 cam = transform.position;
        Vector3 tar = target.position;
        tar.x = Mathf.Clamp(tar.x, -1, 6);
        tar.z = -2;
        tar.y = Mathf.Clamp(tar.y, 0, 4);
        transform.position = Vector3.Lerp(cam, tar, 0.3f * Time.deltaTime * speed);
    }
}