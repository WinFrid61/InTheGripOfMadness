using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGroundCheck : MonoBehaviour
{
    public GameObject GroundCheck, GroundCheckL, GroundCheckR, GroundCheck2, GroundCheckL2, GroundCheckR2, GroundCheck3, GroundCheckL3, GroundCheckR3;
    public BoxColliderSit Check;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Check.SitR) {
            GroundCheck.SetActive(false);
            GroundCheckR.SetActive(false);
            GroundCheckL.SetActive(false);
            GroundCheck2.SetActive(true);
            GroundCheckR2.SetActive(true);
            GroundCheckL2.SetActive(true);
            GroundCheck3.SetActive(false);
            GroundCheckR3.SetActive(false);
            GroundCheckL3.SetActive(false);
        }
        else if (Check.SitL)
        {
            GroundCheck.SetActive(false);
            GroundCheckR.SetActive(false);
            GroundCheckL.SetActive(false);
            GroundCheck2.SetActive(false);
            GroundCheckR2.SetActive(false);
            GroundCheckL2.SetActive(false);
            GroundCheck3.SetActive(true);
            GroundCheckR3.SetActive(true);
            GroundCheckL3.SetActive(true);
        }
        else
        {
                GroundCheck.SetActive(true);
                GroundCheckR.SetActive(true);
                GroundCheckL.SetActive(true);
                GroundCheck2.SetActive(false);
                GroundCheckR2.SetActive(false);
                GroundCheckL2.SetActive(false);
                GroundCheck3.SetActive(false);
                GroundCheckR3.SetActive(false);
                GroundCheckL3.SetActive(false);
        }

    }
}
