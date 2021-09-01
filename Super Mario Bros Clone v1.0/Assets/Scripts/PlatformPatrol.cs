using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlatformPatrol : MonoBehaviour
{
    public float moveSpeed;
    public float rayLength;
    private bool moveLeft;
    public Transform contactChecker;
    // Start is called before the first frame update
    void Start()
    {
        moveLeft = true;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        //<< this is a Bit Shift. We want to affect every layer except our player layer to ignore our player's collider. It depends on the layer mask number.
        int layerMask = 1 << 6;
        layerMask = ~layerMask; // tilde ~ is "is not"
        //point in which our ray cast. The point in which the raycast hits a collider is contactCheck.
        //Point of origin, direction and lengh . At the end, we IGNORE the layerMark we just put before: number 6
        RaycastHit2D contactCheck = Physics2D.Raycast(contactChecker.position, Vector2.down, rayLength, layerMask);
        //Line of raycast below
        Debug.DrawRay(contactChecker.position, Vector2.down * rayLength, Color.red);
        if (contactCheck == false) //If I've hit something or there is nothing below the raycheck
        {
            if (moveLeft == true) //Am I moving left?
            {
                transform.eulerAngles = new Vector2(0, -180); //Turn around! I have to turn myself with the eulerAngles (flip on x axis)
                moveLeft = false;
            }
            else //otherwise
            {
                transform.eulerAngles = new Vector2(0, 0);
                moveLeft = true;
            }
        }
    }
}