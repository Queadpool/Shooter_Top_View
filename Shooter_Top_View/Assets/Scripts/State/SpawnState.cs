using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QQ.Utils;

public class SpawnState : IBaseState
{
    private EnemyStateController _controller = null;
    private Timer _timer = null;
    private float _timerSpawn = 2.0f;
    private Color _colorSpawn = Color.white;
    private Color _colorAlive = Color.red;                          
    
    public SpawnState(EnemyStateController controller)
    {
        _controller = controller;
    }

    public void Enter()
    {
        _timer = new Timer();
        _timer.ResetTimer(_timerSpawn);
        _controller.EnemyRend.material.color = _colorSpawn;
    }

    public void Update()
    {
        float lerp = (_timerSpawn - _timer.TimeLeft) / _timerSpawn;
        _controller.EnemyRend.material.color = Color.Lerp(_colorSpawn, _colorAlive, lerp);

        if(_timer.TimeLeft <= 0)
        {
            _controller.ChangeState(EnemyStateController.EEnemyState.ALIVE);
        }

        if (_controller.IsDead)
        {
            _controller.ChangeState(EnemyStateController.EEnemyState.DEAD);

        }
    }

    public void Exit()
    {

    }
}
