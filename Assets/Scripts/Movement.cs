using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float speed;
    [SerializeField] float xRange = 8.0f;
    [SerializeField] float yRange = 5.0f;
    //pitch means x rotation,yaw means y rotation,roll means z rotation
    [Header("Position")]
    [SerializeField] float PositionPitchFactor=5f;
    [SerializeField] float ControlPitchFactor=5f;
    [SerializeField] float PositionYawFactor=5f;
    [SerializeField] float ControlRollFactor=5f;

    float xOffset, yOffset;
    bool isPlayerAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerAlive)
        {
            PlayerMovement();
            PlayerRotation();
        }
        

    }
    void OnPlayerDeath()
    {
        isPlayerAlive = false;
    }
    private void PlayerMovement()
    {
        float horizontalMove = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalMove = CrossPlatformInputManager.GetAxis("Vertical");

        xOffset = horizontalMove * speed * Time.deltaTime;
        yOffset = verticalMove * speed * Time.deltaTime;

        float xRawPos = transform.localPosition.x + xOffset;
        float yRawPos = transform.localPosition.y + yOffset;

        float xClampPos = Mathf.Clamp(xRawPos, -xRange, xRange);
        float yClampPos = Mathf.Clamp(yRawPos, -yRange, yRange);

        transform.localPosition = new Vector3(xClampPos, yClampPos, transform.localPosition.z);
    }
    private void PlayerRotation()
    { 
        float yRotation = transform.localPosition.y*PositionPitchFactor;
        float pitchControlValue = yOffset * ControlPitchFactor;
        
        float pitch = yRotation + pitchControlValue;

        float yaw = transform.localPosition.x * PositionYawFactor;
        
        float roll = yOffset * ControlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
        //transform.localRotation = Quaternion.Euler(pitch,yaw,pitch);
    }
   
}
