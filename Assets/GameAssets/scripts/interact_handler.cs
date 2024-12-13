using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using Unity.VisualScripting;
using UnityEngine;

public class interact_handler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private DistanceHandGrabInteractable distancehandinteractable;

    private GameObject last_selected_kunai;

    public float thrust = 10.0f;

    public void Start()
    {
        //GameObject temp_kunai = GameObject.FindGameObjectWithTag("kunai");
        //temp_kunai.transform.Rotate(180, 90, 90);
        //Rigidbody temp_rigidbody = temp_kunai.GetComponent<Rigidbody>();
        //temp_rigidbody.AddForce(temp_kunai.transform.up * thrust);
        //temp_rigidbody.AddForce(temp_kunai.transform.forward * thrust);
    }

    //[ContextMenu]
    public void onDeselect()
    {
        //if (last_selected_kunai != null)
        //{
        //transform.parent.gameObject.SetActive(false);
        GameObject Kunai = transform.parent.gameObject;
        Rigidbody rb = Kunai.GetComponent<Rigidbody>();

        //puzzlecandle1.transform.Find("Point Light").gameObject.SetActive(true);

        Debug.Log(transform.parent.name);
        //last_selected_kunai.transform.parent.gameObject.SetActive(false);
        //last_selected_kunai.SetActive(false);

        rb.AddForce(last_selected_kunai.transform.forward * thrust, ForceMode.Impulse);
        //rb.AddForce(Kunai.transform.up * thrust, ForceMode.Impulse);
            //rb.AddForce(last_selected_kunai.transform.right * thrust, ForceMode.Force);
            //rb.AddForce(last_selected_kunai.transform.forward * thrust, ForceMode.Force);
        //}
            
        
            
        //last_selected_kunai = null;

    }
    

    public void GetSelectingInteractorId()
    {
        
        if (distancehandinteractable.SelectingInteractorViews.Any())
        {

            //Debug.Log("Selecting interactor with id ");
            foreach (IInteractorView interactorView in distancehandinteractable.SelectingInteractorViews)
            {
                //transform.parent.gameObject.SetActive(false);
                //Debug.Log(interactorView.Data.ToString());
                last_selected_kunai = interactorView.Data as MonoBehaviour ? ((MonoBehaviour)interactorView.Data).gameObject : null;
                ////Debug.Log("kunai name " + kunai.
                //HandGrabInteractor kunai = interactorView.Data as HandGrabInteractor;
                //GameObject interble = kunai.TargetInteractable.
                //Debug.Log();
                last_selected_kunai = last_selected_kunai.transform.parent.gameObject;

                //Debug.Log(transform.parent.name);
            }

        }
    }

}
