using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBeam : MonoBehaviour {

    public GameObject beam1;
    public GameObject beam2;
    public GameObject beam3;
    public GameObject walk_target;
    public GameObject explosion;
    public GameObject Ethan;
    public GameObject room;

    public float speed;
    int direction1 = 1;
    int direction2 = 1;
    int direction3 = 1;

    Color c;
    Vector3 ethan_position;


    // Use this for initialization
    void Start() {
        speed = Random.Range(2.0f, 5.0f);
        c = room.GetComponent<Renderer>().material.color;
        ethan_position = Ethan.transform.position;

        //Transform target_transform = walk_target.transform;
        //Transform ethan_transform = Ethan.transform;

    }

    // Update is called once per frame
    void Update() {

        //beam1
        if (beam1.transform.position.y >= 4.0f)
        {
            direction1 = -1;
        }
        if (beam1.transform.position.y <= 0.0f)
        {
            direction1 = 1;
        }
        beam1.transform.Translate(0.0f, speed * Time.deltaTime * direction1, 0.0f);


        //beam2
        if (beam2.transform.position.x >= 4.0f)
        {
            direction2 = -1;
        }
        if (beam2.transform.position.x <= -4.0f)
        {
            direction2 = 1;
        }
        beam2.transform.Translate(3 * speed * Time.deltaTime * direction2, 0.0f, 0.0f);

        //beam3
        if (beam3.transform.position.y >= 4.0f)
        {
            direction3 = -1;
        }
        if (beam3.transform.position.y <= 0.0f)
        {
            direction3 = 1;
        }
        beam3.transform.Translate(0.0f, 2 * speed * Time.deltaTime * direction3, 0.0f);


        RaycastHit hit1;
        GameObject hitObject1;
        RaycastHit hit2;
        GameObject hitObject2;
        RaycastHit hit3;
        GameObject hitObject3;
        GameObject expo;
        Ray ray1 = new Ray(beam1.transform.position, beam1.transform.rotation * Vector3.right);
        Ray ray2 = new Ray(beam2.transform.position, beam2.transform.rotation * Vector3.down);
        Ray ray3 = new Ray(beam3.transform.position, beam3.transform.rotation * Vector3.right);
        if (Physics.Raycast(ray1, out hit1))
        {
            hitObject1 = hit1.collider.gameObject;
            if(hitObject1 == Ethan){

                expo = Instantiate(explosion, hit1.point, Quaternion.identity);
                Destroy(expo, 2f);

                //beam1.transform.GetComponentInChildren<LineRenderer>().material.color = Color.red;
                beam1.transform.GetComponentInChildren<LineRenderer>().material.color = Color.Lerp(Color.red, Color.yellow, 1.0f);
                room.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, c, 1.0f);


                //hitObject1.transform.position  = new Vector3(0f, 0f, -8f);
                walk_target.transform.position = new Vector3(0f, 0f, -8f);
                Ethan.transform.position = ethan_position;
                speed = Random.Range(2.0f, 5.0f);
            }

        }


        if (Physics.Raycast(ray2, out hit2))
        {
            hitObject2 = hit2.collider.gameObject;
            if (hitObject2 == Ethan)
            {

                expo = Instantiate(explosion, hit2.point, Quaternion.identity);
                Destroy(expo, 2f);

                //beam1.transform.GetComponentInChildren<LineRenderer>().material.color = Color.red;
                beam2.transform.GetComponentInChildren<LineRenderer>().material.color = Color.Lerp(Color.red, Color.yellow, 1.0f);
                room.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, c, 1.0f);


                //hitObject1.transform.position  = new Vector3(0f, 0f, -8f);
                walk_target.transform.position = new Vector3(0f, 0f, -8f);
                Ethan.transform.position = ethan_position;
                speed = Random.Range(2.0f, 5.0f);
            }

        }

        if (Physics.Raycast(ray3, out hit3))
        {
            hitObject3 = hit3.collider.gameObject;
            if (hitObject3 == Ethan)
            {

                expo = Instantiate(explosion, hit3.point, Quaternion.identity);
                Destroy(expo, 2f);

                //beam1.transform.GetComponentInChildren<LineRenderer>().material.color = Color.red;
                beam3.transform.GetComponentInChildren<LineRenderer>().material.color = Color.Lerp(Color.red, Color.yellow, 1.0f);
                room.GetComponent<Renderer>().material.color = Color.red;//Color.Lerp(Color.red, c, 1.0f);


                //hitObject1.transform.position  = new Vector3(0f, 0f, -8f);
                walk_target.transform.position = new Vector3(0f, 0f, -8f);
                Ethan.transform.position = ethan_position;
                speed = Random.Range(2.0f, 5.0f);
            }

        }

    }
}
