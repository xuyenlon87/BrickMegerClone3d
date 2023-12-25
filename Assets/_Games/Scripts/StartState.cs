using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : IState
{
    private PlayerMove playerMove;
    float timer = 0;
    public void OnEnter(GameManager gameManager)
    {
        LevelManager.Instance.DrawMap();
        GameObject player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();
        playerMove.enabled = false;
    }
    public void OnExecute(GameManager gameManager)
    {
        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {

            gameManager.ChangeState(new PlayState());
        }
    }
    public void OnExit(GameManager gameManager)
    {
        

    }
}
