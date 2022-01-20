using UnityEngine;
public class BombController : MonoBehaviour
{
    private CircleCollider2D BombCollider;
    private SpriteRenderer BombSpriteRenderer;
    private PlayerController PlayerControllerScript;

    public Sprite ExplosionSprite;

    private void Start()
    {
        PlayerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        BombCollider = this.gameObject.GetComponentInChildren<CircleCollider2D>();
        BombCollider.isTrigger = true;
        BombCollider.enabled = false;
        BombSpriteRenderer = this.gameObject.GetComponentInChildren<SpriteRenderer>();

        Invoke(nameof(Explosion), 5f);
    }

    private void Explosion()
    {
        BombCollider.enabled = true;
        BombSpriteRenderer.sprite = ExplosionSprite;
        PlayerControllerScript._bombCount--;
        Destroy(this.gameObject, 1.1f);
    }
}
