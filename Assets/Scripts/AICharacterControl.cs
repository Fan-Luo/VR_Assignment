using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for
        private Ray rayFromMainCamera; // ray from main camera
        private RaycastHit hitFromRay; // the point where the ray hits
        public Texture targetTexture; // target texture
        private Transform target2; // second target for green circle
        public Texture target2Texture;// second target texture 
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            agent.updateRotation = false;
            agent.updatePosition = true;
            target.position = new Vector3(0f, 0f, -8f);
        }


        private void Update()
        {
            rayFromMainCamera = new Ray(Camera.main.transform.position, Camera.main.transform.rotation * new Vector3(0f, 0f, 1f));// ray from main camera starts at main camera's position and goes forward to where the camera is rotated
            if (Physics.Raycast(rayFromMainCamera, out hitFromRay)) // checks if the ray interesects with a collider
            {
                if (hitFromRay.collider.gameObject.name == "Ground" && Input.anyKeyDown) // if the ray hits the ground
                {
                    target.position = hitFromRay.point; //target position = hit point position
                    target.GetComponent<Renderer>().material.SetTexture("_MainTex", targetTexture); // sets target's texture to targetTexture
                    target.GetComponent<Renderer>().material.color = new Color(1f, 0.92f, 0.016f, .5f); // 
                   
                }
            }

            if (target != null)
                agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
