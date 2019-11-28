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
}
