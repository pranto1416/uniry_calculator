using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    private float _result = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void ClickNumbers(int value)
    {
        Debug.Log(message: $"check value : (value)");
    }
}
