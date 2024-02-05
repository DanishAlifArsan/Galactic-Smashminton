using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardMove : MonoBehaviour
{
    [SerializeField] private UIManager uIManager;
    bool isMoved;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        isMoved = false;
        uIManager.InteractButton(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoved)
        {
            transform.Translate(Vector2.left * Time.deltaTime  * 5, Space.World);    
            if (transform.position.x <= 0)
            {
                isMoved = true;
            }
        } else {
            uIManager.InteractButton(true);
        }

    }
}
