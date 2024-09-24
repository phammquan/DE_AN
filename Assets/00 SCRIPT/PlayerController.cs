using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private float _speed, _speedcheck;
    [SerializeField] private float jumpForce;
    Rigidbody2D _rigi;
    [SerializeField] private bool isGrounded;
    [SerializeField] PlayerState _playerState = PlayerState.IDEL;
    public PlayerState playerState => _playerState;
    Anim _anim;
    void Start()
    {
        _rigi = GetComponent<Rigidbody2D>();
        _speedcheck = _speed;
        _anim = this.transform.GetChild(0).gameObject.GetComponent<Anim>();
    }

    void Update()
    {
        move();
        UpdateState();
        _anim.UpdateAnimation(_playerState);
    }
    void move()
    {
        _rigi.velocity = new Vector2(_speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime, _rigi.velocity.y);
        if (isGrounded)
        {
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetAxisRaw("Vertical") == 1)
            {
                _rigi.velocity = new Vector2(_rigi.velocity.x, jumpForce);
                isGrounded = false;
                _rigi.gravityScale = 3;
                _speed /= 2;
            }
        }
        if(_rigi.velocity.x > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_rigi.velocity.x < 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
            _rigi.gravityScale = 1;
            if (_speed != _speedcheck)
            {
                _speed *= 2;
            }
        }
        else
        {
            isGrounded = false;


        }
    }
     public enum PlayerState
    {
        IDEL,
        RUN,
        JUMP
    }
    void UpdateState()
    {
        if(_rigi.velocity.x != 0 && isGrounded)
        {
            _playerState = PlayerState.RUN;
        }
        else if (!isGrounded)
        {
            _playerState = PlayerState.JUMP;
        }
        else
        {
            _playerState = PlayerState.IDEL;
        }
    }
     
}
