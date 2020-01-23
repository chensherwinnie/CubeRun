using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    private GameObject playerObj;
    private char rotation;

    private Dictionary<char, Quaternion> Rotation = new Dictionary<char, Quaternion>();

    void Start(){
      playerObj = GameObject.Find("Player");
      Rotation.Add('g', Quaternion.Euler(30, 0, 0));
      Rotation.Add('c', Quaternion.Euler(-30, 0, 0));
      Rotation.Add('r', Quaternion.Euler(0, 30, 0));
      Rotation.Add('l', Quaternion.Euler(0, -30, 0));
    }

     // Update is called once per frame
    void Update()
    {
      rotation = playerObj.GetComponent<PlayerControl> ().direction;
      transform.rotation = Quaternion.Slerp(transform.rotation, Rotation[rotation], 5 * Time.deltaTime);
    }
}
