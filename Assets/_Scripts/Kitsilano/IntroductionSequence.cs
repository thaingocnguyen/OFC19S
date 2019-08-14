using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

namespace KitsilanoScene
{
    public class IntroductionSequence : MonoBehaviour
    {
        public bool debugMode;
        public float typeSpeed = 0.05f;
        public float fadeOutTime;

        public GameObject characterDialogue;
        public GameObject textboxRenee;
        public TextMeshProUGUI displayedTextRenee;
        public GameObject textboxTheresa;
        public TextMeshProUGUI displayedTextTheresa;
        private TextMeshProUGUI displayedText;
        public Queue<Dialogue> conversation;
        private bool displayingSentence;

        public PlayableDirector cutscene;

        private void Awake()
        {
            conversation = new Queue<Dialogue>();
            conversation.Enqueue(new Dialogue("r", "Renee dialogue here"));
            conversation.Enqueue(new Dialogue("t", "Theresa dialogue here"));
            conversation.Enqueue(new Dialogue("r", "Renee dialogue here"));
            conversation.Enqueue(new Dialogue("t", "Theresa dialogue here"));
        }

        public void StartIntroductionSequence()
        {
            characterDialogue.SetActive(true);
            DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            if (!displayingSentence || debugMode)
            {
                if (conversation.Count == 0)
                {
                    GlobalControl.Instance.startCutscenePlayed = true;
                    StartCoroutine(FadeAway(characterDialogue));
                    cutscene.Play();
                    return;
                }

                Dialogue dialogue = conversation.Dequeue();
                StopAllCoroutines();
                StartCoroutine(TypeSentence(dialogue.character, dialogue.text));
            }
        }

        IEnumerator TypeSentence(string character, string sentence)
        {
            displayingSentence = true;

            if (character.Equals("r"))
            {
                textboxRenee.SetActive(true);
                textboxTheresa.SetActive(false);
                displayedText = displayedTextRenee;
            }
            else
            {
                textboxRenee.SetActive(false);
                textboxTheresa.SetActive(true);
                displayedText = displayedTextTheresa;
            }

            displayedText.text = "";
            foreach (char letter in sentence)
            {
                displayedText.text += letter;
                yield return new WaitForSeconds(typeSpeed);
            }
            displayingSentence = false;
        }

        private IEnumerator FadeAway(GameObject objectToFade)
        {
            CanvasGroup canvasGroup = objectToFade.GetComponent<CanvasGroup>();

            for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
            {
                canvasGroup.alpha = Mathf.Lerp(1, 0, Mathf.Min(1, t / fadeOutTime));
                yield return null;
            }
            canvasGroup.alpha = 0;
        }
    }
}

