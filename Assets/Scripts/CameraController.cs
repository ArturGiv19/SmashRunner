using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;    
    private Transform cubeSpline;
    private float xRot;

    private void Start()
    {
        cubeSpline = transform.parent;
    }

    private void FixedUpdate()
    {
        xRot = To180(cubeSpline.localEulerAngles.x);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(player.transform.localPosition.x, 0, 0), Time.deltaTime * 10);
        transform.localRotation = Quaternion.Euler(-Mathf.Clamp(xRot / 10f, 0, 30), 0, 0);        
    }

    private float To180(float _input)
    {
        if (_input > 180)
        {
            return -(360 - _input);
        }
        return _input;
    }
}
