using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermouvment : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Rigidbody playerRB;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, playerStats.sidesClampValue.x, playerStats.sidesClampValue.y)
            , transform.position.y, transform.position.z);

        playerRB.velocity = new Vector3(joystickManager.instance.Horizontal * playerStats.sidesSpeed, 0f, playerStats.forwardSpeed);
    }
}
