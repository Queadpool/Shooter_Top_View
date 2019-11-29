using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateController : MonoBehaviour
{
    public enum EEnemyState
    {
        SPAWN,
        ALIVE,
        DEAD
    }

    [SerializeField] private EEnemyState _currentState = EEnemyState.SPAWN;
    [SerializeField] private Renderer _enemyRend = null;
    [SerializeField] private NavMeshAgent _enemyNav = null;
    [SerializeField] private bool _isDead = false;

    public EEnemyState CurrentState { get { return _currentState; } }
    public Renderer EnemyRend { get { return _enemyRend; } }
    public NavMeshAgent EnemyNav { get { return _enemyNav; } }
    public bool IsDead { get { return _isDead; } }

    Dictionary<EEnemyState, IBaseState> _states = null;

    void Start()
    {
        _enemyRend = GetComponent<Renderer>();
        _enemyNav = GetComponent<NavMeshAgent>();

        _states = new Dictionary<EEnemyState, IBaseState>();
        _states.Add(EEnemyState.SPAWN, new SpawnState(this));
        _states.Add(EEnemyState.ALIVE, new AliveState(this));
        _states.Add(EEnemyState.DEAD, new DeadState(this));
        _states[_currentState].Enter();
    }

    void Update()
    {
        _states[_currentState].Update();
    }

    public void ChangeState(EEnemyState nextState)
    {
        _states[_currentState].Exit();
        _states[nextState].Enter();
        _currentState = nextState;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            _isDead = true;
            Destroy(other.gameObject);
        }

        if(other.tag == "Player")
        {
            if (!_isDead)
            {
            Destroy(other.gameObject);
            }
        }
    }
}
