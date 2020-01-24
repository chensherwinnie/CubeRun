using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour{

    private Dictionary<char, Quaternion> Direction = new Dictionary<char, Quaternion>();
    private Dictionary<char, Vector3> Offset = new Dictionary<char, Vector3>();

    private Vector3 offset = new Vector3(0, 2, -5);
    private GameObject playerObj;
    private Rigidbody player;
    private char direction;
    Vector3 refPos;

    float smooth = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
      playerObj = GameObject.Find("Player");
      player = playerObj.GetComponent<Rigidbody> ();
      direction = playerObj.GetComponent<PlayerControl> ().direction;

      Direction.Add('g', Quaternion.Euler(0, 0, 0f));
      Direction.Add('r', Quaternion.Euler(0, 0, 90f));
      Direction.Add('l', Quaternion.Euler(0, 0, -90f));
      Direction.Add('c', Quaternion.Euler(0, 0, 180f));

      Offset.Add('g', new Vector3(0, 2, -5));
      Offset.Add('r', new Vector3(-2, 0, -5));
      Offset.Add('l', new Vector3(2, 0, -5));
      Offset.Add('c', new Vector3(0, -2, -5));
    }

    // Update is called once per frame
    void Update(){
      direction = playerObj.GetComponent<PlayerControl>().direction;

      if(direction != playerObj.GetComponent<PlayerControl>().direction){
        transform.position = Vector3.SmoothDamp(transform.position, player.position + Offset[direction], ref refPos, 5 * Time.deltaTime);
        direction = playerObj.GetComponent<PlayerControl>().direction;
      }
      else{
        transform.position = player.position + Offset[direction];
      }

      transform.rotation = Quaternion.Slerp(transform.rotation, Direction[direction], 5 * Time.deltaTime);
    }
}
