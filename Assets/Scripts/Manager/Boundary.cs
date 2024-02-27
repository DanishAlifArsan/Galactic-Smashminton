using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private Collider2D col;
    public Bounds bounds;

    private void Awake() {
        col = GetComponent<Collider2D>();
        bounds = col.bounds;
    }
}
