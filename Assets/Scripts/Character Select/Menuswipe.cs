using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menuswipe : MonoBehaviour
{
    [SerializeField] Transform characterSelectMenu;
    [SerializeField] float swipeSpeed;
    [SerializeField] float minX, maxX;
    private float touchTreshold = 0;
    private Touch initTouch;
    private float currentPos;
    Direction touchDir;
    enum Direction {
        right = 1,
        left = -1,
        noDir = 0
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = characterSelectMenu.transform.localPosition.x;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)    // saat jari menyentuh layar, mendapatkan waktu dan jarak mulai swipe
            {
                initTouch = touch;
            }
            else if (touch.phase == TouchPhase.Moved || touchDir != Direction.noDir)   // saat jari diangkat dari layar, mendapatkan waktu dan jarak selesai swipe
            {
                float dir = touch.position.x - initTouch.position.x;
                if ((dir > touchTreshold || touchDir == Direction.right) && currentPos <= maxX)
                {
                    touchDir = Direction.right;
                    characterSelectMenu.transform.Translate(new Vector2(swipeSpeed, 0), Space.World);
                }
                if ((dir < -touchTreshold || touchDir == Direction.left ) && currentPos >= minX)
                {
                    touchDir = Direction.left;
                    characterSelectMenu.transform.Translate(new Vector2(-swipeSpeed, 0), Space.World);
                }
            }
        }
    }  
}
