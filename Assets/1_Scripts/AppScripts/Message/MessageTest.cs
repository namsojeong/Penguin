using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageTest : MonoBehaviour
{
    [SerializeField]
    GameObject timerPanel;
    [SerializeField]
    GameObject[] buttons;
    [SerializeField]
    Button lastButton;

    public Text chat1;
    public Text chat2;
    public Text chat3;
    public Text chat4;
    public Text chat5;
    public Text chat6;

    List<string> messages_1 = new List<string>();
    List<string> messages_2 = new List<string>();
    List<string> messages_3 = new List<string>();
    List<string> messages_4 = new List<string>();
    List<string> messages_5 = new List<string>();
    List<string> messages_6 = new List<string>();

    private int RandomNum1, RandomNum2, RandomNum3, RandomNum4, RandomNum5;

    void Awake()
    {
        //--ù��°, ���--
        messages_1.Add("��������.. ������ ��δ� ����!!><");
        messages_1.Add("���ڱ� ���� ���Ǫ�� �Ƴ�? ��");
        messages_1.Add("�� ��¥�� ���ǿ����� �ڶ� �Ÿ��� ��������!");
        messages_1.Add("�� ���? ������ ���� �� �۰� �ƴϾ�?!");
        messages_1.Add("�� �ܼ��� �ٸ� ©���� ������ �ƴ��̶�!");
        messages_1.Add("�̰� ����ε��� �� ������ �ܸ��� ������ ���Ѵ�?!");
        messages_1.Add("����.. ��ο� �����ҵ�.. �÷��� ��Ÿ����");
        messages_1.Add("�̵��� ����� ��ġ ũ������ ��ɰ��� ������?");
        messages_1.Add("�� 500m ������ ���� �ٴٿ����� ����� ÷��~");
        messages_1.Add("�����۵�ٴ�ǥ���� �ʹ� ���ҿ�.. ��ƾ�");//10
        messages_1.Add("���ؿ� ���� ���� ������ �ʹ� ��������..");
        messages_1.Add("���� �ȳȳ�~ �� ���� ���ִ� �� �Ծ��!");
        messages_1.Add("�ʰ� �� ���� �������� ���� �νŰű�??");
        messages_1.Add("���� �����ؾ���! �ʰ��� ������ ��� ��Ǫ�ϱ�..");
        messages_1.Add("�ȳ�! ���õ��� �հ� �� �̻Ǻ��̳� ����");
        messages_1.Add("���� ���Կ��� �� �� �̵��� �󸶳� ������?");
        messages_1.Add("�� �ĸ� ���ξ�! ��!! �� �����Ұ� ������,, ũũ");
        messages_1.Add("���� ���� �ð��� �Ʊ��.. �� ���� ��Ÿ�ϱ��");
        messages_1.Add("�տ� �� ���̰ſ� �� �� �������� ������' ũũ ");
        messages_1.Add("�Ȥ���~ ���� ������ ������? �������� ���N����");//20
        messages_1.Add("�� ���� �� �� �پ��? ũũ �β�����");
        messages_1.Add("���! ��ħ �ʿ��� �� ���� �̽�µ� ũũ");
        messages_1.Add("�հ� �Ϸ� �Ϸ� �����ϰ� �̵��� ������ �巯");
        messages_1.Add("����� ���� �������ΰ� �˰� ����..? ���� ��Ǫ��");
        messages_1.Add("���� ù����� �����ı�..? �ٷ� ������!!");
        messages_1.Add("��? ���� Ű�� ¥�����δٱ�? �� Ű�� ���� 60cm��!");
        messages_1.Add("�ʵ� ȯ�� � �Բ�����! �׷� ������ �� ������������!");
        messages_1.Add("���� �����ϴ� ������ �ձ�����~ �ձ۵ձ�~ ");
        messages_1.Add("4�� 25���� ���� ���̰�~ �ٷο� ���� ����� ���̾�! ");
        messages_1.Add("������ ���� ��Ȱ�ϴ� �Ϳ� �������� ������");//30
        messages_1.Add("���Ͽ��� ��� �ִ� �ȸ�..�ƺ���..�� �� ��Ǳ�?");
        messages_1.Add("���ؿ��� �� �� �ٴ� �� ����¥�� �η����� ����� ���½�");
        messages_1.Add("����� Ŀ�� �밨�� ����� �Ǳ�����!");
        messages_1.Add("��� �� �����ϴ� ������ 412������! ������ ���");
        messages_1.Add("���� �̾߱⸦ �巯�þ��ַ� �Ա���! �빫�ʹ��� ����~");
        messages_1.Add("��𰡵��� �ͽ�! �������ٱ�..! ����");
        messages_1.Add("�� �����ϰ� �̽�´� ��ħ �Գ׿�?");
        messages_1.Add("���! �׻� ��ٸ��� �̽�����");
        messages_1.Add("���ִ� �� �Դ°� ������ �ຸ��");
        messages_1.Add("�ȳ�ȳվȳ�~ ��;ƾƾƾ� ũũ");//40
        messages_1.Add("������ �̼������� ������?");


        //--�ι���, ��㿡 ���� ���--
        messages_2.Add("��~");
        messages_2.Add("��!!");
        messages_2.Add("����?");
        messages_2.Add("����!");
        messages_2.Add("��~");
        messages_2.Add("��");
        messages_2.Add("��");
        messages_2.Add("����");
        messages_2.Add("��?");
        messages_2.Add("��!");
        messages_2.Add("����");

        //--����°, ȯ�� ��� ����--

        messages_3.Add("Ŀ�� �� �� ������ �����ϰ� ����� ����!");
        messages_3.Add("���~�� ���ľ����⸦ ���ݸ� �ٿ���");
        messages_3.Add("��ȸ��ǰ�� ���� ���� ����߰Խ�!");
        messages_3.Add("���Ĺ� �����⸦ �����ϴ� �͵� �߿���");
        messages_3.Add("�ǳ� �µ��� �����ϰ� �����غ��� �� ���?");
        messages_3.Add("Ƽ�� ���� �� ��ġ�� �ʹ� ���� ���°�..");
        messages_3.Add("������� �ʴ� ������ ��� ��� ��������!");
        messages_3.Add("����� ���� ���� ���� ������ ������ �ƾ��Ѵ��");
        messages_3.Add("���������� ���� ��ư ������ �� ���̴� �Ŷ�");
        messages_3.Add("���߱����� ����ϴ� �͵� ������..!"); //10
        messages_3.Add("���� ������ ������ ����� ��� �����ٸ�?");
        messages_3.Add("����� �η������� ������ �� �� �������!");
        messages_3.Add("���� ��Һ����� ���� ������� �Ƴ�?");
        messages_3.Add("���� ���� ���� �������Ƴ�..?");
        messages_3.Add("���� ���൵ �̵�? ������ ȯ���� ��ȣ�ϱ� ����");
        messages_3.Add("���� �� �� �� ������ �׳� �����°� �ƴϰ���?");
        messages_3.Add("�ܿ￡ ���� �β��� �԰� �ٴϴ°� ���� �ʾ���?");
        messages_3.Add("Ȥ�� ���� �� ���ϴٱ� ���� ��������!");
        messages_3.Add("�ٵ� �������� �� �̷��� ���� ���°���?");
        messages_3.Add("��ǻ�͸� ���� �ʴ°� �ƴϰ���?"); //20
        messages_3.Add("����� �� ������ ����ϴ� �� ���ٴ�");
        messages_3.Add("�ǵ�ǵ�! ��ĥ �� ���� �����߾�");
        messages_3.Add("����� ���� ���� ���� ��! �� �Ʊ��� �Ƴ�?");
        messages_3.Add("�׳� �ƹ� �ų� �� ��� �� ���ٴ�");
        messages_3.Add("��? Ȥ�� ȯ�渶ũ��� �� �˾�? ��? ��??");
        messages_3.Add("����� �ǳ� �ָӴϿ� �ռ����� ������ �ٴ��� ��."); //�̰� �������� ����
        messages_3.Add("�������� ����غ��� �� ���ƾ�?");
        messages_3.Add("�ڵ��� ���� ����, ��� ������ ���̴°Ŵ�");
        messages_3.Add("���Ĺ� �����⴫ ������ �ӿ� �ִ� �̻����� �̿��ؼ�");
        messages_3.Add("�޷��޷�~ ���ο� ���� 1���� ����� ���ؼ���"); //30
        messages_3.Add("�� �ӿ� ��� ������, �����̿� ���� ���� �����帮");
        messages_3.Add("���� ������ ���� ū ������ �ڵ����� ��Ⱑ����");
        messages_3.Add("�츮�� ������ ���� ������ ���ӿ��� ���ظ� ���Ѿ���!");
        messages_3.Add("�̼������� ���� ��, �ݷ��ݷ� ������ �ؾ� �� ��쿡��");
        messages_3.Add("�������� �Ϲݾ������ ������ ����� ������Ű��");
        messages_3.Add("ġīġī�ϴ� ĩ���� �ֱ������� ��ü�������");
        messages_3.Add("�ö�ƽ ����� ��Ȱ���� �����ұ�ƾ�?"); //37

        //--�׹�°, ȯ�� ��Ŀ� ���� ���--
        messages_4.Add("��!");
        messages_4.Add("��");
        messages_4.Add("����");
        messages_4.Add("��~!");
        messages_4.Add("����!");
        messages_4.Add("��ȣ��!");

        //--�ټ���°, ȯ�� ��� ���� ���� (ȯ���� ���� �������� �Ȱ��� �� ��!)--
        messages_5.Add("���� ������ �� 19���� �ʿ��ϴ�!");
        messages_5.Add("���Ĺ� ó����� 1,700����̳��� ����ȴٱ�!");
        messages_5.Add("ȯ���� ���� ���̳����� �������̶�!");
        messages_5.Add("�˸��� �縸 �����ϸ� ���� ������ �� �̽�");
        messages_5.Add("��� ���� ������ �ʾ ���� �߻��ϰ� �̽�");
        messages_5.Add("���Ⱑ �빫 ���� ����! �� ������ �� ����!");
        messages_5.Add("�׷� ������ ��߹�� ���� �� �̶԰ž�!");
        messages_5.Add("�ɿ��ݾ��� �ٿ����°� ���ƾ�?");
        messages_5.Add("���⸦ �����̶�� �Ƴ� �� �ִ� ����̷�");
        messages_5.Add("��� ���� ������ ���� �� �ִ� ����̾�");
        messages_5.Add("���ó� ���� ��ߴ� ��� �� �ӿ� ���� �ɲ���");
        messages_5.Add("�η������� ����ִ� ���� ��ȭ��ġ���! �ű�����?");
        messages_5.Add("�׺��� ���ڹ��� ����ϸ� ������ ��ų �� �̽�!");
        messages_5.Add("������ �����̶� �ΰ� �Һ��� �ݻ�Ǿ�� ����");
        messages_5.Add("��ȭ �������� �̿��Ѵٴ� �����̾�! �ʹ� �ຸ��");
        messages_5.Add("������ �Ʋ����� ������ �淯���ڱ����!");
        messages_5.Add("�׸��� ������ ���̰� �ǳ� �µ��� ���߿������");
        messages_5.Add("���� �ÿ��� �ݵ�� �ҵ��ߴ��� Ȯ���� �ʼ���");
        messages_5.Add("��ä�� ��ǳ�Ⱑ �ִµ� ������! �� �� ����..");
        messages_5.Add("��ǻ�� ������� ���� ���� ���� ���� ������ ������");
        messages_5.Add("�����⸦ ����ϴ��� �� ����! �� ����ϱ�!");
        messages_5.Add("���������� �� �� �ᰡ����! ���������� ���ڳ�..");
        messages_5.Add("��Ź�̳� û�ҿ����� �����ϴ� ����� �˱��ֳ���?");
        messages_5.Add("ȯ�� ģȭ���� ��ǰ�� �����ϴ°� �������� �� ������?");
        messages_5.Add("�̿� ��°� ȯ�� ��ũ�� �پ��ִ� ��ǰ�� �̿�����");
        messages_5.Add("������ ���� ���� ���� �ųʶ��?");
        messages_5.Add("���� �������� ����ϴ� ����� ������ ũũ.. ");
        messages_5.Add("���� ���ظ� ���� �� �ִ� ���� ������� ����");
        messages_5.Add("ģȯ�� ������ ��� ����� �� ��Ȱ���� �� �̽�");
        messages_5.Add("���� 24�׷�, �� 86���� �Ƿ��ϴٴ� ���� �� ������!");
        messages_5.Add("���� �����ϰ� ������ ��Ȱ�� ������ �ְ� �̶���.");
        messages_5.Add("�츮���� �ʿ��� ������ ���δ� ������ �ſ� �����Ͽ���");
        messages_5.Add("�ٵ� �ɸ��� �ð��� ���� 450���̳� �ɸ��ٱ� �ؿ�");
        messages_5.Add("�� �� ����ũ�� �����ؿ�! �̰� ��¥ ����̾�!");
        messages_5.Add("��� �� ���� ������Ű�ϱ� ������� �����Կ� ������");
        messages_5.Add("�ٵ� �̰� ��𿡴� �����ı�? �Ϲݾ������!");
        messages_5.Add("��� �ƴ�¡ �ٷ�! �Ϲݾ����⿡ �־���� ������");
        //--������°, �ۺ��λ�--

        messages_6.Add("�׷� �߰�!");
        messages_6.Add("����");
        messages_6.Add("���� �Ϸ� ����!");
        messages_6.Add("���߿� �ٽ� ����!");
        messages_6.Add("�� �� ��� ������ ���ٰ���?");
        messages_6.Add("�� ��� ����༭ ����");
        messages_6.Add("�׷� ȯ���� ��Ű�� ������?");
        messages_6.Add("����� �� ��⸦ ����༭ �ʹ� ����");
        messages_6.Add("�츮�� ���� ��õ�� ������ ����!");
    }


    EventParam eventParam = new EventParam();
    private void OnEnable()
    {
        IsState();
    }

    void IsState()
    {
        // ó�� �޼��� â ������ �� �޼��� Ÿ�̸Ӱ� ���ư��� ������ Ȯ��
        if (GameManager.instance.IsMessage()) // ���� ���� �ִٸ�?
        {
            // �޼��� Ÿ�̸Ӱ� ���ư��� ������ �Ѿ��� �� ������ ��
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].gameObject.SetActive(true);
            }
            timerPanel.SetActive(true);
        }
        else
        {
            // �޼��� Ÿ�̸Ӱ� ���ư��� ������ �Ѿ��� �� ������ ��
            for (int i = 1; i < buttons.Length; i++)
            {
                buttons[i].gameObject.SetActive(false);
            }
            timerPanel.SetActive(false);
        }
                Chatting();
    }

    public void GetBonus()
    {
        // ���� ����
        GameManager.instance.PlusCoin(100);
        for (int i = 1; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        timerPanel.SetActive(false);
        lastButton.interactable = true;
    }

    public void StartTimer()
    {
        // Ÿ�̸� ����
        lastButton.interactable = false;
        timerPanel.SetActive(true);
    }

    private void Chatting()
    {
        RandomNum1 = Random.Range(0, 40);
        chat1.text = string.Format(messages_1[RandomNum1]);
        RandomNum2 = Random.Range(0, 5);
        chat2.text = string.Format(messages_2[RandomNum2]);
        RandomNum3 = Random.Range(0, 36);
        chat3.text = string.Format(messages_3[RandomNum3]);
        RandomNum4 = Random.Range(0, 5);
        chat4.text = string.Format(messages_4[RandomNum4]);
        chat5.text = string.Format(messages_5[RandomNum2]);
        RandomNum5 = Random.Range(0, 8);
        chat6.text = string.Format(messages_6[RandomNum5]);


        //if(n==1)
        //{
        //    RandomNum1 = Random.Range(0, 40);
        //    chat1.text = string.Format(messages_1[RandomNum1]);
        //}
        //else if(n==2)
        //{
        //    RandomNum2 = Random.Range(0, 5);
        //    chat2.text = string.Format(messages_2[RandomNum2]);
        //}
        //{
        //    RandomNum3 = Random.Range(0, 36);
        //    chat3.text = string.Format(messages_3[RandomNum3]);
        //}
        //else if(n==4)
        //{
        //    RandomNum4 = Random.Range(0, 5);
        //    chat4.text = string.Format(messages_4[RandomNum4]);
        //}
        //else if(n==5)
        //{
        //    chat5.text = string.Format(messages_5[RandomNum2]);
        //}
        //else if(n==6)
        //{
        //    RandomNum5 = Random.Range(0, 8);
        //    chat6.text = string.Format(messages_6[RandomNum5]);
        //}
    }

}


