using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] LayerMask brickLayer;
    [SerializeField] GameObject foot;
    private Vector3 mousePositionStart, mousePositionEnd;
    private Vector3 raycastStart;
    private RaycastHit hitCheckBrick;


    void Start()
    {

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
            raycastStart = transform.position + new Vector3(0.5f, 0, 0);
            Debug.DrawRay(raycastStart, Vector3.down * hitCheckBrick.distance, Color.yellow);
            Debug.Log("Did hitCheckBrick");
            if (Physics.Raycast(raycastStart, Vector3.down, out hitCheckBrick, 10f, brickLayer))
            {
                transform.position = Vector3.MoveTowards(transform.position, raycastStart, Time.deltaTime * speed);
            }

        }
        else if (direction.x < 0)
        {
            raycastStart = transform.position + new Vector3(-0.5f, 0, 0);
            Debug.DrawRay(raycastStart, Vector3.down * hitCheckBrick.distance, Color.yellow);
            Debug.Log("Did hitCheckBrick");
            if (Physics.Raycast(raycastStart, Vector3.down, out hitCheckBrick, 10f, brickLayer))
            {
                transform.position = Vector3.MoveTowards(transform.position, raycastStart, Time.deltaTime * speed);
            }

        }
        else if (direction.y > 0)
        {
            raycastStart = transform.position + new Vector3(0,0,0.5f);
            Debug.DrawRay(raycastStart, Vector3.down * hitCheckBrick.distance, Color.yellow);
            Debug.Log("Did hitCheckBrick");
            if (Physics.Raycast(raycastStart, Vector3.down, out hitCheckBrick, 10f, brickLayer))
            {
                transform.position = Vector3.MoveTowards(transform.position, raycastStart, Time.deltaTime * speed);
            }

        }
        else if (direction.y < 0)
        {
            raycastStart = transform.position + new Vector3(0, 0, -0.5f);
            Debug.DrawRay(raycastStart, Vector3.down * hitCheckBrick.distance, Color.yellow);
            Debug.Log("Did hitCheckBrick");
            if (Physics.Raycast(raycastStart, Vector3.down, out hitCheckBrick, 10f, brickLayer))
            {
                transform.position = Vector3.MoveTowards(transform.position, raycastStart, Time.deltaTime * speed);
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Brick"))
        {
            other.GetComponent<Collider>().isTrigger = false;
            other.transform.parent = transform.GetChild(0);
            other.transform.position = Vector3.zero;
            transform.Translate(0, transform.position.y + 0.1f, 0);
        }
    }
}
