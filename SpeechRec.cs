using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;


public class SpeechRec : MonoBehaviour
{
    public string[] keywords = new string[] { };
    public ConfidenceLevel confidence = ConfidenceLevel.Low;
    
    public GameObject Player;
    public CameraM Kamera;
    










    protected KeywordRecognizer recognizer;     // speech recognition engine based on Keywords
    protected string utterance = "";            // string to store recognised speech utterance
    protected bool bSpeechToProcess = false;    // boolean to record when some speech has been recognised and is ready to be processed
    

    private void Start()
    {
        
        
        
        


        GameObject g = GameObject.FindGameObjectWithTag("MainCamera");
        Kamera = g.GetComponent<CameraM>();
       


        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }

        
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        utterance = args.text;
        Debug.Log("utterance recognised = " + utterance);
        bSpeechToProcess = true;
    }

    private void Update()
    {
        



        
        if (bSpeechToProcess)       // if some speech input has been recognised, then we process it
        {
            switch (utterance)
            {
               

                
                case "Pew":
                    if (Kamera.GetComponent<CameraM>().status > 0)
                    {
                        Player.GetComponent<Player>().Shoot();
                    }



                    break;
                case "Boom":
                    if (Kamera.GetComponent<CameraM>().status > 0)
                    {
                        Player.GetComponent<Player>().Shoot();
                    }
                    break;

                case "Reload":
                    if (Kamera.GetComponent<CameraM>().status > 0)
                    {
                        Player.GetComponent<Player>().Reload();
                    }



                    break;

                case "Ready":
                    if (Kamera.GetComponent<CameraM>().status < 1)
                    {
                        Kamera.GetComponent<CameraM>().readyToGo();
                    }



                    break;


                case "Go":
                    if (Kamera.GetComponent<CameraM>().status < 1)
                    {
                        Kamera.GetComponent<CameraM>().readyToGo();
                    }



                    break;

                case "Yes":
                    if (Kamera.GetComponent<CameraM>().status < 1)
                    {
                        Kamera.GetComponent<CameraM>().readyToGo();
                    }

                    break;
                case "Left":
                    if (Kamera.GetComponent<CameraM>().status ==4)
                    {
                        Kamera.GetComponent<CameraM>().status = 6;
                    }

                    break;
                case "Right":
                    if (Kamera.GetComponent<CameraM>().status ==4)
                    {

                        Kamera.GetComponent<CameraM>().status = 5;
                    }
                    break;


                default:
                    Debug.Log("utterance recognised is <" + utterance + "> - no Mapped Action Assigned");
                    break;
            }

            
            bSpeechToProcess = false;
        }
    }

    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
   

   
}
