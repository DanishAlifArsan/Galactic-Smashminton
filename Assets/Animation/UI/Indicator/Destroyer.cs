using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public void Destroy() {
        gameObject.SetActive(false);
    }
}
