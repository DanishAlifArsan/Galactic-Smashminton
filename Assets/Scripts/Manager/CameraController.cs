using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera cam;
    [SerializeField] float range;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        var (center, size) = CalculateOrthoSize();
        cam.transform.position = center;
        cam.orthographicSize = size;   
    }

    private (Vector3 center, float size) CalculateOrthoSize() {
        var bounds = new Bounds();
        foreach (var col in FindObjectsOfType<Boundary>())
        {
            bounds.Encapsulate(col.bounds);
        }

        bounds.Expand(range);

        var vertical = bounds.size.y * cam.pixelHeight / cam.pixelWidth;
        var horizontal = bounds.size.x * cam.pixelHeight / cam.pixelWidth;

        var size = Mathf.Max(horizontal, vertical) * 0.5f;
        var center = bounds.center + new Vector3(0,0,-10);

        return (center, size);
    }
}
