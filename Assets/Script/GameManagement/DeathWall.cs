using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathWall : MonoBehaviour
{
    public bool PlayerIsDead = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            PlayerIsDead = true;
        }
    }
}
