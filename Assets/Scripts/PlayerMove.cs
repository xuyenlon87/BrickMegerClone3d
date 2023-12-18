using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] LayerMask brickLayer;
    private Vector3 mousePositionStart, mousePositionEnd;
    

    //private Vector3 position;
    //private float width;
    //private float height;

    void Awake()
    {
        
        //width = (float)Screen.width / 2.0f;
        //height = (float)Screen.height / 2.0f;

        //// Position used for the cube.
        //position = new Vector2(0.0f, 0.0f);
    }

    //void OnGUI()
    //{
    //    // Compute a fontSize based on the size of the screen width.
    //    GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);

    //    GUI.Label(new Rect(20, 20, width, height * 0.25f),
    //        "x = " + position.x.ToString("f2") +
    //        ", y = " + position.y.ToString("f2"));
    //}
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            mousePositionStart = Input.mousePosition;
            Debug.Log(mousePositionStart.x);
        }
        if (Input.GetMouseButtonUp(0))
        {
            mousePositionEnd = Input.mousePosition;
           
        }
        Vector3 direction = mousePositionEnd - mousePositionStart;
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            direction.y = 0f;
        }
        else
        {
            direction.x = 0f;
        }
        transform.position = Vector3.MoveTowards(transform.position, direction, 1f);
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if(direction.x > 0)
        {
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 10f, brickLayer))
            {
                Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
            }
        }


        // Handle screen touches.
        //    if (Input.touchCount > 0)
        //    {
        //        Touch touch = Input.GetTouch(0);

        //        // Move the cube if the screen has the finger moving.
        //        if (touch.phase == TouchPhase.Moved)
        //        {
        //            Vector2 pos = touch.position;
        //            pos.x = (pos.x - width) / width;
        //            pos.y = (pos.y - height) / height;
        //            position = new Vector2(-pos.x, pos.y);

        //            // Position the cube.
        //            transform.position = position;
        //        }

        //        if (Input.touchCount == 2)
        //        {
        //            touch = Input.GetTouch(1);

        //            if (touch.phase == TouchPhase.Began)
        //            {
        //                // Halve the size of the cube.
        //                transform.localScale = new Vector2(0.75f, 0.75f);
        //            }

        //            if (touch.phase == TouchPhase.Ended)
        //            {
        //                // Restore the regular size of the cube.
        //                transform.localScale = new Vector2(1.0f, 1.0f);
        //            }
        //        }
        //    }
        //}
    }

}
