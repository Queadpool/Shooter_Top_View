using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QQ/Database/SoundData")]
public class SoundData : ScriptableObject
{
    [SerializeField] private AudioClip _gunAudio = null;
    [SerializeField] private AudioClip _akimboAudio = null;
    [SerializeField] private AudioClip _shotGunAudio = null;

    public AudioClip GunAudio { get { return _gunAudio; } }
    public AudioClip AkimboAudio { get { return _akimboAudio; } }
    public AudioClip ShotGunAudio { get { return _shotGunAudio; } }
}
