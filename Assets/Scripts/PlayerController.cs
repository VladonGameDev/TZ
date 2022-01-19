using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D PlayerRigidBody;
    private BoxCollider2D PlayerCollider;
    private SpriteRenderer PlayerSpriteRenderer;

    public Joystick joystick;
    public Sprite[] _playerSprites;
    public float _playerSpeed;
    public GameObject _bomb;


    void Awake()
    {
        Player = this.gameObject;
        PlayerSpriteRenderer = this.gameObject.GetComponentInChildren<SpriteRenderer>();
        PlayerRigidBody = Player.GetComponent<Rigidbody2D>();
        PlayerCollider = Player.GetComponentInChildren<BoxCollider2D>();
    }

    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        PlayerRigidBody.velocity = new Vector2(joystick.Horizontal*_playerSpeed, joystick.Vertical*_playerSpeed);
        if(joystick.Horizontal > 0.5f)
        {
            PlayerSpriteRenderer.sprite = _playerSprites[0];
            PlayerCollider.size = new Vector2(5.75f, 3f);
        }
        if (joystick.Horizontal < -0.5f)
        {
            PlayerSpriteRenderer.sprite = _playerSprites[2];
            PlayerCollider.size = new Vector2(5.75f, 3f);
        }
        if (joystick.Vertical > 0.5f)
        {
            PlayerSpriteRenderer.sprite = _playerSprites[3];
            PlayerCollider.size = new Vector2(3f, 5.75f);
        }
        if (joystick.Vertical < -0.5f)
        {
            PlayerSpriteRenderer.sprite = _playerSprites[1];
            PlayerCollider.size = new Vector2(3f, 5.75f);
        }
    }
    public void DropBomb()
    {
        Instantiate(_bomb, Player.transform.position, Quaternion.identity);
    }
}


