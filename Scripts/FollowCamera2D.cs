using UnityEngine;
using System.Collections;
using System;

namespace CustomCamera
{
    [Flags]
    public enum Direction
    {
        None = 0,
        Horizontal = 1,
        Vertical = 2,
        Both = 3
    }

    public class FollowCamera2D : MonoBehaviour
    {
        public Transform target;
        public Transform startPosition;
        public Transform finishPosition;
        public float dampTime = 0.15f;
        public Direction followType = Direction.Horizontal;
        [Range(0.0f,1.0f)]
        public float
            cameraCenterX = 0.5f;
        [Range(0.0f,1.0f)]
        public float
            cameraCenterY = 0.5f;
        /*public Direction boundType = Direction.None;
        public float leftBound = 0;
        public float rightBound = 0;
        public float upperBound = 0;
        public float lowerBound = 0;
        public Direction deadZoneType = Direction.None;
        
        public float leftDeadBound = 0;
        public float rightDeadBound = 0;
        public float upperDeadBound = 0;
        public float lowerDeadBound = 0;*/

        // private
        Camera camera;
        Vector3 velocity = Vector3.zero;
        float vertExtent;
        float horzExtent;
        Vector3 tempVec = Vector3.one;
        //bool isBoundHorizontal;
        //bool isBoundVertical;
        bool isFollowHorizontal;
        bool isFollowVertical;
        //bool isDeadZoneHorizontal;
        //bool isDeadZoneVertical;

        float posX;
        float posY;
        Vector3 deltaCenterVec;

        void Start ()
        {
            camera = GetComponent<Camera> ();
            vertExtent = camera.orthographicSize;
            horzExtent = vertExtent * Screen.width / Screen.height;
            deltaCenterVec = camera.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 0))
                - camera.ViewportToWorldPoint (new Vector3 (cameraCenterX, cameraCenterY, 0));
                
    
            isFollowHorizontal = (followType & Direction.Horizontal) == Direction.Horizontal;
            isFollowVertical = (followType & Direction.Vertical) == Direction.Vertical;
            
            tempVec = Vector3.one;
            
        }

        void LateUpdate ()
        {
            if (target) {

               

                Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(cameraCenterX, cameraCenterY, 0));
                Vector3 destination = transform.position + delta;

                
                bool isPosX = ((target.position.x - startPosition.position.x >= 13) && (finishPosition.position.x - target.position.x >= 13));
                bool isPosY = ((startPosition.position.y - target.position.y >= 5) && (finishPosition.position.y - target.position.y <= -5));
                //bool isPosY = (finishPosition.position.y - target.position.y <= -5);
               
               
                if (isPosX)
                {
                    posX = target.position.x;
                }else
                {
                   
                    if (target.position.x - startPosition.position.x >= 12)
                    {
                        //posX = (target.position.x - startPosition.position.x)-10f;
                       
                    }
                }
               // Debug.Log(posX+" | "+ (target.position.x - startPosition.position.x));
                if (isPosY)
                {
                    posY= target.position.y;
                }
                tempVec = Vector3.SmoothDamp(transform.position, new Vector3(posX, posY, transform.position.z), ref velocity, dampTime);
                //tempVec = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

                tempVec.z = transform.position.z;

               
                //Debug.Log(isPosY+" | " +  (finishPosition.position.y - target.position.y >= -5));
                //(target.position.y - startPosition.position.y >= 12) && (finishPosition.position.y - target.position.y >= 12) &&
                
                    
                transform.position = tempVec;//new Vector3(tempVec.x, tempVec.y);
                        //tempVec.x;   
                
            }            
        }
       
    }

}
