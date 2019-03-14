using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetpoint : MonoBehaviour {

    public GameObject ground;
    public Texture targetTexture ; // target texture

    // Use this for initialization
    void Start()
    {

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
                transform.position = hit.point;
                GetComponent<Renderer>().material.SetTexture("_MainTex", targetTexture); // sets target's texture to targetTexturetarget.GetComponent<Renderer>().material.color = Color.yellow; // 
                //GetComponent<Renderer>().material.mainTexture = targetTexture;
                GetComponent<Renderer>().material.color = new Color(1f, 0.92f, 0.016f, .5f);

            }
        }
 



            //if (!Input.anyKey)
            //{

            //}
    
    }
}
