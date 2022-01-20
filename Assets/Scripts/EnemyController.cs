using UnityEngine;
public class EnemyController : MonoBehaviour
{
    private GameManager GameManagerScript;
    private GameObject Enemy;
    [HideInInspector] public Rigidbody2D EnemyRigidBody;
    private BoxCollider2D EnemyCollider;
    private SpriteRenderer EnemySpriteRenderer;
    private Vector3 dir;

    public Sprite[] _enemySprites;
    public bool _horizontalMove;

    void Awake()
    {
        GameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Enemy = this.gameObject;
        EnemySpriteRenderer = this.gameObject.GetComponentInChildren<SpriteRenderer>();
        EnemyRigidBody = Enemy.GetComponent<Rigidbody2D>();
        EnemyCollider = Enemy.GetComponent<BoxCollider2D>();

        if (_horizontalMove)
        {
            dir = transform.right;
            EnemySpriteRenderer.sprite = _enemySprites[0];
        }
        else
        {
            dir = transform.up;
            EnemySpriteRenderer.sprite = _enemySprites[3];
        }
    }

    void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        if ((transform.position.x > 7f || transform.position.x < -8f) && _horizontalMove)
        {
            if (transform.position.x > 7f)
                EnemySpriteRenderer.sprite = _enemySprites[1];
            if (transform.position.x < -8f)
                EnemySpriteRenderer.sprite = _enemySprites[0];

            dir *= -1f;
        }
        else if ((transform.position.y > 1.75f || transform.position.y < -1.75f) && !_horizontalMove)
        {
            if (transform.position.y > 1.75f)
                EnemySpriteRenderer.sprite = _enemySprites[2];
            if (transform.position.y < -1.75f)
                EnemySpriteRenderer.sprite = _enemySprites[3];

            dir *= -1f;
        }
            
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bomb")
        {
            Destroy(this.gameObject);
        }
    }
}
