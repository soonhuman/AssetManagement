using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{

    public GameObject talkDisplay;
    public Text talkText;
    public GameObject lSDisplay;
    public GameObject toJewels;
    public GameObject toOldBooks;

    public InputField inputField;
    public Text displayInputText;
    public Text judgeText;
    public Text cPUMessage;

    private string text;
    private bool pushFlag = false;

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
        lSDisplay.SetActive(true);
        toJewels.SetActive(false);
        toOldBooks.SetActive(false);

        var scenario01 = new Scenario()
        {
            ScenarioID = "scenario01",
            Texts = new List<string>()
            {
                "�ˑR�Ă�ň������A�N�ɂ͎��̉Ƃ̎��Y�����𗊂݂����B",
                "���̉Ƃɂ͌Õ������������񂠂��ĂˁA\n���낻�됮���������Ǝv���Ă��Ă�񂾁B",
                "�����ŁA�Õ�����p�̋������A�����ŊǗ����ė~�����B\n���̖��O���Â����������邱�Ƃ��`���悤�ɂ������B",
                "�������Ȃ��A���̖��O�� OldBooks �ŗ��ށB",
                "�~�b�V�����F��� OldBooks ���쐬����I�J�n",
                "���Ȃ��͐V������� OldBooks �̍쐬�𖽗߂���܂����B\n�R�}���h���g�p���Ė��߂����s���܂��傤�B",
                "���̖���������Ē����m�F����R�}���h�� ls �ł��B\n�R���\�[���� ls �Ɠ��͂��Ď��s (Enter������) ���܂��傤�B",
                "�����肪���܂����I���͐V������� OldBooks ���쐬���܂��傤�B",
                "�����쐬����R�}���h�� mkdir ��於 �ł��B\n�R���\�[���� mkdir OldBooks �Ɠ��͂��Ď��s���܂��傤�B",
                "�V������� OldBooks ���������ł��Ă��邩����������Ċm�F���܂��B",
                "���̖���������Ē����m�F����R�}���h�� ls �ł��B\n�R���\�[���� ls �Ɠ��͂��Ď��s (Enter������) ���܂��傤�B",
                "��� OldBooks ���o���Ă���̂��m�F�ł��܂����I"
            },
            
        };

        inputField = GameObject.Find("InputField").GetComponent<InputField>();
        SetScenario(scenario01);
    }

    

    void SetScenario(Scenario scenario)
    {
        currentScenario = scenario;
        talkText.text = currentScenario.Texts[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScenario != null)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                if (pushFlag == false)
                {
                    pushFlag = true;

                    switch (index)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            SetNextMessage();
                            break;

                        case 4:
                            Play();
                            break;

                        case 5:
                        case 7:
                        case 9:
                        case 11:
                            SetNextMessageOnPlay();
                            break;

                        case 6:
                        case 8:
                        case 10:
                            break;
                    }

                }

            }

            else
            {
                pushFlag = false;
            }

        }

    }

    void SetNextMessage()
    {
        if (currentScenario.Texts.Count > index + 1)
        {
            index++;
            talkText.text = currentScenario.Texts[index];
        }
        else
        {
            SceneManager.LoadScene("ClearScene");
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
            SceneManager.LoadScene("ClearScene");
        }
    }

    void LSDisplayOn()
    {
        lSDisplay.SetActive(true);
        toJewels.SetActive(false);
        toOldBooks.SetActive(false);
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
        displayInputText.text = inputField.text;
        pushFlag = true;

        switch (index)
        {
            case 6:
            case 10:
                if (textValue == "ls")
                {
                    judgeText.text = "";
                    index++;
                    cPUMessage.text = currentScenario.Texts[index];
                    lSDisplay.SetActive(false);
                    
                    if(index == 7)
                    {
                        toJewels.SetActive(true);
                    }

                    else if(index == 11)
                    {
                        toJewels.SetActive(true);
                        toOldBooks.SetActive(true);
                    }

                }

                else
                {
                    judgeText.text = "�����ȃR�}���h�ł��B";
                }
                break;

            case 8:
                if (textValue == "mkdir OldBooks")
                {
                    judgeText.text = "";
                    index++;
                    cPUMessage.text = currentScenario.Texts[index];
                    LSDisplayOn();
                }

                else
                {
                    judgeText.text = "�����ȃR�}���h�ł��B";
                }
                break;
        }

    }
}
