using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            print("Player");
        }


        Instantiate(Explosion, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);

    }

}
