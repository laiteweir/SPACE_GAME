using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingridient : MonoBehaviour
{
    // Start is called before the first frame update
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void OnMouseDrag()
    {
        rend.material.color += Color.red * Time.deltaTime;
        if(rend.material.color == Color.red)
            rend.material.color += Color.black * Time.deltaTime;

        Debug.Log(rend.material.color);
    }

    void Update(){
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray , out hit))
            {
                Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
                hit.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
            }
        }
    }
}
