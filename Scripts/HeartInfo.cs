using UnityEngine;
using System.Collections;

public class HeartInfo : MonoBehaviour {

    // Use this for initialization
    public GameObject gHeart;
    GameObject heart;
    ArrayList arrHeart;
    void Start () {

        arrHeart = new ArrayList();
        
        
        
        for (int i = 0; i < Opt.numHeart; i++)
        {
            heart=Instantiate(gHeart, new Vector3(transform.position.x+(1f * i), transform.position.y, transform.position.z), transform.rotation) as GameObject;
            heart.transform.parent = transform;
            arrHeart.Add(heart);

        }
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addHeart()
    {
        if (transform.childCount<5)
        {
            heart = Instantiate(gHeart, new Vector3(transform.position.x + (1f * arrHeart.Count), transform.position.y, transform.position.z), transform.rotation) as GameObject;
            heart.transform.parent = transform;
            arrHeart.Add(heart);
            Opt.numHeart++;
        }
       
    }
    public void removeHeart()
    {
        //Debug.Log("PIPEC");
        if (transform.childCount > 0)
        {
            Destroy(arrHeart[Opt.numHeart - 1] as GameObject);
            arrHeart.RemoveAt(Opt.numHeart - 1);
            Opt.numHeart--;
            
        }
        
    }
}
