using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 30f;
    public float Multiplier = 1f;

    private Vector3 previousMousePos;
    void Update()
    {
        ForwardMovement();
        SideWaySwipe();
        LockHorizontalPosition();
    }
    void ForwardMovement()
    {
        transform.position = transform.position + Vector3.forward * forwardSpeed * Time.deltaTime;
    }
    public void SideWaySwipe()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            previousMousePos = Input.mousePosition;
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            var newpos = Input.mousePosition;
            var difpos = newpos - previousMousePos;
            var horizontal = difpos.x * Time.deltaTime * Multiplier;

            transform.position = transform.position + transform.right * horizontal;
        }
    }
    public void LockHorizontalPosition()
    {
        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -5, 5);
        transform.position = pos;
    }
}
