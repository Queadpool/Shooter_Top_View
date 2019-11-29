using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QQ/Database")]
public class Database : ScriptableObject
{
    [SerializeField] private GameObject _enemy0 = null;
    [SerializeField] private GameObject _bullet = null;
    [SerializeField] private SoundData _soundData = null;

    public GameObject Enemy0 { get { return _enemy0; } }
    public GameObject Bullet { get { return _bullet; } }
    public SoundData SoundData { get { return _soundData; } }
}