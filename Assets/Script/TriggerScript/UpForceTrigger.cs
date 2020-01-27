using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpForceTrigger : MonoBehaviour
{
    private float ForceConstant = 40f;
    public char mode;
    Dictionary<char, Vector3> Direction = new Dictionary<char, Vector3>();

    private void Start()
    {
        Direction.Add('u', Vector3.up);
        Direction.Add('d', Vector3.down);
        Direction.Add('r', Vector3.right);
        Direction.Add('l', Vector3.left);
        Direction.Add('f', Vector3.forward);
        Direction.Add('b', Vector3.back);

    }

    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().AddForce(Direction[mode] * ForceConstant, ForceMode.Impulse);
    }
}
