using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/PlayableCharacter")]
public class PlayableCharacter : ScriptableObject
{
    public GameObject prefab;
    public float speed;
    public float jumpForce;
    public float swingCooldown;
    public float swingPower;
    public float swingAngle;
    public float smashPower;
    public float smashAngle;
    public float servicePower;
    public float serviceAngle;
    public int number;
    public Sprite portrait;
}
