using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sample : MonoBehaviour
{
    int[] arr = { 1, 24, 1, 2 };
    void Start()
    {
        print(add(1,2));
        Debug.Log(sub(1,2));
        findHighNumber(arr);
        finddublicate(arr);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int add(int num1, int num2) {
        return num1 + num2;
    }
    int sub(int num1, int num2)
    {
        return num1 + num2;
    }

    void findHighNumber(int[] arr) {
        int max = 0;
        for(int i = 0; i < arr.Length; i++) {
            if (arr[i] > max) {
                max = arr[i];
            }
        }
    }
    void finddublicate(int[] arr) {
        int num = 0; 
        for (int i = 0; i < arr.Length; i++) { 
            
        }
    }
}
