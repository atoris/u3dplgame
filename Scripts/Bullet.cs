using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    // Use this for initialization
    
    Vector3 startPos;
    public float maxDistance=20f;

    
    private GameObject parent;
    public GameObject Parent { set { parent = value; } get { return parent; } }
    
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }

    private float speed=10f;
    public float Speed { set { speed = value; } get { return speed; } }
    void Start () {
        
        startPos = transform.position;
       // Debug.Log(speed);
        speed = speed / 10;
    }
	
	// Update is called once per frame
    


	void Update () {
       
        if (transform.position.x- startPos.x<maxDistance)
        {//
           // transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);

        }
        else
        {
            //Destroy(gameObject);
        }
       // transform.position = new Vector3(transform.position.x + direction.x, transform.position.y, transform.position.z);


        //transform.Translate(Vector3.forward * Time.deltaTime);
        // transform.position = Vector3.MoveTowards(transform.position, transform.position, 10f * Time.deltaTime);
    }
}
