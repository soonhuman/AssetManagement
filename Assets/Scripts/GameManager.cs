using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Text scenarioMessage;
    public GameObject talkDisplay;

    public Text cPUMessage;
    public InputField inputField;
    public Text displayInputText;
    // public GameObject placeHolder;

    private string text;


    List<Scenario> scenarios = new List<Scenario>();
    Scenario currentScenario;
    int index = 0;

    class Scenario
    {
        public string ScenarioID;
        public List<string> Texts;
        public string NextScenarioID;
    }

    // Start is called before the first frame update
    void Start()
    {
        var scenario01 = new Scenario()
        {
            ScenarioID = "scenario01",
            Texts = new List<string>()
            {
                "�ˑR�Ă�ň������A�N�ɂ͎��̉Ƃ̎��Y�����𗊂݂����B",
                "���̉Ƃɂ͌Õ������������񂠂��ĂˁA���낻�됮���������Ǝv���Ă��Ă�񂾁B",
                "�����ŁA�Õ�����p�̂����ŊǗ����ė~�����B���̖��O���Â����������邱�Ƃ��`���悤�ɂ������B",
                "�������Ȃ��A���̖��O�� OldBooks �ŗ��ށB",
                "�~�b�V�����F��� OldBooks ���쐬����I�J�n",
                "���Ȃ��͐V������� OldBooks �̍쐬�𖽗߂���܂����B�R�}���h���g�p���Ė��߂����s���܂��傤�B",
                "���̖���������Ē����m�F����R�}���h�� ls �ł��B�R���\�[���� ls �Ɠ��͂��Ď��s (Enter������) ���܂��傤�B",
                "�����肪���܂����I���͐V������� OldBooks ���쐬���܂��傤�B",
                "�����쐬����R�}���h�� mkdir ��於 �ł��B�R���\�[���� mkdir OldBooks �Ɠ��͂��Ď��s���܂��傤�B",
                "�V������� Oldbooks ���������ł��Ă��邩����������Ċm�F���܂��B",
                "���̖���������Ē����m�F����R�}���h�� ls �ł��B�R���\�[���� ls �Ɠ��͂��Ď��s (Enter������) ���܂��傤�B"

            },
            
        };

        inputField = GameObject.Find("InputField").GetComponent<InputField>();
        SetScenario(scenario01);
    }

    void SetScenario(Scenario scenario)
    {
        currentScenario = scenario;
        scenarioMessage.text = currentScenario.Texts[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScenario != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(index < 4)
                {
                    SetNextMessage();
                }

                else if(index == 4)
                {
                    Play();
                }

                else
                {

                }

            }

            else if (Input.GetKey(KeyCode.Return))
            {
                switch (index)
                {
                    case 5:
                        SetNextMessageOnPlay();
                        break;

                    case 6:
                        break;
                }
            }

        }

    }

    void SetNextMessage()
    {
        if (currentScenario.Texts.Count > index + 1)
        {
            index++;
            scenarioMessage.text = currentScenario.Texts[index];
        }
        else
        {
            ExitScenario();
        }
    }

    void SetNextMessageOnPlay()
    {
        if (currentScenario.Texts.Count > index + 1)
        {
            index++;
            cPUMessage.text = currentScenario.Texts[index];
        }
        else
        {
            ExitScenario();
        }
    }

    void ExitScenario()
    {
        scenarioMessage.text = "";
        index = 0;
        if (string.IsNullOrEmpty(currentScenario.NextScenarioID))
        {
            currentScenario = null;
        }
        else
        {
            var nextScenario = scenarios.Find
                (s => s.ScenarioID == currentScenario.NextScenarioID);
            currentScenario = nextScenario;
        }
    }

    void Play()
    {
        talkDisplay.SetActive(false);
        index++;
        cPUMessage.text = currentScenario.Texts[index];  
    }

    public void DisplayText()
    {
        string textValue = inputField.text;
        Debug.Log(textValue);


        switch (index)
        {
            case 6:
                if (textValue == "ls")
                {
                    index++;
                    cPUMessage.text = currentScenario.Texts[index];
                }

                else
                {
                    cPUMessage.text = "�����ȃR�}���h�ł��B";
                }
                break;
        }

    }
}
