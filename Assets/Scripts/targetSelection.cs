using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetSelection : MonoBehaviour {

    public Transform yellowCircle;
    public GameObject selection;
    public Transform walktarget;
    GameObject green_circle;
    float timeLeft = 0.0f;  //for destory green circle
    bool display_green_circle = false;
   //--> public GameObject player;

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (boxtri.success < 3)
        {
            if (!display_green_circle && Input.anyKeyDown)  //green circle appears
            {
                green_circle = Instantiate(selection, yellowCircle.position, Quaternion.identity);
                display_green_circle = true;
                transform.position = yellowCircle.position;
                walktarget.position = transform.position;
                timeLeft = 2.0f;
            }

            if (display_green_circle && (Input.anyKeyDown || (timeLeft <= 0.0f)) && timeLeft < 2.0f)
            // without timeLeft < 2.0f, green_circle do not even showup, since Input.anyKeyDown is still true, it gets destory immediatedly
            {
                Destroy(green_circle);
                display_green_circle = false;
            }
        }

    }
}
