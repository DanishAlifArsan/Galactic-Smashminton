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
}
