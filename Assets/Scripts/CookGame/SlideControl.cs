using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideControl : MonoBehaviour
{
    Slider slide;
    public float points = 0;
    public bool is_done = false;
    float time = 0; 
    public int count = 30; 
    bool start_timer = true;
    public bool flip = false;
    public int t =1;
    [SerializeField] GameObject fireup;
    [SerializeField] GameObject firedown;
    private float speed =0;
    [SerializeField] List<Sprite> mode;
    [SerializeField] Image target;
    //private readonly Random _random = new Random();  
      // Start is called before the first frame update
    void Start()
    {
        slide = GetComponent<Slider>();
        slide.value = 0;
        fireup.SetActive(flip);
        firedown.SetActive(!flip);
        speed =  Random.Range(0.1f, 0.3f); 
    }

    // Update is called once per frame
    void Update()
    {
        time +=Time.deltaTime;
 
        // if(time > 1){
        //     time = 0;
        //     slide.value += 1;
        // }

        if(Input.GetKeyDown(KeyCode.Space)){
            speed =  Random.Range(0.08f, 0.15f); 
            //slide.value =0;
            flip = !flip;
            fireup.SetActive(flip);
            firedown.SetActive(!flip);
            // Sprite image = mode[t];
            // target.sprite = image;
            if(t==0 && slide.value >= 8)
                points+=1;
            else if (t==2 && slide.value >=5.5 && slide.value <=7.5 )
                points+=1;
            else if(t==1 && slide.value >=3 && slide.value <=6 )
                points+=1;
            t = Random.Range(0, 10); 
            t%=3;
            Sprite image = mode[t];
            target.sprite = image;
            slide.value =0;
        }
        if(start_timer){
            StartCoroutine("count_down");
            start_timer = false;
            Debug.Log(count);
            if(count==0){
                points += slide.value;
                slide.value =0;
                is_done = true;
                Debug.Log(points);
                //Destroy(this);
            }
        }
    }

    IEnumerator count_down(){
        yield return new WaitForSeconds(1);
        count--;
        start_timer = true;
    }

    void FixedUpdate(){
        slide.value += speed;
    }
}
