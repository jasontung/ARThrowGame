using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour {
    public Collider basketCollider;
    private void OnTriggerEnter(Collider other)
    {
        basketCollider.enabled = false;
        Invoke("DelayEnableCollider", 0.5f);
    }

    private void DelayEnableCollider()
    {
        basketCollider.enabled = true;
    }
}
