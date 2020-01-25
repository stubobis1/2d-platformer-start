using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Target;
    public GameObject Bullet;
    public Transform FirePos;

    public float FirePower = 500f;
    public float FireCooldown = 1f;

    public float MinimumDistance = 35f;

    public bool AbleToFire = true;
    void Start()
    {
        nextTimeToSwitch = Time.time + FireCooldown;
        if (Target == null)
            Target = FindObjectOfType<PlayerController2D>().gameObject;

        //This is for 2D
        //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
    }

    float nextTimeToSwitch;
    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(Target.transform,Vector3.one);


        if (AbleToFire && Time.time > nextTimeToSwitch)
        {
            if (Vector2.Distance(Target.transform.position, this.transform.position) < MinimumDistance)
            {
                nextTimeToSwitch = Time.time + FireCooldown;
                Fire();
            }
        }
    }


    public void Fire()
    {
        var pos3 = new Vector3(FirePos.position.x, FirePos.position.y, 0f); ;
        var bullet = Instantiate(Bullet, pos3, Quaternion.identity);
        var dir3 = this.transform.forward * FirePower;
        var dir2 = new Vector2(dir3.x, dir3.y).normalized;
        var rb  = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(dir2 * rb.mass * FirePower,ForceMode2D.Force);
    }
}
