using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using System;
using System.Collections;
using Newtonsoft.Json.Linq;

public class CubeGenerator : MonoBehaviour
{

    public static CubeGenerator Instance { get { return instance; } }
    private static CubeGenerator instance;

    [SerializeField] TMP_InputField spawnTime;
    [SerializeField] TMP_InputField speed;
    [SerializeField] TMP_InputField distandce;

    [SerializeField] GameObject errorCanvas;
    [SerializeField] GameObject cube;

    private GameObject[] forDelete;

    private float spawnTimeFloat;
    private float speedFloat;
    private float distandceFloat;

    private Vector3 startPoint = Vector3.zero;

    [SerializeField] private bool isError = false;

    private void Start()
    {
        instance = this;

        spawnTimeFloat = ConvertToFloat(spawnTime.text);
        speedFloat = ConvertToFloat(speed.text);
        distandceFloat = ConvertToFloat(distandce.text);
        
        if(!isError)
            StartCoroutine("CreateCube");
    }


    IEnumerator CreateCube()
    {
        spawnTimeFloat = ConvertToFloat(spawnTime.text);
        speedFloat = ConvertToFloat(speed.text);
        distandceFloat = ConvertToFloat(distandce.text);
                
        GameObject newCube = Instantiate(cube, startPoint, Quaternion.identity);

        yield return new WaitForSeconds(spawnTimeFloat);
        if (!isError)
            StartCoroutine("CreateCube");
    }


    private float ConvertToFloat(string text)
    {
        float returnedFloat;

          if(float.TryParse(text, out returnedFloat))
          {
              isError = false;
              return returnedFloat;
          }
          else
          {
              isError = true;
              ShowError();
              return 0f;
          }
    }


    private void ShowError()
    {
        errorCanvas.SetActive(true);
    }
    

    public void CloseErrorWindow()
    {
        errorCanvas.SetActive(false);
        SetCorrect();
        StartCoroutine("CreateCube");
    }

    private void SetCorrect()
    {
        forDelete = GameObject.FindGameObjectsWithTag("Cube");

        foreach( GameObject go in forDelete)
        {
            Destroy(go);
        }

        spawnTime.text = "5";
        speed.text = "5";
        distandce.text = "10";

        spawnTimeFloat = 5f;
        speedFloat = 5f;
        distandceFloat = 10f;
        isError = false;
    }

    public float GetSpeed()
    {
        return speedFloat;
    }

    public float GetDistance()
    {
        return distandceFloat;
    }

}
