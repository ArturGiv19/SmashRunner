using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereEnemy : MonoBehaviour
{
    private Rigidbody rigidbody;
    private SphereCollider sphereCollider;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sphereCollider.isTrigger = false;
            sphereCollider.radius = 0.5f;
            rigidbody.isKinematic = false;
            rigidbody.AddRelativeForce(-transform.forward * 1000);
            StartCoroutine(StaticClass.CustomDelay(0.1f, (() => { gameObject.tag = "Enemy"; })));
            StartCoroutine(StaticClass.CustomDelay(5f, (() => { gameObject.SetActive(false); }))); // Або можна буде повертати до пулу і використовувати повторно
        }
    }
}
