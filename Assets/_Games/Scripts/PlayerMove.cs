using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] LayerMask brickLayer;
    [SerializeField] GameObject playerImg;
    [SerializeField] private bool canMove = true;

    private Vector3 mousePositionStart, mousePositionEnd;
    private Vector3 raycastStart;
    private RaycastHit hitCheckBrick;
    private Vector3 currentPos;
    void Start()
    {
        transform.position = currentPos;
    }
    // Update is called once per frame
    void Update()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            mousePositionStart = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mousePositionEnd = Input.mousePosition;

        }
        if(mousePositionStart != null && mousePositionEnd != null)
        {
            Move();

        }
        Debug.Log(LevelManager.Instance.currentMap);
    }
    private void Move()
    {
        Vector3 direction = mousePositionEnd - mousePositionStart;
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            direction.y = 0f;
        }
        else
        {
            direction.x = 0f;
        }
        // Does the ray intersect any objects excluding the player layer
        if (direction.x > 0)
        {
            raycastStart = transform.position + new Vector3(1f, 0, 0);
            Debug.DrawRay(raycastStart, Vector3.down * hitCheckBrick.distance, Color.black, 20f);
            Debug.Log("Did hitCheckBrick");
            if (Physics.Raycast(raycastStart, Vector3.down, out hitCheckBrick, 10f, brickLayer))
            {
                transform.position = Vector3.MoveTowards(transform.position, raycastStart, Time.deltaTime * speed);
            }

        }
        else if (direction.x < 0)
        {
            raycastStart = transform.position + new Vector3(-1f, 0, 0);
            Debug.DrawRay(raycastStart, Vector3.down * hitCheckBrick.distance, Color.black, 20f);
            Debug.Log("Did hitCheckBrick");
            if (Physics.Raycast(raycastStart, Vector3.down, out hitCheckBrick, 10f, brickLayer))
            {
                transform.position = Vector3.MoveTowards(transform.position, raycastStart, Time.deltaTime * speed);
            }

        }
        else if (direction.y > 0)
        {
            raycastStart = transform.position + new Vector3(0, 0, 1f);
            Debug.DrawRay(raycastStart, Vector3.down * hitCheckBrick.distance, Color.black, 20f);
            Debug.Log("Did hitCheckBrick");
            if (Physics.Raycast(raycastStart, Vector3.down, out hitCheckBrick, 10f, brickLayer))
            {
                transform.position = Vector3.MoveTowards(transform.position, raycastStart, Time.deltaTime * speed);
            }

        }
        else if (direction.y < 0)
        {
            raycastStart = transform.position + new Vector3(0, 0, -1f);
            Debug.DrawRay(raycastStart, Vector3.down * hitCheckBrick.distance, Color.black, 20f);
            Debug.Log("Did hitCheckBrick");
            if (Physics.Raycast(raycastStart, Vector3.down, out hitCheckBrick, 10f, brickLayer))
            {
                transform.position = Vector3.MoveTowards(transform.position, raycastStart, Time.deltaTime * speed);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Brick"))
        //{
        //    //Nhấc playerImg lên 0.1f
        //    playerImg.transform.position += new Vector3(0, 0.1f, 0);
        //    //Nhét brick xuống dưới
        //    other.transform.parent = playerImg.transform;
        //    other.transform.localPosition = new Vector3(0, playerImg.transform.position.y * -1, 0);
        //}
        if (other.CompareTag("BrickEnd"))
        {
            LevelManager.Instance.currentMap +=1;
            GameManager.Instance.ChangeState(new EndState());

        }

    }
}
