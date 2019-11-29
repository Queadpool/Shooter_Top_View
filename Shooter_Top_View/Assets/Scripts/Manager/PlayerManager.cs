using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QQ.Utils;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private PlayerController _player = null;

    public PlayerController Player { get { return _player; } }
}
