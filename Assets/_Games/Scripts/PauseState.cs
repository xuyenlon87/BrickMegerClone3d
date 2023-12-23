using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : MonoBehaviour
{
    private PlayerMove playerMove;
    
    // Start is called before the first frame update
    public void OnEnter(GameManager gameManager)
    {
        // Lấy playerMove và bật chế độ di chuyển
        GameObject player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();
        playerMove.enabled = false;
    }
    public void OnExecute(GameManager gameManager)
    {

    }
    public void OnExit(GameManager gameManager)
    {

    }
}
