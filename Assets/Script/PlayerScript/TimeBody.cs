using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public bool isRewinding = false;
    public bool PlayerIsDead = false;
    private int RewindSpeed = 1;
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


        PlayerIsDead = transform.Find("DeathWall").GetComponent<DetectPlayerState>().PlayerIsDead;
    }

    private void FixedUpdate()
    {
        if (PlayerIsDead)
        {
            isRewinding = true;
            RewindSpeed = 3;
            if(PlayerPosition.Count == 0)
            {
                PlayerIsDead = false;
                GameObject.Find("DeathWall").GetComponent<DetectPlayerState>().PlayerRevive();
                isRewinding = false;
                RewindSpeed = 1;
            }
        }

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
            PlayerPosition.Insert(0, player.transform.position);
        }
    }

    void Rewind()
    {
        if (PlayerPosition.Count != 0)
        {
            player.transform.position = PlayerPosition[0];
            for(int i = 0; i < RewindSpeed; i++)
                PlayerPosition.RemoveAt(0);
        }
    }
}
