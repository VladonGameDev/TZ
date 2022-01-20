using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private GameManager GameManagerScript;
    private GameObject Player;
    [HideInInspector] public Rigidbody2D PlayerRigidBody;
    private BoxCollider2D PlayerCollider;
    private SpriteRenderer PlayerSpriteRenderer;

    [HideInInspector] public int _bombCount;
    public Joystick joystick;
    public Sprite[] _playerSprites;
    public float _playerSpeed;
    public GameObject _bomb;

    void Awake()
    {
        GameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Player = this.gameObject;
        PlayerSpriteRenderer = this.gameObject.GetComponentInChildren<SpriteRenderer>();
        PlayerRigidBody = Player.GetComponent<Rigidbody2D>();
        PlayerCollider = Player.GetComponentInChildren<BoxCollider2D>();
        _bombCount = 0;
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
        if(_bombCount == 0)
        {
            Instantiate(_bomb, Player.transform.position, Quaternion.identity);
            _bombCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Enemy")
        {
            GameManagerScript.Lose();
        }
        if (coll.gameObject.tag == "WinZone")
        {
            GameManagerScript.Win();
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Bomb")
        {
            GameManagerScript.Lose();  
        }
    }
}


