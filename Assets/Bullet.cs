using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Explosion;
    public float damage = 10f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            print("Player");
            collision.collider.GetComponent<Player>().TakeHit(damage);

        }


        Instantiate(Explosion, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);

    }

}
