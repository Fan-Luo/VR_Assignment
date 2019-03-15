using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetpoint : MonoBehaviour {

    public GameObject ground;
    //public GameObject selection;
    //GameObject green_circle;
    //float timeLeft = 0.0f;  //for destory green circle
    //bool display_green_circle = false;
    // Use this for initialization

    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(1f, 0.92f, 0.016f, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        RaycastHit[] hits;
        GameObject hitObject;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);

        hits = Physics.RaycastAll(ray);

        //Then we iterate through each hit, looking for a ground hit
        //anywhere along the path of the ray vector.
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            hitObject = hit.collider.gameObject;
            if (hitObject == ground)
            {
                transform.position = new Vector3(hit.point.x, hit.point.y + 0.01f, hit.point.z);
            }
        }

        ////green_circle = Instantiate(selection, transform.position, Quaternion.identity);
        //timeLeft -= Time.deltaTime;
        ////Debug.Log(display_green_circle);
        //if (!display_green_circle && Input.anyKeyDown)
        //{
        //    Debug.Log("enter1");
        //    green_circle = Instantiate(selection, transform.position, Quaternion.identity);
        //    Debug.Log(green_circle);
        //    display_green_circle = true;
        //    timeLeft = 2.0f;
        //}

        //if(display_green_circle && (Input.anyKeyDown || (timeLeft <= 0.0f)) && timeLeft < 2.0f) 
        //// without timeLeft < 2.0f, green_circle do not even showup, since Input.anyKeyDown is still true, it gets destory immediatedly
        //{
        //    Debug.Log("enter2");
        //    Destroy(green_circle);
        //    display_green_circle = false;
        //}


    }
}
