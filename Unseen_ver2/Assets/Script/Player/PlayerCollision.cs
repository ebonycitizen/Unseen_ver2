using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    public event EventHandler OnDead = delegate { };
    public event EventHandler OnReachGoal = delegate { };

    void Start () {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("OutArea"))
        {
            OnDead(this, EventArgs.Empty);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            OnReachGoal(this, EventArgs.Empty);
        }
    }
}
