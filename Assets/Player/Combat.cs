using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Combat : MonoBehaviour
{
    [SerializeField] Slider fearSlider;
    [SerializeField] Slider angerSlider;
    [SerializeField] int initialFear = 3;
    [SerializeField] int initialAnger = 0;
    bool collided = false;
    bool hitHazard = false;

    GameObject target;
 

    private void Start()
    {
        fearSlider.value = initialFear;
        angerSlider.value = initialAnger;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && collided)
        {
            Debug.Log("Hit enemy +1");
            Good();
            target.GetComponentInParent<GoreExplosion>().Explode();

            //Destroy(target.transform.parent.gameObject);
            //FindObjectOfType<GoreExplosion>().Explode();

            collided = false;

        }
        else if (Input.GetMouseButtonDown(0) && !collided)
        {
            //enemy hits you
            Bad();
            Debug.Log("no enemy -1");
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy") 
        {
            collided = true;
            target = other.gameObject;

        }
        else if (other.gameObject.tag == "Exit")
        {
            Bad();
            print("didn't kill -1");

        }
        else if (other.gameObject.tag == "Hazard")
        {
            print("Hit hazard -1");
            Bad();
            hitHazard = true;

        }
        if (other.gameObject.tag == "AvoidHazard" && !hitHazard)
        {
            print("Avoided hazard +1");
            Good();
            hitHazard = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy") 
        { 
            collided = false; 
        }
    }

    void Bad()
    {
        fearSlider.value = fearSlider.value + 1;

        angerSlider.value = angerSlider.value - 1;

        if (fearSlider.value == 10)
        {
            FindObjectOfType<LevelControl>().Loser();
        }

    }

    void Good()
    {
        fearSlider.value = fearSlider.value - 1;
        angerSlider.value = angerSlider.value + 1;
    }
}
