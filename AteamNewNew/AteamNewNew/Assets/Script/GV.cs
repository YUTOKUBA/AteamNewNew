using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GV : MonoBehaviour
{
    public Vector3 velocity;
    public Rigidbody rb;
    private Vector3 lastvelocity;


    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();

        velocity = Vector3.zero;

        rb.mass = 1;
        rb.drag = 0;
        rb.angularDrag = 0.05f;
        rb.isKinematic = false;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.constraints = RigidbodyConstraints.None;
    }

    void FixedUpdate()
    {
        this.lastvelocity = this.rb.velocity;
    }

    void Update()
    {
        Vector3 pos = transform.position;

        //RaycastHit hit;

        //if (Physics.SphereCast(pos, 0.1f, new Vector3(0,0,0),out hit))
        //{
        //    Vector3 refrectVec = Vector3.Reflect(this.lastvelocity, hit.normal);
        //    this.rb.velocity = refrectVec;
        //}

        //velocity += Physics.gravity * Time.deltaTime;

        //transform.position += velocity * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Vector3 refrectVec = Vector3.Reflect(this.lastvelocity, other.contacts[0].normal);
            this.rb.velocity = refrectVec;
        }
    }

}
