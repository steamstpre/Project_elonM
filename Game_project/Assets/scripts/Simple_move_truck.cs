using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_move_truck : MonoBehaviour
{
    public float move_speed;
    

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(2 * Time.deltaTime * move_speed, 0, 0);
    }
}
