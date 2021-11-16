using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Wacki.IndentSurface
{
    public class RakeM : MonoBehaviour
    {
        private bool _mouseDrag = false;
        public float movementSpeed, rotationSpeed, consty, stopT, X, Y, Z;
        public AudioSource SandNoise;
        public Collider[] teeth;
        void bump(Collider rake)
        {
            Collider[] into = Physics.OverlapBox(rake.bounds.center, rake.bounds.extents, rake.transform.rotation);

            foreach (Collider other in into)
            {
                if (other.gameObject.GetComponent<ProdNoise>() != null)
                {
                    //Debug.Log("InIn");
                    //other.gameObject.GetComponent<ProdNoise>().PPlay();
                }
            }
        }

        private void contact(Collider col)
        {
            RaycastHit hitRake;
            if (Physics.Raycast(col.bounds.center, Vector3.down, out hitRake))
            {
                var Obj = hitRake.collider.gameObject;
                if (Obj.GetComponent<IndentDraw>() != null)
                {
                    Obj.GetComponent<IndentDraw>().IndentAt(hitRake); //make indent in sand
                }
            }
        }

        void Update()
        {
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
                Vector3 To = hit.point;
                To.y = consty;
                Vector3 relativePos = transform.position - To;
                Quaternion rotation = Quaternion.LookRotation(relativePos);

                //find start cus unity big gay
                Vector3 from = new Vector3(transform.position.x - X, transform.position.y - Y, transform.position.z - Z);
                Debug.DrawRay(from, To-from, Color.white);
                //check if there is some thing in the way
                RaycastHit temp;
                if (Physics.Raycast(from, To-from, out temp))
                {
                    To = temp.point;
                    Debug.DrawRay(from, To-from, Color.red);
                    Debug.Log(temp.collider.gameObject.name);
                }
                To.y = consty;

                Quaternion currentQ = transform.localRotation;
                Vector3 currentV = transform.localPosition;
                transform.rotation = Quaternion.Lerp(currentQ, rotation, rotationSpeed * Time.deltaTime);
                transform.position = Vector3.Lerp(currentV, To, movementSpeed * Time.deltaTime);
                bump(rake.GetComponent<Collider>());
            }
        }
    }
}
