using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayableCharacter player;
    [SerializeField] Transform target;
    PlayerMovement movement;
    PlayerSwing swing;
    private bool isSwing;
    float swingTimer = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = Instantiate(player.prefab, transform);
        movement = obj.GetComponent<PlayerMovement>();
        swing = obj.GetComponent<PlayerSwing>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSwing)
        {
            swingTimer += Time.deltaTime;
            if (CanSwing())
            {
                isSwing = false;
            }
        }   
    }

    public void Move(float _direction) {
        movement.Move(player.speed, _direction);
    }

    public void Jump() {
        movement.Jump(player.jumpForce);
    }

    public void Swing() {
        if (CanSwing())
        {
            swingTimer = 0;
            isSwing = true;
            
            swing.Swing(player.swingPower, target.position, !movement.isGrounded());
        }
    }

    private bool CanSwing() {
        return swingTimer >= player.swingCooldown;
    }
}
