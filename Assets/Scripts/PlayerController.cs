using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Player player;

    private Vector2 startPos;
    private float x;


    public void Lose()
    {
        this.enabled = false;
        player.AnimatorState(AnimState.lose);
    }
    public void Complete()
    {
        this.enabled = false;
        player.AnimatorState(AnimState.dance);
    }

    public void Run()
    {
        this.enabled = true;
        player.enabled = true;
        player.AnimatorState(AnimState.run);
    }

    private void Start() { }

    private void FixedUpdate()
    {
        player.MoveForward();
        player.RotateLeftRight(x);
    }
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) { startPos = Input.mousePosition; }
        if (Input.GetMouseButton(0))
        {
            x = Input.mousePosition.x - startPos.x;            
        }
    }

}
