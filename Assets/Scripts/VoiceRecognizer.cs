using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
public class VoiceRecognizer : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, Action> keywords = new Dictionary<string, Action>();

    public GameObject player;
    
    void Start()
    {
        /*keywords.Add("hello", () =>
        {
            Debug.Log("User said hello");
        });
        Debug.Log("Started");
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray(), ConfidenceLevel.High);

        keywordRecognizer.OnPhraseRecognized += (PhraseRecognizedEventArgs ev) =>
        {
            Debug.Log(ev.text);
            if (keywords.TryGetValue(ev.text, out Action keywordAction))
            {
                keywordAction.Invoke();
            }
        };

        keywordRecognizer.Start();*/

        if (player != null)
        {
            var player_component = player.GetComponent<GameManager>();

            if(player_component != null)
            {
                keywords.Add("eet", player_component.eat);

                keywords.Add("wash", player_component.wash);

                keywords.Add("sleep", player_component.sleep);

                keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
            }
        }

        keywordRecognizer.OnPhraseRecognized += (PhraseRecognizedEventArgs ev) =>
        {
            Debug.Log(ev.text);
            if (keywords.TryGetValue(ev.text, out Action keywordAction))
            {
                keywordAction.Invoke();
            }
        };

        keywordRecognizer.Start();

    }
    
    void Update()
    {

    }
}
