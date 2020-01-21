using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryTimer : MonoBehaviour
{
    public float timeToLive = 1f;

    float destoryTime;
    void Start()
    {
        destoryTime = Time.time + timeToLive;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > destoryTime)
            Destroy(this.gameObject);
    }
}
