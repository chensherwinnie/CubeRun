using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerState : MonoBehaviour
{
    public bool PlayerIsDead = false;
    GameObject[] allChildren;

    void Start()
    {
        allChildren = new GameObject[transform.childCount];
        int i = 0;
        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }
    }

    private void Update()
    {
        foreach(GameObject child in allChildren)
        {
            PlayerIsDead = child.GetComponent<DeathWall>().PlayerIsDead;
            if (PlayerIsDead)
            {
                break;
            }
        }
    }

    public void PlayerRevive()
    {
        foreach (GameObject child in allChildren)
        {
            child.GetComponent<DeathWall>().PlayerIsDead = false;
        }
    }
}
