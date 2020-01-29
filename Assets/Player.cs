using PC2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerController2D))]
public class Player : MonoBehaviour
{
    
    PlatformerMotor2D Motor;
    PlayerController2D Controller;
    PlatformerAnimation2D Animator;

    public float Health = 100f;
    // Start is called before the first frame update
    void Start()
    {
    
        if (Motor == null)
            Motor = this.GetComponent<PlatformerMotor2D>();

        if (Controller == null)
            Controller = this.GetComponent<PlayerController2D>();

        if (Animator == null)
            Animator = this.GetComponent<PlatformerAnimation2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    // Update is called once per frame
    void Update()
    {
                    
    }

    public void TakeHit(float damage)
    {
        Health -= damage;
    }

}
