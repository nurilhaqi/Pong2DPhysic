using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleSpeed : MonoBehaviour
{
    public Collider2D ball;
    public PaddleController[] paddle;
    public int multiplier;

    public PowerUpManager manager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == ball)
        {
            foreach (var p in paddle)
            {
                p.ChangeSpeed(multiplier);
            }
            manager.RemovePowerUp(gameObject);
        }
    }
}
