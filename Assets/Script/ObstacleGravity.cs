using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGravity : MonoBehaviour
{
    private int ForceConstant = 16;
    public char ObjectType;
    private Rigidbody rb;
    private Dictionary<char, Vector3> Force = new Dictionary<char, Vector3>();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Force.Add('r', Vector3.left * ForceConstant);
        Force.Add('l', Vector3.right * ForceConstant);
        Force.Add('g', Vector3.down * ForceConstant);
        Force.Add('c', Vector3.up * ForceConstant);
        Force.Add('z', Vector3.zero);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Force[ObjectType]);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Player")
        {
            ObjectType = 'z';
        }
    }
}
