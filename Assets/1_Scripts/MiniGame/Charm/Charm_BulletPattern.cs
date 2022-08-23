using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charm_BulletPattern : MonoBehaviour
{
    //�߻�� �Ѿ� ������Ʈ
    public GameObject bullet;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shot();
        }
    }

    void shot()
    {
        //360�� �ݺ�
        for (int i = 0; i < 360; i += 13)
        {
            //�Ѿ� ����
            GameObject temp = Instantiate(bullet);

            //2�ʸ��� ����
            Destroy(temp, 2f);

            //�Ѿ� ���� ��ġ�� (0,0) ��ǥ�� �Ѵ�.
            temp.transform.position = Vector2.zero;

            //Z�� ���� ���ؾ� ȸ���� �̷�����Ƿ�, Z�� i�� �����Ѵ�.
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }
}
