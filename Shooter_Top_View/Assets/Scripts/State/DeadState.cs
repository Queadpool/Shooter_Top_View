using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IBaseState
{
    private EnemyStateController _controller = null;
    private Color _colorDead = Color.black;

    public DeadState(EnemyStateController controller)
    {
        _controller = controller;
    }

    public void Enter()
    {
        _controller.EnemyRend.material.color = _colorDead;
        _controller.EnemyNav.ResetPath();
        PlayerManager.Instance.Player.LevelUp();
    }

    public void Update()
    {

    }

    public void Exit()
    {

    }
}