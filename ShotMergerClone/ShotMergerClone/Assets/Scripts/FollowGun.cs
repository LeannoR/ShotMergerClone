using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGun : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    public Transform gun;
    void Update()
    {
        CameraPosition();
    }
    public void CameraPosition()
    {
        var cameraPos = gun.position + offset;
        cameraPos.x = Mathf.Clamp(0, 0, 0);
        transform.position = cameraPos;
    }
}
