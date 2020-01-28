using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{

    private bool isRewinding = false;
    List<Vector3> PlayerPosition;

    Color PlayerNormalColor = new Color(156 / 255f, 66 / 255f, 183 / 255f); //A reddish color
    Color PlayerRewindColor = new Color(236 / 255f, 71 / 255f, 66 / 255f); // A purplish color

    void Start()
	{
        PlayerPosition = new List<Vector3>();
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Return))
		{
            GetComponent<Renderer>().material.color = Color.Lerp(PlayerNormalColor, PlayerRewindColor, Mathf.PingPong(Time.time, 0.5f));
            isRewinding = true;
		}
		if (Input.GetKeyUp(KeyCode.Return))
		{
            GetComponent<Renderer>().material.color = Color.Lerp(PlayerRewindColor, PlayerNormalColor, Mathf.PingPong(Time.time, 0.5f));
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
        PlayerPosition.Insert(0, transform.position);
        if(PlayerPosition.Count > 5000)
        {
            PlayerPosition.RemoveAt(PlayerPosition.Count - 1);
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
