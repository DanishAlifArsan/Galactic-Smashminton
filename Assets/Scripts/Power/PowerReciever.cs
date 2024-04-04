using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerReciever : MonoBehaviour
{
    [SerializeField] private PowerSystem power;

    private void OnTriggerEnter2D(Collider2D other) {
         if (other.gameObject.CompareTag("PlayerField"))
        {
            power.EndPower();
        }
    }
}
