using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxtri : MonoBehaviour {

    public GameObject Ethan;
    public Transform walk_target;
    public GameObject Door_Right;
    public GameObject Door_Left;
    Vector3 Left_door_close_pos;
    Vector3 Left_door_open_pos;
    Vector3 Right_door_close_pos;
    Vector3 Right_door_open_pos;
    Color c;
    private int success = 0;
    private int score;
    bool door_open = false;   // door sliding

    void Start()
    {
        Left_door_close_pos = Door_Left.transform.position;
        Left_door_open_pos = new Vector3(Door_Left.transform.position.x - 1.7f, Door_Left.transform.position.y, Door_Left.transform.position.z);
        Right_door_close_pos = Door_Right.transform.position;
        //Right_door_open_pos = new Vector3(Door_Right.transform.position.x + 1.7f, Door_Right.transform.position.y, Door_Right.transform.position.z);
        c = Door_Left.GetComponent<Renderer>().materials[0].color;
    }

    void Update()
    {

        if (door_open && Door_Left.transform.position.x > Left_door_open_pos.x)  //still sliding
        {
            Door_Left.transform.Translate(-1.2f * Time.deltaTime, 0.0f, 0.0f);
            Door_Right.transform.Translate(1.2f * Time.deltaTime, 0.0f, 0.0f);

            if (Door_Left.transform.position.x <= Left_door_open_pos.x)   //done with openning, close instantly
            {
                door_open = false;
                Door_Left.transform.position = Left_door_close_pos;
                Door_Right.transform.position = Right_door_close_pos;
                Door_Left.GetComponent<Renderer>().materials[0].color = c;
                Door_Right.GetComponent<Renderer>().materials[0].color = c;

                movingBeam.speed = Random.Range(2.0f, 5.0f);
                Ethan.transform.position = movingBeam.ethan_position;
                walk_target.position = new Vector3(0f, 0f, -8f);
            }

        }

    }

    void OnTriggerEnter(Collider other)
    {
        //if (score < 3 && success == 1)
        //{
        if (other.tag== "Player")
        {
            //open
            door_open = true;
            success += 1;
            Door_Left.GetComponent<Renderer>().materials[0].color = Color.green;
            Door_Right.GetComponent<Renderer>().materials[0].color = Color.green;
        }


    }

}
