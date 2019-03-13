using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBeam : MonoBehaviour {

    public GameObject beam1;
    public GameObject beam2;
    public GameObject beam3;
    public static float speed;
    int direction1 = 1;
    int direction2 = 1;
    int direction3 = 1;
    // Use this for initialization
    void Start () {
        speed = Random.Range(2.0f, 5.0f);
    }
	
	// Update is called once per frame
	void Update () {

        //beam1
        if(beam1.transform.position.y > 4.0f || beam1.transform.position.y < 0.0f)
        {
            direction1 *= -1;
        }
        beam1.transform.Translate(0.0f, speed * Time.deltaTime * direction1, 0.0f);


        //beam2
        if (beam2.transform.position.x > 4.0f || beam2.transform.position.x < -4.0f)
        {
            direction2 *= -1;
        }
        beam2.transform.Translate(3 * speed * Time.deltaTime * direction2, 0.0f, 0.0f);

        //beam3
        if(beam3.transform.position.y > 4.0f || beam3.transform.position.y < 0.0f)
        {
            direction3 *= -1;
        }
        beam3.transform.Translate(0.0f, 2 * speed * Time.deltaTime * direction3, 0.0f);


        //If there’s a hit with Ethan’s collider


    }
}
