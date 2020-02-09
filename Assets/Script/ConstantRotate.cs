using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotate : MonoBehaviour
{

    public float speedX = 0f;
    public float speedY = 0f;
    public float speedZ = 50f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speedX * Time.deltaTime, speedY * Time.deltaTime, speedZ * Time.deltaTime);
    }
}
