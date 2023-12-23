using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : IState
{
    // Start is called before the first frame update
    private PlayerMove playerMove;
    public void OnEnter(GameManager gameManager)
    {
        // Lấy playerMove và bật chế độ di chuyển
        GameObject player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();
        playerMove.enabled = true;
    }
    public void OnExecute(GameManager gameManager)
    {
        
    }
    public void OnExit(GameManager gameManager)
    {

    }
}
