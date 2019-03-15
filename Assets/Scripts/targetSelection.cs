using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetSelection : MonoBehaviour {

    public Transform targetpoint;
    public GameObject selection;
    GameObject green_circle;
    float timeLeft = 0.0f;  //for destory green circle
    bool display_green_circle = false;
   
     // Use this for initialization
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
       
        //green_circle = Instantiate(selection, transform.position, Quaternion.identity);
        timeLeft -= Time.deltaTime;
        //Debug.Log(display_green_circle);
        if (!display_green_circle && Input.anyKeyDown) 
        //if (Input.anyKeyDown)
        {
            Debug.Log("transform");
            //Debug.Log(transform.position);
            green_circle = Instantiate(selection, targetpoint.position, Quaternion.identity);
            ////    //Debug.Log(green_circle);
            display_green_circle = true;
            timeLeft = 2.0f;
        }

        if (display_green_circle && (Input.GetKeyDown(KeyCode.Space) || (timeLeft <= 0.0f)) && timeLeft < 2.0f)
        // without timeLeft < 2.0f, green_circle do not even showup, since Input.anyKeyDown is still true, it gets destory immediatedly
        {
            //Debug.Log("enter2");
            Destroy(green_circle);
            display_green_circle = false;
        }

        //green_circle = Instantiate(selection, targetpoint.position, Quaternion.identity);
    }
}
