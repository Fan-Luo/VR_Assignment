using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetpoint : MonoBehaviour {

    public GameObject ground;
    public GameObject line;
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

        if (boxtri.success < 3)
        {
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
                    line.GetComponent<LineRenderer>().SetPosition(0, Camera.main.transform.position);
                    line.GetComponent<LineRenderer>().SetPosition(1, transform.position);
                    
                }
            }
        }


    }
}
