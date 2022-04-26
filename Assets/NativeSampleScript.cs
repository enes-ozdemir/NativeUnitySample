using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;
using System;
using System.Text;

public class NativeSampleScript : MonoBehaviour
{
    [SerializeField] private TMP_InputField firstNumberInput;
    [SerializeField] private TMP_InputField secondNumberInput;
    [SerializeField] private TextMeshProUGUI sum;
    [SerializeField] private TextMeshProUGUI randomNumberText;
    [SerializeField] private TextMeshProUGUI cppText;
    [SerializeField] private TextMeshProUGUI isCppText;
    [SerializeField] private TextMeshProUGUI pointerText;

    [DllImport("SampleNativeProject.dll")]
    public static extern int getRandomNumber();

    [DllImport("SampleNativeProject.dll")]
    public static extern int sumNumbers(int a,int b);

    [DllImport("SampleNativeProject.dll")]
    public static extern void FillString(StringBuilder myString, int length);
    
    [DllImport("SampleNativeProject.dll")]
    public static extern bool isThisCpp();
  
    [DllImport("SampleNativeProject.dll")]
    public static extern int getPointer();

    public void GetPointer()
    {
        int c = getPointer();
        Debug.Log(c.ToString());
    }

    public void GetStringFromNativeCode()
    {
        StringBuilder str = new StringBuilder(100);
        FillString(str, str.Capacity);
        string myString = str.ToString();

        cppText.text = "C++ says: "+ myString;
    }

    public void GetBoolFromNativeCode()
    {
        isCppText.text = "Is this code from c++ : " + isThisCpp();
    }

    public void GetSumNumbersFromNativeCode()
    {   
        int FirstNumber = Convert.ToInt32(firstNumberInput.text);
        int SecondNumber = Convert.ToInt32(secondNumberInput.text);

        sum.text = "= "+ sumNumbers(FirstNumber, SecondNumber).ToString();
    }

    public void GetRandomNumberFromNative()
    {
        randomNumberText.text = "Random Number = "+ getRandomNumber().ToString();
    }
    public void GetPointerFromNative()
    {
        pointerText.text = "Pointer from c++ : " + getPointer().ToString();
    }

}
