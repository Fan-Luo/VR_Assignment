using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetSelection : MonoBehaviour {

    public Transform targetpoint;
    public GameObject selection;
    GameObject green_circle;
    float timeLeft = 0.0f;  //for destory green circle
    bool display_green_circle = false;
   

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (!display_green_circle && Input.anyKeyDown && boxtri.success < 3) 
        {
            green_circle = Instantiate(selection, targetpoint.position, Quaternion.identity);
            display_green_circle = true;
            timeLeft = 2.0f;
        }

        if (display_green_circle && (Input.GetKeyDown(KeyCode.Space) || (timeLeft <= 0.0f)) && timeLeft < 2.0f)
        // without timeLeft < 2.0f, green_circle do not even showup, since Input.anyKeyDown is still true, it gets destory immediatedly
        {
            Destroy(green_circle);
            display_green_circle = false;
        }

    }
}
