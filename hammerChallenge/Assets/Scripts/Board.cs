using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    bool m_Started;
    public LayerMask m_LayerMask;

    void Start()
    {
        //Use this to ensure that the Gizmos are being drawn when in Play Mode.
        m_Started = true;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("hammer") )
        {
            print("hammer touched");
            DetectTouchingColliders();
        }
    }


    void DetectTouchingColliders()
    {
        Collider[] hitColliders = Physics.OverlapBox(
            gameObject.transform.position, 
            transform.localScale/2 , 
            Quaternion.identity, 
            m_LayerMask);
        
        foreach (Collider hitCollider in hitColliders)
        {
            hitCollider.GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);
        }
    }

    //Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
