using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveState : IBaseState
{
    private EnemyStateController _controller = null;
    private Color _colorAlive = Color.red;

    public AliveState(EnemyStateController controller)
    {
        _controller = controller;
    }

    public void Enter()
    {
        _controller.EnemyRend.material.color = _colorAlive;
    }

    public void Update()
    {
        _controller.EnemyNav.SetDestination(PlayerManager.Instance.Player.transform.position);

        if (_controller.IsDead)
        {
            _controller.ChangeState(EnemyStateController.EEnemyState.DEAD);

        }
    }

    public void Exit()
    {

    }
}