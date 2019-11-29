using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QQ.Utils;

public class Spawner : MonoBehaviour
{
    private Timer _timer = null;
    [SerializeField] private float _timerSpawn = 5.0f;
    [SerializeField] private Transform _spawnerPoint = null;

    void Start()
    {
        _timer = new Timer();
    }

    void Update()
    {
        if (_timer.TimeLeft <= 0)
        {
            _timer.ResetTimer(_timerSpawn);
            GameObject enemy = DatabaseManager.Instance.Database.Enemy0;
            if (enemy == null)
            {
                Debug.LogError("Missing target Reference");
            }
            else
            {
                GameObject newEnemy = Instantiate(enemy);
                newEnemy.transform.position = _spawnerPoint.position;
            }
        }
    }
}
