using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScript : MonoBehaviour
{
    public float ballSpeed = 1;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.acceleration.x * ballSpeed, Input.acceleration.y*ballSpeed, 0);
        if (myabs(Input.acceleration.x) > .5 || myabs(Input.acceleration.y) > .5)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    public void setBlack()
    {
        GetComponent<SpriteRenderer>().color = Color.black;
    }

    float myabs(float input)
    {
        if (input >= 0) return input;
        return -input;
    }
  
}
