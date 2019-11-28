using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    private Transform m_transform;
    public GameObject prefab;
    private GameObject[] m_gameObjects;

    // Start is called before the first frame update
    void Start()
    { 
        m_transform = transform;

        //InstantiateTest();

        m_gameObjects = new GameObject[1000];

        for (int i = 0; i < m_gameObjects.Length; i++)
        {
            GameObject tempObject = Instantiate(prefab);

            m_gameObjects[i] = tempObject;

            m_gameObjects[i].SetActive(false);  
        }

        Debug.Log(CompareStrings("Yes", "No"));

        string val1 = "Yes";
        string val2 = "Yes";

        int string1 = val1.GetHashCode();
        int string2 = val2.GetHashCode();

        Debug.Log(CompareStrings(string1, string2));
    }
    
    void OptimisedInstantiateTest()
    {
        for (int i = 0; i < m_gameObjects.Length; i++)
        {
            m_gameObjects[i].SetActive(true);
            m_gameObjects[i].transform.position = new Vector3(1, 4, 0);
            m_gameObjects[i].SetActive(false);
        }
    }

    void InstantiateTest()
    {
        for (int i = 0; i < 1000; i++)
        {
            GameObject tempObject = Instantiate(prefab);
            tempObject.transform.position = new Vector3(1, 4, 0);
            Destroy(tempObject);
        }
        
    }

    void TransformTest()
    {
        for (int i = 0; i < 10000; i++)
        {
            m_transform.position = Vector3.zero;
        }
    }

    void ObjectAllocation()
    {
        for (int i = 0; i < 100; i++) 
        {
            int firstInt = 1;
            firstInt++;
            int secondInt = firstInt;

            ComplexObjects complexObjects = new ComplexObjects();

            if(secondInt == firstInt)
            {
                firstInt++;
            }

            ComplexObjects1 complexObjects1 = new ComplexObjects1();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //TransformTest();

        //ObjectAllocation();

        //InstantiateTest();

        OptimisedInstantiateTest();
    }

    private float[] RandomValues(int _amount)
    {
        var numberList = new float[_amount];

        for (int i = 0; i < _amount; i++)
        {
            numberList[i] = Random.value;
        }

        return numberList;
    }

    private void OptimisedRandomValues(float[] _arrayToFill)
    {
        for (int i = 0; i < _arrayToFill.Length; i++)
        {
            _arrayToFill[i] = Random.value;
        }
    }

    private bool CompareStrings(string _string1, string _string2)
    {
        if(_string1 == _string2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CompareStrings(int _string1, int _string2)
    {
        if (_string1 == _string2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
