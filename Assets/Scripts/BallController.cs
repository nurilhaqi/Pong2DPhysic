using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Launch();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? - 1 : 1;
        float y = Random.Range(0, 2) == 0 ? - 1 : 1;
        rig.velocity = new Vector2(speed * x, speed * y);
    }

}
