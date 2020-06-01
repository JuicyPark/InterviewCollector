using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    Question[] questions;
    int currentIndex;

    [SerializeField]
    Text questionText;
    [SerializeField]
    Text answerText;

    bool isOpen;
    WaitForSeconds typingDelay = new WaitForSeconds(0.02f);

    void Start()
    {
        LoadQuestion();
        UpdateQuestion();
    }

    public void ChangePanel(Direction direction)
    {
        if (direction.Equals(Direction.NONE))
        {
            ActivateAnswerPanel();
            return;
        }
        else if (direction.Equals(Direction.LEFT))
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = questions.Length - 1;
        }
        else if (direction.Equals(Direction.RIGHT))
        {
            currentIndex++;
            if (currentIndex > questions.Length - 1)
                currentIndex = 0;
        }
        UpdateQuestion();
    }
    void ActivateAnswerPanel()
    {
        answerText.enabled = !isOpen;
        isOpen = !isOpen;
    }

    void UpdateQuestion()
    {
        isOpen = false;
        answerText.enabled = isOpen;

        StopAllCoroutines();
        StartCoroutine(CTypingString(questionText, questions[currentIndex].question));
        answerText.text = questions[currentIndex].answer;
    }

    IEnumerator CTypingString(Text target, string str)
    {
        target.text = "";
        for (int i = 0; i < str.Length; i++)
        {
            target.text += str[i];
            yield return typingDelay;
        }
    }

    void LoadQuestion()
    {
        questions = Resources.LoadAll<Question>("");
        Shuffle();
    }

    void Shuffle()
    {
        int first, second;
        Question temp;

        for(int i = 0; i< 20;i++)
        {
            first = Random.Range(0, questions.Length);
            second = Random.Range(0, questions.Length);

            temp = questions[first];
            questions[first] = questions[second];
            questions[second] = temp;
        }
    }
}
