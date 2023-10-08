using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rig;
    private bool isOnPU;
    private Vector2 tempScale;
    private int tempSpeed;
    private float durationCooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement=GetInput();
        MoveObject(movement);
    }

    private Vector2 GetInput()
    {

        if (Input.GetKey(upKey))
        {
            return Vector2.up * speed;

        }
        else if (Input.GetKey(downKey))
        {
            return Vector2.down * speed;

        }
        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        rig.velocity = movement;
    }

    public void ChangeSize(float multiplier)
    {
        if (!isOnPU)
        {
            transform.localScale = new Vector3(tempScale.x, tempScale.y * multiplier);
            isOnPU = true;
        }
    }
    public void ChangeSpeed(int multiplier)
    {
        if (!isOnPU)
        {
            speed *= multiplier;
            isOnPU = true;
        }
    }

    private void PUDuration(float duration)
    {
        durationCooldown += Time.deltaTime;
        if (durationCooldown >= duration)
        {
            isOnPU = false;
            durationCooldown = 0;
            RemovePUEffect();
        }
    }

    private void RemovePUEffect()
    {
        transform.localScale = tempScale;
        speed = tempSpeed;
    }
}
