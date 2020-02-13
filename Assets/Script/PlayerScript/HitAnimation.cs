using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * This Script is in charge of the ContactAnimation's Rotation and Color Change
 */
public class HitAnimation : MonoBehaviour
{
    private Dictionary<char, Quaternion> Direction = new Dictionary<char, Quaternion>();
    private GameObject Player;
    private char CurrentDirection = 'g';
    private Animator ContactAnimation;
    public float YRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        ContactAnimation = GetComponent<Animator>();
        Player = GameObject.Find("Player");

        Direction.Add('g', Quaternion.Euler(90f, YRotation, 0f));
        Direction.Add('r', Quaternion.Euler(0, 90f, YRotation));
        Direction.Add('l', Quaternion.Euler(0, 90f, YRotation));
        Direction.Add('c', Quaternion.Euler(90f, YRotation, 0));
    }

    void Update()
    {
        if(CurrentDirection != GameObject.Find("Player").GetComponent<PlayerControl>().direction)
        {
            Debug.Log("Changes direction");
            CurrentDirection = GameObject.Find("Player").GetComponent<PlayerControl>().direction;
            transform.rotation = Direction[CurrentDirection];
            GetComponent<SpriteRenderer>().color = Player.GetComponent<PlayerColor>().PlayerMaterial.color;
            StartCoroutine(PlayContactAnimation());
            ContactAnimation.Play("ContactAnimation", -1, 0f);
        }
    }

    /*
     * Play ContactAnimation
     * And wait for 0.4 second (time require to finish the animation)
     */

    IEnumerator PlayContactAnimation()
    {
        ContactAnimation.Play("ContactAnimation");
        yield return new WaitForSeconds(0.4f);
    }
}
