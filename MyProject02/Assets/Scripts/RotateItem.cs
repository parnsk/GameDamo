using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    public float speed = 80;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, speed * Time.deltaTime, 0f);
    }
}
