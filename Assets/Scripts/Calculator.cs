using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Calculator : MonoBehaviour
{
    #region variables

    public TextMeshProUGUI InputText;
    private double _result;
    private int _input;
    private int _secondInput;
    private string _currentInput;
    private string _operator;
    private int _decimalPlace1;
    private int _decimalPlace2;
    private bool _equalIsPressed;


    #endregion variables

    // Start is called before the first frame update

    #region methods

    void Start()
    {

    }

    public void ClickNumbers(int value)
    {
        Debug.Log($"  val: {value}");

        if (!string.IsNullOrEmpty(_currentInput) && _currentInput.Length < 10)
        {
            _currentInput += value;

        }
        else
        {
            _currentInput = value.ToString();
        }
        InputText.text = $"{_currentInput}";

    }

    public void ClickOperators(string value)
    {
        Debug.Log($"  val: {value}");
        if (_input == 0)
        {
            SetCurrentInput();
            _operator = value;
        }
        else
        {
            if (_equalIsPressed)
            {
                _equalIsPressed = false;
                _operator = value;
                _secondInput = 0;

            }
            else
            {
                if (_operator.Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    Calculate();
                }
                else
                {
                    _operator = value;
                    _secondInput = 0;
                }
            }

        }
    }

    public void ClickEquals(string value)
    {
        Debug.Log($"  val: {value}");
        Calculate();
        _equalIsPressed = true;

    }

    private void Calculate()
    {
        if (_input != 0 && !string.IsNullOrEmpty(_operator))
        {
            SetCurrentInput();
            switch (_operator)
            {
                case "+":
                    _result = _input + _secondInput;
                    break;

                case "-":
                    _result = _input + _secondInput;
                    break;

                case "*":
                    _result = _input + _secondInput;
                    break;


                case "/":
                    _result = _input + _secondInput;
                    break;


            }
            InputText.SetText(_result.ToString());

            _input = (int)_result;
        }
    }

    private void SetCurrentInput()
    {
        if (!string.IsNullOrEmpty(_currentInput))
        {
            if (_input == 0)
            {
                _input = int.Parse(_currentInput);
            }
            else
            {
                _secondInput = int.Parse(_currentInput);
            }
            _currentInput = "";
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
        _currentInput = "";
        _input = 0;
        _secondInput = 0;
        _result = 0;
        InputText.SetText("");
    }

    #endregion methods
}