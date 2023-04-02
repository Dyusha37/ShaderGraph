using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveControl : MonoBehaviour
{
    [SerializeField] float dissolveAmount;
    [SerializeField] float dissolveSpeed;
    [SerializeField] bool isDissolve;
    [ColorUsageAttribute(true, true)] public Color fadeColor;
    [ColorUsageAttribute(true, true)] public Color fadeInColor;

    [SerializeField] Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    public void DissolveColor(float speed, Color color)
    {
        mat.SetColor("_OutlineColor", color);
        if (dissolveAmount > -0.1)
        {
            dissolveAmount -= Time.deltaTime * speed;
        }
    }
    public void DissolveIn(float speed, Color color)
    {
        mat.SetColor("_OutlineColor", color);
        if (dissolveAmount <1)
        {
            dissolveAmount += Time.deltaTime * speed;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            isDissolve = true;
        if (Input.GetKeyDown(KeyCode.S))
            isDissolve = false;
        if (isDissolve)
        {
            DissolveColor(dissolveSpeed, fadeColor);
        }
        if (!isDissolve)
        {
            DissolveIn(dissolveSpeed, fadeInColor);
        }
        mat.SetFloat("_DissolveAmound", dissolveAmount);
    }
}
