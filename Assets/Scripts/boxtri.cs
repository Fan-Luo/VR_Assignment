using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxtri : MonoBehaviour {

    public GameObject Door_RightPrefab;
    public GameObject Door_LeftPrefab;
    private GameObject Door_RightPrefabInstance;
    private GameObject Door_LeftPrefabInstance;
    private Vector3 scaleFactor;
    private int score;
    private int success;
    void OnTriggerEnter(Collider other)
    {
        if (score < 3 && success == 1)
        {
            if (other.tag == "Player")
            {
                Door_RightPrefabInstance = Instantiate(Door_RightPrefab, other.transform.transform.position, Quaternion.identity);
                Door_LeftPrefabInstance = Instantiate(Door_LeftPrefab, other.transform.position, Quaternion.identity);
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Door_RightPrefab.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f);
            transform.Translate(Vector3.right * 1.7f * Time.deltaTime);
            Door_LeftPrefab.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f);
            transform.Translate(Vector3.left * 1.7f * Time.deltaTime);
            scaleFactor.x += 1.2f * Time.deltaTime;
            scaleFactor.y += 0f * Time.deltaTime;
            scaleFactor.z += 0f * Time.deltaTime;
            Door_RightPrefabInstance.transform.localScale += scaleFactor;
            Door_LeftPrefabInstance.transform.localScale -= scaleFactor;
        }
        Destroy(Door_RightPrefabInstance, 2f);
        Destroy(Door_LeftPrefabInstance, 2f);
    }

}
