using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FileData
{
    public class AbnormalTable // �����
    {
        public int AbnormalID { get; set; } // �����̻� ID
        public string Name { get; set; }
        public int AbnormalType { get; set; } // �����̻� Ÿ�� 1. �ൿ���� 2. ��Ʈ ������
        public int AbnormalFlag { get; set; }
        public int AbnormalTime { get; set; } // ���� �ð�(sec)
        public int AbnormalDotTime { get; set; }
        public float Value1 { get; set; } // ƽ�� ������
        public float Value2 { get; set; } // ƽ ����(0.1 sec)
        public float Value3 { get; set; } // ��� ����
    }

    public class GameRuleTable // ���� ��� ��Ģ
    {
        public int GameRuleID { get; set; } // ���� ��Ģ ID 0 : ������ 1 : ���� 2 : ��Ʋ�ξ� 3 : �Ʒ���
        public int GameRuleTeamType { get; set; } // �� Ÿ�� 0. 1�� 1. 2��
        public int GameRuleDeadType { get; set; } // ��� �� ��Ȱ Ÿ�� 0. ��Ȱ ����(������, ����) 1. ������ġ(��Ʋ�ξ�)
        public int MinCountPerTeam { get; set; } // ���� ���� �ּ� �ο�
        public int StartMinTime { get; set; } // �ο� ���� �� ���� ��� �ð�(sec) 0. ���� �ȵ�(���� ���) 1~ ���� ��� �ð�
        public int MaxCountPerTeam { get; set; } // ���� �ִ� �ο�
        public int MapID { get; set; } // ���� ���̵�
        public int Play_Time { get; set; } // ���� �ð�(sec)
        public int GameRuleMatchingType { get; set; } // ��Ī Ÿ�� 0. ������ 1. ����(�������� �з�)
        public int ArrowID1 { get; set; }
        public int ArrowID2 { get; set; }
        public int ArrowID3 { get; set; }
        public int ArrowID4 { get; set; }
        public int ArrowID5 { get; set; }
    }

    public class ItemTable // ������
    {
        public int ItemID { get; set; } // ������ ID
        public string Name { get; set; } // �̸�
        public int ItemType { get; set; } // ������ Ÿ�� 1. Ȱ 2. ȭ�� 3. �Ҹ�ǰ
        public int ItemSubType { get; set; }
        // ������ ����Ÿ�� 
        // ItemType(1) = 1. Ȱ 2. ����
        // ItemType(2) = 1. �⺻ ȭ�� 2. ��ź ȭ�� 3. ���� ȭ�� 4. ��ȭ�� 5. ��ö ȭ��
        // ItemType(3) = 1. ü��ȸ�� 2. �����̻� ����
        public float Value1 { get; set; }
        // ItemType(1) = ���� ������(%)
        // ItemType(2) = ȭ�� ������
        // ItemType(3) = 1. ü�� ȸ����(���) 2. �����̻� ����
        public float Value2 { get; set; }
        // ItemType(1) = 1. ��� ����(0) 2. ������ �ð�
        // ItemType(2) = 1. ��� ����(0) 2. ��ų ID(����) 3. ��ų ID(����) 4. ��ų ID(ȭ��) 5. ��� ����(0)
        // ItemType(3) = 1. ��� ���� 2. ��� ����
        public float Value3 { get; set; }
        // ItemType(1) = ��Ȯ��(����)
        // ItemType(2) = 1. ��� ����(0) 2. ������ �ð� 3. ��� ����(0) 4. ��� ����(0) 5. ��� ����(0)
        // ItemType(3) = 1. ��� ����(0) 2. ��� ����(0)
    }

    public class ArrowTable // ȭ��
    {
        public int ArrowID { get; set; }
        public string Name { get; set; }
        public float Damage { get; set; } // ���ط�
        public int AbnormalID { get; set; }  // �����̻� ID
        public int Range { get; set; } // ����
    }

    public class NPCTable // NPC(�Ʒ����)
    {
        public int NPCID { get; set; } // NPC ���̵�
        public float MaxHP { get; set; } // ü��
        public string NPCPath { get; set; } // ���ҽ�
    }

    public class NPCPosTable // NPC ���� ��ġ(�Ʒ����)
    {
        public int GameRuleID { get; set; } // ���� ��Ģ ID
        public int NPCID { get; set; } // NPC ���̵�
        public float Position_x { get; set; }
        public float Position_y { get; set; }
        public float Position_z { get; set; }
        public float Rotation_x { get; set; }
        public float Rotation_y { get; set; }
        public float Rotation_z { get; set; }
    }

    public class SpawnGroupTable // ������ ���� �׷�
    {
        public int GameRuleID { get; set; } // ���� ��Ģ ID
        public int SpawnGroupID { get; set; } // ��ȯ �׷� ID
        public string Name { get; set; }
        public int SpawnType { get; set; } // ������ ��ȯ Ÿ��
        public int SpawnCount { get; set; } // ������ ��ȯ ����
    }

    public class SpawnGroupItemTable // ���� ������ �׷�
    {
        public int GameRuleID { get; set; } // ���� ��Ģ ID
        public int SpawnGroupID { get; set; } // ��ȯ �׷� ID
        public string Name { get; set; }
        public int ItemID { get; set; } // ��ȯ ������ ID
        public int Count { get; set; } // ��ȯ ������ ����
    }

    public class SpawnGroupPositionTable // ������ ��ȯ ��ġ
    {
        public int GameRuleID { get; set; } // ���� ��Ģ ID
        public int SpawnGroupID { get; set; } // ��ȯ �׷� ID
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class StartPositionTable // ĳ���� ���� ��ġ
    {
        public int GameRuleID { get; set; } // ���� ��Ģ ID
        public int PositionType { get; set; } // ��ġ Ÿ�� 1. ���� ��ġ 2. ��Ȱ ��ġ
        public int positionindex { get; set; } // ��ġ ���̵�
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }

}