using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMouvment : MonoBehaviour
{
    //[SerializeField] Rigidbody obstacleRb;
    [SerializeField] ObstacleStats obsStats;
    //Transform obstaclePosition;
    bool heTouchedTriggers=true;
    // Start is called before the first frame update
    void Start()
    {
      // transform.position = new Vector3(Random.Range(obsStats.obstacleClamSidesValue.x, obsStats.obstacleClamSidesValue.y), 2.21f,0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (!heTouchedTriggers) { return; }
        
           transform.Translate(Vector3.right * Time.deltaTime*obsStats.LeftRightSpeed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Left")
        {
            heTouchedTriggers = false;
            transform.Translate(Vector3.right * Time.deltaTime*obsStats.LeftRightSpeed);
        }

        if (other.tag == "Right")
        {
            heTouchedTriggers = false;
            transform.Translate(Vector3.left * Time.deltaTime * obsStats.LeftRightSpeed);
        }
    }
    
}
