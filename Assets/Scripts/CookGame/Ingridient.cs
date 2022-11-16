using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ingridient : MonoBehaviour
{
    // Start is called before the first frame update
    public Action<Vector3> mDragEven;
    private  GameObject target;
    private  bool  isMouseDrag;
    private  Vector3 screenPosition;
    private  Vector3 offset;

    // Use this for initialization
    void  Start () {
        
    }
    
    // Update is called once per frame
    void  Update () 
    {
#if UNITY_EDITOR
        if  (Input.GetMouseButtonDown (0))
        {
            isMouseDrag =  true ;
        }

        if  (Input.GetMouseButtonUp(0))
        {
            isMouseDrag =  false ;
        }
#else
        if ( Input.touchCount > 0 ) 
        {
            isMouseDrag =  true ;
        }
        else
        {
            isMouseDrag =  false ;
        }
            
#endif
        if(isMouseDrag)
            GameObjectDragAndDrog();
        
    }
    

    //任意拖拽
    private  GameObject ReturnGameObjectDrag( out  RaycastHit hit)
    {
        target =  null ;
        #if UNITY_EDITOR
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        #else
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        #endif
        if  (Physics.Raycast(ray.origin, ray.direction * 10,  out  hit))
        {
            target = hit.collider.gameObject;
        }
        return  target;
    }
    
    //拖拽Updata
    private  void  GameObjectDragAndDrog()
    {
        RaycastHit hitInfo;
        target = ReturnGameObjectDrag( out  hitInfo);
        if  (target !=  null )
        {
            screenPosition = Camera.main.WorldToScreenPoint(target.transform.position);
            #if UNITY_EDITOR
            offset = target.transform.position - Camera.main.ScreenToWorldPoint( new  Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
            #else
            offset = target.transform.position - Camera.main.ScreenToWorldPoint( new  Vector3(Input.touches[0].position.x, Input.touches[0].position.y, screenPosition.z));
            #endif
            if(mDragEven!=null)
                mDragEven(offset);
        }      

        
    
    
        //    Vector3 currentScreenSpace =  new  Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
        //    Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;
        //    target.transform.localPosition =  new  Vector3(currentPosition.x, currentPosition.y, currentPosition.z);
            

    }
}
