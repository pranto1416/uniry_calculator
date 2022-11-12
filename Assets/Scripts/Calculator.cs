using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{
    #region variables

    public TextMeshProUGUI InputText;
    private double _result;
    private List<int> _input = new List<int>();
    private List<int> _secondInput = new List<int>();
    private string _operator;
    private int _decimalPlace1;
    private int _decimalPlace2;
    

    #endregion variables

    // Start is called before the first frame update

    #region methods

    void Start()
    {
        _input = new();
        _secondInput = new();
    }

    public void ClickNumbers(int value)
    {
        Debug.Log($"  val: {value}");
        InputText.text = $"{value}";
        
        if(_operator == " ")
        {
            _input.Insert(0, value);
        }
        else
        {
            _secondInput.Insert(0, value);
        }
    }
    
    public void ClickOperators(string value)
    {
        _operator = value;
        Debug.Log($"  val: {value}");
    }

    public void ClickEquals(string value)
    {
        Debug.Log($"  val: {value}");

        double _dinput1 = 0;
        double _dinput2 = 0;

        for(int i = 0; i <= _input.Count; i++)
        {
            if(i < _decimalPlace1)
            {
                _dinput1 += _input[i] * Mathf.Pow(10, _decimalPlace1 - i - 1);

            }

            else
            {
                _dinput1 += _input[i] * Mathf.Pow(10, i);
            }
        }

        for (int i = 0; i <= _secondInput.Count; i++)
        {
            if (i < _decimalPlace1)
            {
                _dinput2 += _secondInput[i] * Mathf.Pow(10, _decimalPlace1 - i - 1);

            }

            else
            {
                _dinput2 += _secondInput[i] * Mathf.Pow(10, i);
            }
        }


        if (_dinput1 != 0 && _dinput2 != 0 && !string.IsNullOrEmpty(_operator))
        {
            switch (_operator)
            {
                case "+":
                    _result = _dinput1 + _dinput2;
                    break;

                case "-":
                    _result = _dinput1 - _dinput2;
                    break;

                case "*":
                    _result = _dinput1 * _dinput2;
                    break;

                case "/":
                    _result = _dinput1 / _dinput2;
                    break;

                
            }

            InputText.SetText(_result.ToString());
            ClearInput();
        }
    }

    public void ClickDot(string value)
    {
        Debug.Log($"  val: {value}");
        InputText.text = $"{value == "."}";
        if(_operator == "")
        {
            _decimalPlace1 = _input.Count;
        }
        else
        {
            _decimalPlace2 = _secondInput.Count;
        }
        
    }

    public void ClickAC(string value)
    {
        Debug.Log($"  val: {value}");
        ClearInput();
    }


    public void ClickSquareRoot(string value)
    {
        Debug.Log($"  val: {value}");
    }

    public void ClickPower(string value)
    {
        Debug.Log($"  val: {value}");
    }

    public void ClearInput()
    {
        _input = new();
        _secondInput = new();
        _operator = "";
        
    }

    #endregion methods
}
