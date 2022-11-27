using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Slide;
    public float limit_point ;
    public bool win = false;
    public bool overcooked = false;
    [SerializeField] GameObject Food;
    [SerializeField] GameObject FoodCooked;
    void Start()
    {
        Food.SetActive(true);
        FoodCooked.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Slide.GetComponent<SlideControl>().is_done){
            if(Slide.GetComponent<SlideControl>().points > limit_point){
                CookData.situation =1;
                win =true;
                backScene();
            }
            else{
                CookData.situation =3;
                backScene();
            }
        }
        if( Slide.GetComponent<Slider>().value == 10 ){
            overcooked = true;
            CookData.situation =2;
            backScene();
        }

        if( Slide.GetComponent<SlideControl>().points >= limit_point ){
            Food.SetActive(false);
            FoodCooked.SetActive(true);
        } 
    }

    void backScene(){
        Manager.Instance.returnKeyitem.EndKeyitemEvent();
    }
}
