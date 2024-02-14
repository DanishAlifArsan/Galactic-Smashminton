using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayableCharacter player;
    [SerializeField] Transform target;
    [SerializeField] Transform indicator;
    PlayerMovement movement;
    PlayerSwing swing;
    public Transform servePoint;
    private bool isSwing;
    float swingTimer = Mathf.Infinity;
    float[,] swingPowers;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject obj = Instantiate(player.prefab, transform).transform.GetChild(0).gameObject;
        movement = obj.GetComponent<PlayerMovement>();
        swing = obj.GetComponent<PlayerSwing>();
        servePoint = swing.servePoint;
        indicator.parent = obj.transform;
        indicator.localPosition = swing.smashPoint.localPosition;
        PopulateArray();
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
            
            swing.Swing(swingPowers, target.position, !movement.isGrounded());
        }
    }

    private bool CanSwing() {
        return swingTimer >= player.swingCooldown;
    }

    private void PopulateArray() {
        swingPowers = new float[3,3];
        swingPowers[0,0] = player.swingPower;
        swingPowers[0,1] = player.swingAngle;
        swingPowers[1,0] = player.smashPower;
        swingPowers[1,1] = player.smashAngle;
        swingPowers[2,0] = player.servicePower;
        swingPowers[2,1] = player.serviceAngle;
    }
}
