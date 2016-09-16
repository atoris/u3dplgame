using UnityEngine;
using System.Collections;

public class Rotatekarys : MonoBehaviour {

    // Use this for initialization
    public float speedMove = 100;
    public bool rotate = false;
    public float speedRotate = 25f;
    public Transform target;
    public float maxTimeDelta = 0;
    private float timeDelta=0;
    public float startTime = 0;
    bool isTimeStart;
    private bool boolMove = false;
    
    private Vector3 targetPosition;

    void Start () {
        targetPosition = transform.position;
        //timeDelta = maxTimeDelta;
    }
	
	// Update is called once per frame
	void Update () {
        if (rotate)
        {
            transform.Rotate(new Vector3(0f, 0f, speedRotate * Time.deltaTime));
        }else
        {
            //Debug.Log("step");
            float step = speedMove * Time.deltaTime;
           


            if (transform.position != target.position && !boolMove)
            {
                boolMove = false;
                
            }
            else if (transform.position != targetPosition)
            {
                boolMove = true;
            }else
            {                
                boolMove = false;
            }
            if (startTime>0)
            {
                startTime -= Time.deltaTime;
                isTimeStart = false;
            }else
            {
                isTimeStart = true;
            }
            if (isTimeStart)
            {

            if (!boolMove)
            {

                if (timeDelta < maxTimeDelta)
                {
                    timeDelta += Time.deltaTime;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, target.position, step);
                }   
            }else
            {
                timeDelta = 0;
                
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);


                }
            }

        }
        
    }
}
