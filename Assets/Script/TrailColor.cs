using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailColor : MonoBehaviour
{
    ParticleSystem LeftTrail;
    ParticleSystem RightTrail;
    GameObject Player;
    private char CurrentDirection = 'g';

    void Start()
    {
        LeftTrail = transform.Find("LeftTrail").GetComponent<ParticleSystem>();
        RightTrail = transform.Find("RightTrail").GetComponent<ParticleSystem>();

        Player = GameObject.Find("Player");

        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.red, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
    }

    private void Update()
    {
        if(CurrentDirection != Player.GetComponent<PlayerControl>().direction)
        {
            CurrentDirection = Player.GetComponent<PlayerControl>().direction;

            Gradient grad = new Gradient();
            Color CurrentColor = Player.GetComponent<PlayerColor>().PlayerMaterial.color;
            grad.SetKeys(new GradientColorKey[] { new GradientColorKey(CurrentColor, 0.0f), new GradientColorKey(CurrentColor, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });

            var LeftTrialColorOverLifeTime = LeftTrail.colorOverLifetime;
            var RightTrialColorOverLifeTime = RightTrail.colorOverLifetime;

            LeftTrialColorOverLifeTime.color = grad;
            RightTrialColorOverLifeTime.color = grad;
        }
    }
}
