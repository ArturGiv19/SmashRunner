using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;


public class Player : MonoBehaviour, IMovable
{
    public SplineFollower spline;

    [SerializeField] private Animator animator;
    private float _rot;
    private float y;    
    private Rigidbody[] joints;

    private void Start()
    {
        joints = transform.GetChild(0).GetComponentsInChildren<Rigidbody>();        
    }
    

    public void MoveForward()
    {
        y = Mathf.Clamp(transform.localPosition.x + _rot * 0.02f * Time.deltaTime, -4, 4);
        transform.localPosition = new Vector3(y, 5, 0);
    }

    public void RotateLeftRight(float _rotate)
    {
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, 180 + Mathf.Clamp(_rotate / 10, -20, 20), transform.localRotation.z);
        _rot = _rotate;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "finish")
        {
            GameController.instance.CompleteGame();
        }
        if (other.tag == "Enemy")
        {            
            GameController.instance.LoseGame();
        }
    }

    public void AnimatorState(AnimState animState)
    {
        animator.enabled = true;        

        switch (animState)
        {
            case AnimState.run:
                animator.Play("run");
                break;
            case AnimState.lose:
                animator.enabled = false;
                spline.enabled = false;
                ActivateRagdoll();
                break;
            case AnimState.dance:
                spline.enabled = false;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                animator.Play("dance");
                break;
        }
    }

    public void ActivateRagdoll()
    {
        for (int i = 0; i < joints.Length; i++)
        {
            joints[i].isKinematic = false;
        }
        joints[0].AddForce(transform.forward * 1000);
    }

}


interface IMovable
{
    void MoveForward();
    void RotateLeftRight(float _rotate);
}

public enum AnimState
{
    run,
    dance,
    lose
}