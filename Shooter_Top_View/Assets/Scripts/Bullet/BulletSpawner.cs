using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QQ.Utils;

public class BulletSpawner : MonoBehaviour
{
    private AudioSource _audio = null;
    private AudioClip _clip = null;
    private Timer _timer = null;
    private Image _image = null;
    [SerializeField] private float _fireRate = 0.0f;

    void Start()
    {
        _timer = new Timer();
        _timer.ResetTimer(_fireRate);
        _audio = GetComponent<AudioSource>();
        _fireRate = PlayerManager.Instance.Player.FireRate;
        _clip = PlayerManager.Instance.Player.Clip;
        _image = PlayerManager.Instance.Player.CurrentSprite;
    }

    void Update()
    {
        _image.fillAmount = (_timer.TimeLeft) / _fireRate;
        if (Input.GetButton("Fire"))
        {
            _fireRate = PlayerManager.Instance.Player.FireRate;
            _clip = PlayerManager.Instance.Player.Clip;
            if (_timer.TimeLeft <= 0)
            {
                _timer.ResetTimer(_fireRate);
                _audio.PlayOneShot(_clip);
                GameObject bullet = DatabaseManager.Instance.Database.Bullet;
                if (bullet == null)
                {
                    Debug.LogError("Missing bullet Reference");
                }
                else
                {
                    GameObject newBullet = Instantiate(bullet);
                    newBullet.transform.position = transform.position;
                    newBullet.transform.forward = transform.forward;
                }
            }
        }
    }
}
