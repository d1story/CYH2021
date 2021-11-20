using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Wacki.IndentSurface
{
    public class RakeM : MonoBehaviour
    {
        public AudioSource Noise, SandNoise;
        private bool _mouseDrag = false;
        public float movementSpeed, rotationSpeed, consty;
        public Collider[] teeth;
        private RayCast check;
        void bump(Collider rake, Vector3 To)
        {
            Collider[] into = Physics.OverlapBox(rake.bounds.center, rake.bounds.extents, rake.transform.rotation);

            if (into.Length > 4 && !Noise.isPlaying)
            {
                Noise.Play();
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

        void Start()
        {
            check = gameObject.GetComponentInChildren<RayCast>();
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

            if (_mouseDrag && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                //making sand noises
                if (!SandNoise.isPlaying)
                    SandNoise.Play();

                Vector3 To = hit.point;
                To.y = consty;
                Vector3 relativePos = transform.position - To;
                Quaternion rotation = Quaternion.LookRotation(relativePos);

                relativePos.y += 0.0f;
                To = check.R(To, -relativePos);
                To.y = consty;

                bump(rake.GetComponent<Collider>(), To);
                Quaternion currentQ = transform.localRotation;
                Vector3 currentV = transform.localPosition;
                transform.rotation = Quaternion.Lerp(currentQ, rotation, rotationSpeed * Time.deltaTime);
                transform.position = Vector3.Lerp(currentV, To, movementSpeed * Time.deltaTime);
            }
            else SandNoise.Stop();
        }
    }
}
