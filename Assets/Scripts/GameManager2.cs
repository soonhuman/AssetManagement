using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public GameObject panelWalls;

    public GameObject talkDisplay;
    public Text talkText;
    public GameObject lSDisplay;
    public GameObject toJewels;
    public GameObject toOldBooks;

    public InputField inputField;
    public Text displayInputText;
    public Text judgeText;
    public Text cPUMessage;

    public GameObject imageRuby;
    public GameObject imageSapphire;
    public GameObject imageBook1;
    public GameObject imageBook2;

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

        imageRuby.SetActive(false);
        imageSapphire.SetActive(false);
        imageBook1.SetActive(false);
        imageBook2.SetActive(false);

        var scenario02 = new Scenario()
        {
            ScenarioID = "scenario01",
            Texts = new List<string>()
            {
                "���͕Еt�������Ȃ���Ȍ̂ɁA�Õ����ƕ�΂��ꊇ�� Jewels �ɊǗ����Ă��܂��Ă��ĂˁB",
                "�����ŌN�ɂ� Jewels �Ƃ������ɍs���Ă�����āA\n��������Õ������قǍ����Oldbooks�Ɉړ����ė~�����B",
                "�Õ����͖��O�� .txt �Ƃ��Ă��邩�炻��Ŕ��ʂ��Ă���B\n��낵�����ށB",
                "�~�b�V���� : ��� Jewels �Ɉړ����A\n�����ɂ���Õ�������� Oldbooks �Ɉړ�����I�J�n",
                "�܂��̓R�}���h���g�p���ċ�� Jewels �Ɉړ����܂��B",
                "�����ړ�����R�}���h�� cd ��於 �ł��B\n�R���\�[���� cd Jewels ����͂��Ď��s���܂��傤�B",
                "��� Jewels �Ɉړ����܂����I���͖���������Ē��g���m�F���܂��B\n�R���\�[���ɃR�}���h����͂��Ď��s���܂��傤�B",
                "�����肪���܂����I���� History1.txt ����� Oldbooks �Ɉړ����܂��B",
                "���ɂ��镨�𑼂̏ꏊ�Ɉړ�����R�}���h�� mv �ړ����������̖��O �ړ���̋��̏ꏊ �ł��B\n�R���\�[����  mv Hisoty1.txt /Hall/Oldbooks ����͂��Ď��s���܂��傤�B",
                "History1.txt ���ړ��ł������𖾂�������Ċm�F���܂��B\n�R���\�[���ɃR�}���h����͂��Ď��s���܂��傤�B",
                "History1.txt���ړ��ł����̂��m�F�ł��܂����I",
                "���� Hisoty2.txt ����� OldBooks �Ɉړ����܂��B\n�R���\�[���ɃR�}���h����͂��Ď��s���܂��傤�B",
                "History2.txt ���ړ��ł������𖾂�������Ċm�F���܂��B\n�R���\�[���ɃR�}���h����͂��Ď��s���܂��傤�B",
                "�Õ��� History1.txt �� History2.txt ���ړ��ł��܂����I"
            },

        };

        inputField = GameObject.Find("InputField").GetComponent<InputField>();
        SetScenario(scenario02);
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
                            SetNextMessage();
                            break;

                        case 3:
                            Play();
                            break;

                        case 4:
                        case 7:
                        case 10:
                        case 13:
                            SetNextMessageOnPlay();
                            break;

                        case 5:
                        case 6:
                        case 8:
                        case 9:
                        case 11:
                        case 12:
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

        imageRuby.SetActive(false);
        imageSapphire.SetActive(false);
        imageBook1.SetActive(false);
        imageBook2.SetActive(false);
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
            case 5:
                if (textValue == "cd Jewels")
                {
                    judgeText.text = "";
                    panelWalls.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    index++;
                    cPUMessage.text = currentScenario.Texts[index];
                    
                }

                else
                {
                    judgeText.text = "�����ȃR�}���h�ł��B";
                }
                break;

            case 6:
            case 9:
            case 12:
                if (textValue == "ls")
                {
                    judgeText.text = "";
                    index++;
                    cPUMessage.text = currentScenario.Texts[index];
                    lSDisplay.SetActive(false);

                    if (index == 7)
                    {
                        imageRuby.SetActive(true);
                        imageSapphire.SetActive(true);
                        imageBook1.SetActive(true);
                        imageBook2.SetActive(true);
                    }

                    else if (index == 10)
                    {
                        imageRuby.SetActive(true);
                        imageSapphire.SetActive(true);
                        imageBook2.SetActive(true);
                    }

                    else if (index == 13)
                    {
                        imageRuby.SetActive(true);
                        imageSapphire.SetActive(true);
                    }
                }

                else
                {
                    judgeText.text = "�����ȃR�}���h�ł��B";
                }
                break;

            case 8:
                if (textValue == "mv History1.txt /Hall/OldBooks")
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

            case 11:
                if (textValue == "mv History2.txt /Hall/OldBooks")
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