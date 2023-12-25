using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : IState
{
    private PlayerMove playerMove;
    private float timer = 0;
    // Start is called before the first frame update
    public void OnEnter(GameManager gameManager)
    {
        
    }
    public void OnExecute(GameManager gameManager)
    {
        timer += Time.deltaTime;
        // Lấy playerMove và bật chế độ di chuyển
        GameObject player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();
        playerMove.enabled = false;
        if (timer >= 2f)
        {
            gameManager.ChangeState(new StartState());
        }
    }
    public void OnExit(GameManager gameManager)
    {
        
    }
}
