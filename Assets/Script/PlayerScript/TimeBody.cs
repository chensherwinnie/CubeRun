using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public bool isRewinding = false;
    List<Vector3> PlayerPosition;
    GameObject player;

    void Start()
	{
        PlayerPosition = new List<Vector3>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Return))
		{
            isRewinding = true;
		}
		if (Input.GetKeyUp(KeyCode.Return))
		{
            isRewinding = false;
		}
    }

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

   void Record()
    {
        if(player.GetComponent<Rigidbody>().velocity != Vector3.zero)
        {
            PlayerPosition.Insert(0, transform.position);
            if (PlayerPosition.Count > 5000)
            {
                PlayerPosition.RemoveAt(PlayerPosition.Count - 1);
            }
        }
    }

    void Rewind()
    {
        if (PlayerPosition.Count != 0)
        {
            transform.position = PlayerPosition[0];
            PlayerPosition.RemoveAt(0);
        }
    }
}
