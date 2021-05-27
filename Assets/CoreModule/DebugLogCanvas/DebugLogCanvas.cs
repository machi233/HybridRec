using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class DebugLogCanvas: MonoBehaviour
{

    [SerializeField]
    private Text m_textUI = null;

    private bool status = false;



    public void SetON()
    {
        if (status == true)
        {
            return;
        }

        status = true;
        GetComponent<Canvas>().enabled = true;
        Application.logMessageReceived += OnLogMessage;
    }

    public void SetOFF()
    {
        if (status == false)
        {
            return;
        }

        status = false;
        GetComponent<Canvas>().enabled = false;
        Application.logMessageReceived -= OnLogMessage;
    }

    
    private void Awake()
    {


        SetON();




    }

    private void Start()
    {

    }


    private void OnLogMessage(string i_logText, string i_stackTrace, LogType i_type)
    {
        if (string.IsNullOrEmpty(i_logText))
        {
            return;
        }


        switch (i_type)
        {
            case LogType.Error:
            case LogType.Assert:
            case LogType.Exception:
                i_logText = string.Format("<color=red>{0}</color>", i_logText);
                break;
            case LogType.Warning:
                i_logText = string.Format("<color=yellow>{0}</color>", i_logText);
                break;
            default:
                break;
        }


        m_textUI.text += i_logText + System.Environment.NewLine;
    }


    private IEnumerator OutputTest()
    {
        while (true)
        {
            switch (UnityEngine.Random.Range(0, 3))
            {
                case 0:
                    Debug.LogFormat("Time:{0}", System.DateTime.Now);
                    break;
                case 1:
                    Debug.LogWarningFormat("Time:{0}", System.DateTime.Now);
                    break;
                case 2:
                    Debug.LogErrorFormat("Time:{0}", System.DateTime.Now);
                    break;

                default:
                    break;

            }
            yield return new WaitForSeconds(0.5f);
        }
    }


}