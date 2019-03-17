using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBeam : MonoBehaviour {

    public GameObject beam1;
    public GameObject beam2;
    public GameObject beam3;
    //public GameObject walk_target;
    public GameObject explosion;
    public GameObject Ethan;
    //public GameObject room;
    public Material roomMat;
    public Transform walk_target;

    public static float speed;
    public static Vector3 ethan_position;
    int direction1 = 1;
    int direction2 = 1;
    int direction3 = 1;
    float lerp_t1 = 0.0f;   // original color
    float lerp_t2 = 0.0f;
    float lerp_t3 = 0.0f;
    Color c;

    // Use this for initialization
    void Start() {
        speed = Random.Range(2.0f, 5.0f);
        c = roomMat.color;
        ethan_position = Ethan.transform.position;
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
                lerp_t1 = 1.0f; //changed to red instantly
                expo = Instantiate(explosion, hit1.point, Quaternion.identity);
                Destroy(expo, 2f);

                walk_target.position = new Vector3(0f, 0f, -8f);
                Ethan.transform.position = ethan_position;
                speed = Random.Range(2.0f, 5.0f);
            }

        }

        if (Physics.Raycast(ray2, out hit2))
        {
            hitObject2 = hit2.collider.gameObject;
            if (hitObject2 == Ethan)
            {
                lerp_t2 = 1.0f;
                expo = Instantiate(explosion, hit2.point, Quaternion.identity);
                Destroy(expo, 2f);
 
                walk_target.position = new Vector3(0f, 0f, -8f);
                Ethan.transform.position = ethan_position;
                speed = Random.Range(2.0f, 5.0f);
            }

        }

        if (Physics.Raycast(ray3, out hit3))
        {
            hitObject3 = hit3.collider.gameObject;
            if (hitObject3 == Ethan)
            {
                lerp_t3 = 1.0f;
                expo = Instantiate(explosion, hit3.point, Quaternion.identity);
                Destroy(expo, 2f);

                walk_target.position = new Vector3(0f, 0f, -8f);
                Ethan.transform.position = ethan_position;
                speed = Random.Range(2.0f, 5.0f);
            }

        }


        if (lerp_t1 > 0.0)    //color is still changing back to original color
        {
            lerp_t1 -= Time.deltaTime;
            beam1.transform.GetComponentInChildren<LineRenderer>().material.color = Color.Lerp(Color.yellow, Color.red, lerp_t1);
            roomMat.color = Color.Lerp(c, Color.red, lerp_t1);
        }
        if (lerp_t2 > 0.0)
        {
            lerp_t2 -= Time.deltaTime;
            beam2.transform.GetComponentInChildren<LineRenderer>().material.color = Color.Lerp(Color.yellow, Color.red, lerp_t2);
            roomMat.color = Color.Lerp(c, Color.red, lerp_t2);
        }
        if (lerp_t3 > 0.0)
        {
            lerp_t3 -= Time.deltaTime;
            beam3.transform.GetComponentInChildren<LineRenderer>().material.color = Color.Lerp(Color.yellow, Color.red, lerp_t3);
            roomMat.color = Color.Lerp(c, Color.red, lerp_t3);
        }



    }
}
