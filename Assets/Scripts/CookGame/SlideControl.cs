using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideControl : MonoBehaviour
{
    public Slider slide;
    public float points = 0;
    public bool is_done = false;
    float time = 0; 
    int count = 30; 
    bool start_timer = true;
      // Start is called before the first frame update
    void Start()
    {
        slide = GetComponent<Slider>();
        slide.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time +=Time.deltaTime;
 
        if(time > 1){
            time = 0;
            slide.value += 1;
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            if(slide.value > 6)
                points +=2;
            points += slide.value;
            slide.value =0;
        }
        if(start_timer){
            StartCoroutine("count_down");
            start_timer = false;
            Debug.Log(count);
            if(count==0){
                is_done = true;
                Debug.Log(points);
                Destroy(this);
            }
        }
    }

    IEnumerator count_down(){
        yield return new WaitForSeconds(1);
        count--;
        start_timer = true;
    }
}
