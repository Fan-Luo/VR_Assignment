using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneControl : MonoBehaviour {

    float holdingDown = 0.0f;
    bool pressed = false;

    // Update is called once per frame
    void Update () {


        if (Input.anyKeyDown)
        {
            pressed = true;
            holdingDown = Time.deltaTime;
        }

        if (!Input.anyKeyDown && holdingDown>0)
        {

            holdingDown += Time.deltaTime;
            pressed = false;
        }

        if (holdingDown >= 3f)
        {
            SceneManager.LoadScene("Assignment1", LoadSceneMode.Single); // loads the other scene in single mode
        }

    }
}
