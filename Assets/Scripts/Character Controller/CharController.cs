using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [HideInInspector] public PlayerMovement movement;
    [HideInInspector] public PlayerSwing swing;
    [HideInInspector] public GameObject obj;
    [HideInInspector] public Transform servePoint;
    [HideInInspector] public bool isJump;
    [HideInInspector] public float[,] swingPowers;

    protected void InitCharacter(PlayableCharacter character) {
        obj = Instantiate(character.prefab, transform).transform.GetChild(0).gameObject;
        movement = obj.GetComponent<PlayerMovement>();
        swing = obj.GetComponent<PlayerSwing>();
        servePoint = swing.servePoint;

        PopulateArray(character);
    }

    private void PopulateArray(PlayableCharacter character) {
        swingPowers = new float[3,3];
        swingPowers[0,0] = character.swingPower;
        swingPowers[0,1] = character.swingAngle;
        swingPowers[1,0] = character.smashPower;
        swingPowers[1,1] = character.smashAngle;
        swingPowers[2,0] = character.servicePower;
        swingPowers[2,1] = character.serviceAngle;
    }
}
