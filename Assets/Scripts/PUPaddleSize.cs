using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleSize : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D ball;
    public PaddleController[] paddle;
   public float multiplier;

   public PowerUpManager manager;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other == ball)
        {
            foreach (var p in paddle)
            {
                p.ChangeSize(multiplier);    
            }
            manager.RemovePowerUp(gameObject);
        }
    }
}
