using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelrationScript : MonoBehaviour
{
    private float AccelLow = .01f;
    private float AccelSmooting = 0.5f;

    private Vector3 accel = new Vector3(0, 0, 0);
    private Vector3 prevAccel = new Vector3(0, 0, 0);
    public float testNum = 1;
    public float ballSpeed = 1;
    // Update is called once per frame
    private void Start()
    {
        Input.gyro.enabled = true;
    }
    void Update()
    {
        accel.x = (Input.gyro.userAcceleration.x * AccelLow) + (prevAccel.x * (1.0f - AccelLow));
        accel.y = (Input.gyro.userAcceleration.y * AccelLow) + (prevAccel.y * (1.0f - AccelLow));
        Vector3 accelSmooth = Vector3.Lerp(accel, prevAccel, AccelSmooting);
        transform.Translate(accelSmooth.x * ballSpeed, accelSmooth.y*ballSpeed, 0);
        if (Mathf.Abs(Input.gyro.userAcceleration.x) > testNum || Mathf.Abs(Input.gyro.userAcceleration.y) > testNum)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }else{
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        prevAccel = accel;
    }

    public void setBlack()
    {
        GetComponent<SpriteRenderer>().color = Color.black;
    }
}
