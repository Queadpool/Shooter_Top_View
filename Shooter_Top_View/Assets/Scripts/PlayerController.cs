using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _gun = null;
    [SerializeField] private GameObject _akimbo = null;
    [SerializeField] private GameObject _shotGun = null;
    [SerializeField] private GameObject _gunSprite = null;
    [SerializeField] private GameObject _akimboSprite = null;
    [SerializeField] private GameObject _shotGunSprite = null;
    [SerializeField] private Image _gunSpriteRed = null;
    [SerializeField] private float _fireRate = 0.0f;
    [SerializeField] private AudioClip _clip = null;
    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private int _xp = 0;
    private Vector3 _moveInput = Vector3.zero;
    private Vector3 _moveVelocity = Vector3.zero;
    private Rigidbody _myRigidbody = null;

    public float FireRate { get { return _fireRate; } }
    public AudioClip Clip { get { return _clip; } }
    public Image CurrentSprite { get { return _gunSpriteRed; } }

    void Start()
    {
        _myRigidbody = GetComponent<Rigidbody>();
        _fireRate = 0.3f;
        _clip = DatabaseManager.Instance.Database.SoundData.GunAudio;
        _gun.SetActive(true);
        _gunSprite.SetActive(true);
    }

    void Update()
    {
        _moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        _moveVelocity = _moveInput * _moveSpeed;

        Vector3 lookDirection = new Vector3(Input.GetAxisRaw("HorizontalR"), 0, Input.GetAxisRaw("VerticalR"));

        if (lookDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }

    public void LevelUp()
    {
        _xp++;

        if(_xp >= 5)
        {
            _fireRate = 1.6f;
            _clip = DatabaseManager.Instance.Database.SoundData.ShotGunAudio;
            _gun.SetActive(false);
            _akimbo.SetActive(false);
            _akimboSprite.SetActive(false);
            _shotGun.SetActive(true);
            _shotGunSprite.SetActive(true);
        }
        else if(_xp == 2)
        {
            _fireRate = 0.1f;
            _clip = DatabaseManager.Instance.Database.SoundData.AkimboAudio;
            _gunSprite.SetActive(false);
            _akimbo.SetActive(true);
            _akimboSprite.SetActive(true);
        }
    }



    private void FixedUpdate()
    {
        _myRigidbody.velocity = _moveVelocity;
    }
}
