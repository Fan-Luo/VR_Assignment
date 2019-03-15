using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Spaceship : MonoBehaviour
{ // class Spaceship extends MonoBehaviour
    public GameObject spaceship; // space ship prefab
    public GameObject explosionParticle; // Explosion Mobile Particle particle effect
    public GameObject sparksParticle; // Sparks Particle system
    public GameObject[] asteroids = new GameObject[5]; // asteroid array
                                                       // public GameObject lineRenderer; //--> LR
    private float x; // x position
    private float y; // y position
    private float z; // z position
    private float[] zArray = new float[2];// z array of size 2
    private int index; // index of array
    private float rotationalSpeed; // rotational speed
    private MeshRenderer spaceShipMeshRenderer; // space ship mesh renderer
    private float time; // current time
    private float xAsteroid; // x position of asteroids
    private int score; // player score
    private Ray rayFromMainCamera; // ray from main camera
    private RaycastHit hitFromRay; // the point where the ray hits
    private Color lineRendererColor; // Line renderer color 
    private Color spaceShipColor; // Spaceship color
    private float time2; // time2 used for success instance condition
    private float time2Plus3; // time2 + 3 
    private int success; // int success to check if its a success instance
    private int won; // int won to check if the player won 
    // Use this for initialization
    void Start()
    { // Start function
        x = Random.Range(-10f, 10f); // Random x from -10f to 10f
        y = Random.Range(1f, 6f); // Random y from 1f to 6f
        z = Mathf.Sqrt(100f - (x * x)); // z = sqrt(100f -(x*x)) for x and z to be a point in the circle x*x + z*z = 100, radius = 10 with center at the origin
        zArray[0] = -z; // point could be in -z
        zArray[1] = z; // or z
        index = Random.Range(0, 2); // index would randomly be 0 or 1
        z = zArray[index]; // z would be -z or z
        rotationalSpeed = Random.Range(10f, 40f); // rotational speed from 10f to 40f
                                                  //  while(((x*x)+(z*z))!=100f) Tried this but its an infinite loop so I had to do the above for it to not be an infinite loop
                                                  // {
                                                  // x = Random.Range(-10f, 10f);
                                                  // z = Random.Range(-10f, 10f);
                                                  // }
        Instantiate(spaceship, new Vector3(x, y, z), Quaternion.identity); // instantiates spaceship prefab in x y z position and no rotation
        // GameObject.Find("SpaceShip(Clone)").transform.RotateAround(new Vector3(0,0,0),Vector3.up,-rotationalSpeed*Time.deltaTime); // find spaceship that was instntiated and rotated around origin in a counterclockwise direction
        spaceShipMeshRenderer = GameObject.Find("SpaceShip(Clone)").GetComponent<MeshRenderer>(); // get space ship mesh renderer
        spaceShipMeshRenderer.shadowCastingMode = ShadowCastingMode.On; // turn cast shadows on inside the space ship mesh renderer
        xAsteroid = -5f; // x position of asteroids starts at -5f
        score = 0;// initial player score is 0
        success = 0; // success starts at 0 
        lineRendererColor = Camera.main.GetComponent<Renderer>().material.color; // Gets line renderer's color
        spaceShipColor = GameObject.Find("SpaceShip(Clone)").GetComponent<Renderer>().material.color; // Gets Spaceship's color
        time2 = 0f; // time 2 for success instance
        time = 0f; // time for change scene
        won = 0;//start won at 0
    }
    // Update is called once per frame
    void Update()
    { // Update function
      // rotationalSpeed = Random.Range(10f, 40f); // rotational speed from 10f to 40f
      //-->lineRenderer.transform.position = new Vector3(0, 1.6f, 0); LR
        GameObject.Find("SpaceShip(Clone)").transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, -rotationalSpeed * Time.deltaTime);// find spaceship that was instantiated and rotated around origin in a counterclockwise direction
        rayFromMainCamera = new Ray(Camera.main.transform.position, Camera.main.transform.rotation * new Vector3(0f, 0f, 1f)); // new ray from camera position forward depending on where the camera rotates
        Camera.main.GetComponent<Renderer>().material.color = lineRendererColor; // change line renderer's color to its original color
        GameObject.Find("SpaceShip(Clone)").GetComponent<Renderer>().material.color = spaceShipColor; // change spaceship's color to its original color

        if (Input.anyKey) // If the user presses any key on the controller 
        {
            time2 = 0;
            time = time + Time.deltaTime; // updates time key is pressed
            Debug.Log(time);
            if (time > 2.99f && time < 3.1f) // if user pressed the button for 3 seconds
            {
                //  Debug.Log(time);
                SceneManager.LoadScene("Assignment2", LoadSceneMode.Single); // loads the other scene in single mode
            }

        }
        //-->LR rayFromMainCamera = new Ray(lineRenderer.transform.position, lineRenderer.transform.rotation * new Vector3(0f, 0f, 1f));
        // ray from main camera starts at main camera's position and goes forward to where the camera is rotated
        else if (Physics.Raycast(rayFromMainCamera, out hitFromRay) && score < 10) // checks if the ray interesects with a collider
        {
            time = 0;
            time2 = 0;
            //GameObject.Find("SpaceShip(Clone)").transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, -rotationalSpeed * Time.deltaTime);// find spaceship that was instntiated and rotated around origin in a counterclockwise direction
            // GameObject.Find("SpaceShip(Clone)").transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, -rotationalSpeed * Time.deltaTime);
            if (hitFromRay.collider.gameObject.name == "SpaceShip(Clone)" && score < 10) // if the ray hits the spaceship
            {
                //GameObject.Find("SpaceShip(Clone)").transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, -rotationalSpeed * Time.deltaTime);// find spaceship that was instntiated and rotated around origin in a counterclockwise direction
                time2 = time2 + Time.deltaTime; // updates time key is pressed
                Camera.main.GetComponent<Renderer>().material.color = Color.yellow; // change line renderer's color to yellow
                                                                                    //--> lineRenderer.GetComponent<Renderer>().material.color = Color.yellow; LR
                hitFromRay.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow; //change spaceship's color to yellow
                Instantiate(sparksParticle, hitFromRay.point, Quaternion.identity); // instantiate sparksParticle at hit point
                                                                                    //  GameObject.Find("SpaceShip(Clone)").transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, -rotationalSpeed * Time.deltaTime);
            }
            if (time2 > 2.99f && time2 < 3.1f)
            {

                success = 1; // ship was hit for three seconds
                             //   GameObject.Find("SpaceShip(Clone)").transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, -rotationalSpeed * Time.deltaTime);
            }
        }


        //Success Instance Condition
        else if (score < 10 && success == 1) // no more than 10 success instances
        {
            time = 0;
            time2 = 0;
            x = Random.Range(-10f, 10f); // Random x from -10f to 10f
            y = Random.Range(1f, 6f); // Random y from 1f to 6f
            z = Mathf.Sqrt(100f - (x * x)); // z = sqrt(100f -(x*x)) for x and z to be a point in the circle x*x + z*z = 100, radius = 10 with center at the origin
            zArray[0] = -z; // point could be in -z
            zArray[1] = z; // or z
            index = Random.Range(0, 2); // index would randomly be 0 or 1
            z = zArray[index]; // z would be -z or z
            GameObject.Find("SpaceShip(Clone)").transform.position = new Vector3(x, y, z);
            rotationalSpeed = Random.Range(10f, 40f); // rotational speed from 10f to 40f
            Instantiate(explosionParticle, hitFromRay.point, Quaternion.identity);
            Destroy(explosionParticle, 2f); // destroy explosion particle in 2 seconds
            Destroy(sparksParticle, 2f);
            index = Random.Range(0, 5); // index randomly from 0 to 4
            Instantiate(asteroids[index], new Vector3(xAsteroid, 0f, 0f), Quaternion.identity); // instantiate random asteroid in x position where the next asteroid goes
            asteroids[index].GetComponent<Renderer>().material.color = Random.ColorHSV(); // assign radom color to asteroid
            xAsteroid++; // asteroid x position increases by 1
            score++; // add 1 to score
            success = 0; // success=0
            time2 = 0f; // time =0;
                        // GameObject.Find("SpaceShip(Clone)").transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, -rotationalSpeed * Time.deltaTime);
        }
        else if (score == 10)
        {
            time = 0;
            time2 = 0;
            x = Random.Range(-10f, 10f); // Random x from -10f to 10f
            y = Random.Range(1f, 6f); // Random y from 1f to 6f
            z = Mathf.Sqrt(100f - (x * x)); // z = sqrt(100f -(x*x)) for x and z to be a point in the circle x*x + z*z = 100, radius = 10 with center at the origin
            zArray[0] = -z; // point could be in -z
            zArray[1] = z; // or z
            index = Random.Range(0, 2); // index would randomly be 0 or 1
            z = zArray[index]; // z would be -z or z
            GameObject.Find("SpaceShip(Clone)").transform.position = new Vector3(x, y, z);
            rotationalSpeed = Random.Range(10f, 40f); // rotational speed from 10f to 40f
            Camera.main.GetComponent<Renderer>().material.color = lineRendererColor; // change line renderer's color to its original color
            hitFromRay.collider.gameObject.GetComponent<Renderer>().material.color = spaceShipColor; // change spaceship's color to its original color
            Destroy(explosionParticle); // Destroy explosion particle
            Destroy(sparksParticle); //destroy sparks particle
            won++; // add 1 to won
            score++; // add 1 ro score
                     // GameObject.Find("SpaceShip(Clone)").transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, -rotationalSpeed * Time.deltaTime);
        }
        else
        {
            time = 0;
            time2 = 0;
        }
    }
}
