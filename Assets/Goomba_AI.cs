using PC2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba_AI : MonoBehaviour
{
    public bool IsAbleToMove = true;
    public bool IsMovingRight = true;
    public PlatformerMotor2D charController;
    public Animator GoombaAnimator;

    public GameObject VisualChild;
    SpriteRenderer Sprite;


    public bool IsDead = false;
    public float DamageOnHit = 50f;

    public float AboutFaceDistance = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        if (this.charController == null)
            this.charController = this.GetComponent<PlatformerMotor2D>();

        if (this.VisualChild == null)
        {
            this.Sprite = this.GetComponentInChildren<SpriteRenderer>();
            VisualChild = Sprite.gameObject;
        }
        else {
            this.Sprite = VisualChild.GetComponent<SpriteRenderer>();
        }

        if (this.GoombaAnimator == null)
            this.GoombaAnimator = this.GetComponentInChildren<Animator>();
        //AboutFaceDistance += this.GetComponent<BoxCollider2D>().size.x / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        var signedMovement = IsMovingRight ? 1 : -1;
        if (IsAbleToMove && !IsDead)
        {
            this.charController.normalizedXMovement = signedMovement;
        }
        else {
            this.charController.normalizedXMovement = 0f;
            if (IsDead)
            {
                deadUpdate();
            }
        }


        RaycastHit2D hit = Physics2D.Raycast(
                            transform.position,
                            transform.right * signedMovement,
                            AboutFaceDistance,
                            Globals.ENV_MASK);

        if (hit.collider != null)
        {
            IsMovingRight = !IsMovingRight;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsDead)
        {
            var go = collision.gameObject;
            if (go.CompareTag("Player"))
            {
                var pc2d = go.GetComponent<PlatformerMotor2D>();
                if (pc2d.velocity.y < 0) // Falling
                {
                    die();
                }
                else
                { // Hit Player
                    var player = go.GetComponent<Player>();
                    player.TakeHit(DamageOnHit);
                }
            }
        }
    }

    void deadUpdate()
    {
        Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, Sprite.color.a - (.5f * Time.deltaTime));
    }
    void die()
    {
        this.IsDead = true;
        GoombaAnimator.Play("Goomba_Dead");
        Destroy(this.gameObject, 3f);
    }

}
