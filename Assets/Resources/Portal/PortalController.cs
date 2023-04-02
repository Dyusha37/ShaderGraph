using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField] float circleClipStart;
    [SerializeField] float featherStart;
    [SerializeField] float ringWidthStart;

    [SerializeField] float portalSpeed;

    private float circleClipTarget;
    private float featherTarget;
    private float ringWidthTarget;

    private float circleClipCurrent;
    private float featherCurrent;
    private float ringWidthCurrent;

    private Material mat;
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        circleClipCurrent = Mathf.Lerp(circleClipCurrent, circleClipTarget, Time.deltaTime * portalSpeed);
        featherCurrent = Mathf.Lerp(featherCurrent, featherTarget, Time.deltaTime * portalSpeed);
        ringWidthCurrent = Mathf.Lerp(ringWidthCurrent, ringWidthTarget, Time.deltaTime * portalSpeed);

        if (Input.GetKeyDown(KeyCode.A))
        {
            circleClipTarget = circleClipStart;
            featherTarget = featherStart;
            ringWidthCurrent = ringWidthStart;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            circleClipTarget = 0;
            featherTarget = 0;
            ringWidthCurrent = 0;
        }
        mat.SetFloat("_CircleClip", circleClipCurrent);
        mat.SetFloat("_Feather", featherCurrent);
        mat.SetFloat("_CircleWidth", ringWidthCurrent);
    }
}
