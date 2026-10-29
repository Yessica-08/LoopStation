using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public bool isPaused;

    public string interactuable;
    public Transform handGrableLeftPosition;

    public Transform handGrableRightPosition;

    public float rayDistance;

    public bool onFirstHandOcuped;

    public bool onSecondHandOcuped;

    private GameObject object1;
    private GameObject object2;

    private void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * rayDistance , Color.blue);
        
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            
        }
        else
        {
             if (context.started)
            {
            Interact();
            }  
        }
        
       
    }
    public void OnRelease(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            
        }
        else
        {
             if (context.started)
            {
            Release();
            }
        }
       
    }
    public void Interact()
    {
        Debug.Log("Agarrar");
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rayDistance))
        {
            if(hit.collider.CompareTag("InteruactableTag"))
            {
                if (!onFirstHandOcuped)
                {
                    Debug.Log("Tomo objeto");
                    onFirstHandOcuped = true;
                    hit.transform.GetComponent<Rigidbody>().isKinematic = true;

                    hit.transform.position = handGrableLeftPosition.position;
                   hit.transform.rotation = handGrableLeftPosition.rotation;

                    hit.transform.SetParent(handGrableLeftPosition);

                    object1 = hit.transform.gameObject;
                }
            
                else
                {
                    if (!onSecondHandOcuped)
                    {
                        Debug.Log("Tomo 2 Objeto");
                        onSecondHandOcuped = true;
                        hit.transform.GetComponent<Rigidbody>().isKinematic = true;

                        hit.transform.position = handGrableRightPosition.position;
                        hit.transform.rotation = handGrableRightPosition.rotation;

                        hit.transform.SetParent(handGrableRightPosition);

                        object2 = hit.transform.gameObject;
                    }
                }
            }

            if (hit.collider.CompareTag("InteractablePlace"))
            {
                if (onFirstHandOcuped)
                {
                    if(object1.GetComponent<ObjectID>().ID == hit.collider.GetComponent<ObjectPlace>().IDPlace) 
                    {
                        var temporalObject = object1;
                        Release();
                        temporalObject.GetComponent<Rigidbody>().isKinematic = true;
                        temporalObject.transform.position = hit.transform.position;
                        temporalObject.transform.rotation = hit.transform.rotation;
                        temporalObject.GetComponent<Collider>().enabled = false;
                        hit.collider.GetComponent<MeshRenderer>().enabled = false;
                        GameObject.FindAnyObjectByType<PlaceValidator>().CalculatePlaces();
                    }
                }
            }
        }
    }

  
    public void Release()
    {
        if (onFirstHandOcuped)
        {
            Debug.Log("Solto Objeto");
            object1.transform.parent = null;
            onFirstHandOcuped = false;
            
            object1.GetComponent<Rigidbody>().isKinematic = false;


            object1 = null;
            if (onSecondHandOcuped)
            {
                Debug.Log("Solto 2 Objeto");
                object2.transform.SetParent(handGrableLeftPosition);
                object2.transform.position = handGrableLeftPosition.position;
                object2.transform.rotation = handGrableLeftPosition.rotation;

                object1 = object2;
                object2 = null;

                onSecondHandOcuped = false;
                onFirstHandOcuped = true;
            }
        }
        
    }
}
