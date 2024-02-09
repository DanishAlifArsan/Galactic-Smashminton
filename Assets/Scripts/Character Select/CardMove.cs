using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardMove : MonoBehaviour
{
    [SerializeField] private UIManager uIManager;
    bool isMoved;

    void OnEnable()
    {
        isMoved = false;
        uIManager.InteractButton(false);
    }

    private void Start() {
        uIManager.OnEscPressed += ReturnToPrevious;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoved)
        {
            transform.Translate(Vector2.left * Time.deltaTime  * 5, Space.World);    
            if (transform.position.x <= -17)
            {
                isMoved = true;
            }
        } else {
            uIManager.InteractButton(true);
        }
    }

    private void ReturnToPrevious() {
        uIManager.SwitchScene(0);
    }
}