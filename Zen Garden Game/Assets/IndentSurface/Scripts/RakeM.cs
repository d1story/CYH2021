using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Wacki.IndentSurface
{
    public class RakeM : MonoBehaviour
    {
        private bool _mouseDrag = false;
        public float movementSpeed, rotationSpeed, consty, stopT;
        public AudioSource SandNoise;
        public Collider[] teeth;
        private float T;
        bool bump(Collider rake)
        {
            Debug.Log("In");
            Collider[] into = Physics.OverlapBox(rake.bounds.center, rake.bounds.extents, rake.transform.rotation);

            foreach (Collider other in into)
            {
                //if (other.gameObject.GetComponent<ProdN>() != null)
                //{
                    //Debug.Log("InIn");
                    //other.gameObject.GetComponent<ProdN>().PPlay();
                //}
            }
            if (into.Length > 6)
            {
                return true;
            }
            return false;
        }

        private void contact(Collider col)
        {
            RaycastHit hitRake;
            if (Physics.Raycast(col.bounds.center, Vector3.down, out hitRake))
            {
                var Obj = hitRake.collider.gameObject;
                if (Obj.GetComponent<IndentDraw>() != null)
                {
                    Debug.Log("alksdjfalk");
                    Obj.GetComponent<IndentDraw>().IndentAt(hitRake); //make indent in sand
                }
            }
        }

        void Start()
        {
            T = Time.time - stopT;
        }

        void Update()
        {
            if (Time.time > T + stopT)
            {
                Debug.Log("Start");
                var rake = GetComponent<Rigidbody>();
                //raycast of mouse
                RaycastHit hit;

                //checking for mouse action
                _mouseDrag = Input.GetMouseButton(0);

                //making indent
                foreach (Collider tooth in teeth)
                    contact(tooth);

                //making sand noises
                //if (tranform.velocity.magnitude > 1 && !SandNoise.isPlaying)
                //SandNoise.Play();
                if (_mouseDrag && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    Debug.Log("Start");
                    Vector3 To = hit.point;
                    To.y = consty;
                    Vector3 relativePos = transform.position - new Vector3(To.x, consty, To.z);
                    Quaternion rotation = Quaternion.LookRotation(relativePos);


                    Quaternion currentQ = transform.localRotation;
                    Vector3 currentV = transform.localPosition;
                    transform.rotation = Quaternion.Lerp(currentQ, rotation, rotationSpeed * Time.deltaTime);
                    transform.position = Vector3.Lerp(currentV, To, movementSpeed * Time.deltaTime);
                }
                if (bump(rake.GetComponent<Collider>()))
                {
                    T = Time.time;
                }
            }
        }
    }
}
