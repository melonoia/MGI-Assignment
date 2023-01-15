using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI inputText;
    public TextMeshProUGUI answerText;
    private string first;
    
    private float firstNumber;
    private float secondNumber;
    private string operation;
    
    private bool ops;
    private bool nps;
    
    private float res;

    // Start is called before the first frame update
    void Start()
    {
		res = 0;
		inputText.text = answerText.text = "";
		ops = false;
		nps = true;
    }

    public void NumberClick(Button b)
    {

		if(b.name == ".")
		{			
			if(!nps)
			{			
				b.enabled = false;
				nps = true;
			}
			else{
				nps = false;
				answerText.text = answerText.text + b.name;
			}
		}
		else
		{
			GameObject.Find(".").GetComponent<Button>().enabled = true;				
			answerText.text += b.name;
		}
		
    }
    
    public void OperationClick(Button o)
    {			
			operation = o.name;	
			string ans = answerText.text;
			ans += operation;	
			
			if(!ans.StartsWith(operation))
			{		
						firstNumber = float.Parse(answerText.text);   		
						answerText.text += operation;
						inputText.text = answerText.text; 
						answerText.text = "";
						GameObject.Find("Equals").GetComponent<Button>().enabled = true;				
						ops = true;
			} 
					else
					{
						inputText.text = "invalid input";
					}
		
   }
    
    public void Equals(Button b)
    { 
			if(ops)
			{
				secondNumber = float.Parse(answerText.text);
				inputText.text += secondNumber;    
				ops = false;		
				
			switch(operation)
			{
				case "+":
				res = Add();
				break;
				
				case "-":
				res = Minus();
				break;
				
				case "*":
				res = Multiply();
				break;
				
				case "/":
				res = Divide();
				break;
				
				default:
				inputText.text = "Invalid Input";
				break;
			}
			
				answerText.text = res.ToString();
				b.enabled = false;
				
			}
						    	
    }

    float Add()
    {
			return firstNumber + secondNumber;
    }

    float Minus()
    {
				return firstNumber - secondNumber;
    }

    float Divide()
    {
			return firstNumber / secondNumber;
    }

    float Multiply()
    {
		return firstNumber * secondNumber;
    }
    
    public void Backspace()
    {
    	if(answerText.text.Length != 0)
    	{
			answerText.text = answerText.text.Remove(answerText.text.Length - 1);
    	}
    }

    public void Clear()
    {
        inputText.text = answerText.text = "";
    }

}
