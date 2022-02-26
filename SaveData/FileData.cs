using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FileData
{
    public class AbnormalTable // 디버프
    {
        public int AbnormalID { get; set; } // 상태이상 ID
        public string Name { get; set; }
        public int AbnormalType { get; set; } // 상태이상 타입 1. 행동금지 2. 도트 데미지
        public int AbnormalFlag { get; set; }
        public int AbnormalTime { get; set; } // 유지 시간(sec)
        public int AbnormalDotTime { get; set; }
        public float Value1 { get; set; } // 틱당 데미지
        public float Value2 { get; set; } // 틱 간격(0.1 sec)
        public float Value3 { get; set; } // 사용 안함
    }

    public class GameRuleTable // 전투 모드 규칙
    {
        public int GameRuleID { get; set; } // 게임 규칙 ID 0 : 개인전 1 : 팀전 2 : 배틀로얄 3 : 훈련장
        public int GameRuleTeamType { get; set; } // 팀 타입 0. 1팀 1. 2팀
        public int GameRuleDeadType { get; set; } // 사망 시 부활 타입 0. 부활 가능(개인전, 팀전) 1. 데스매치(배틀로얄)
        public int MinCountPerTeam { get; set; } // 시작 가능 최소 인원
        public int StartMinTime { get; set; } // 인원 만족 시 시작 대기 시간(sec) 0. 적용 안됨(무한 대기) 1~ 시작 대기 시간
        public int MaxCountPerTeam { get; set; } // 팀별 최대 인원
        public int MapID { get; set; } // 지도 아이디
        public int Play_Time { get; set; } // 전투 시간(sec)
        public int GameRuleMatchingType { get; set; } // 매칭 타입 0. 개인전 1. 팀전(양팀으로 분류)
        public int ArrowID1 { get; set; }
        public int ArrowID2 { get; set; }
        public int ArrowID3 { get; set; }
        public int ArrowID4 { get; set; }
        public int ArrowID5 { get; set; }
    }

    public class ItemTable // 아이템
    {
        public int ItemID { get; set; } // 아이템 ID
        public string Name { get; set; } // 이름
        public int ItemType { get; set; } // 아이템 타입 1. 활 2. 화살 3. 소모품
        public int ItemSubType { get; set; }
        // 아이템 보조타입 
        // ItemType(1) = 1. 활 2. 석궁
        // ItemType(2) = 1. 기본 화살 2. 폭탄 화살 3. 얼음 화살 4. 불화살 5. 강철 화살
        // ItemType(3) = 1. 체력회복 2. 상태이상 해제
        public float Value1 { get; set; }
        // ItemType(1) = 무기 데미지(%)
        // ItemType(2) = 화살 데미지
        // ItemType(3) = 1. 체력 회복량(즉시) 2. 상태이상 해제
        public float Value2 { get; set; }
        // ItemType(1) = 1. 사용 안함(0) 2. 재장전 시간
        // ItemType(2) = 1. 사용 안함(0) 2. 스킬 ID(폭발) 3. 스킬 ID(빙결) 4. 스킬 ID(화염) 5. 사용 안함(0)
        // ItemType(3) = 1. 사용 안함 2. 사용 안함
        public float Value3 { get; set; }
        // ItemType(1) = 정확도(범위)
        // ItemType(2) = 1. 사용 안함(0) 2. 터지는 시간 3. 사용 안함(0) 4. 사용 안함(0) 5. 사용 안함(0)
        // ItemType(3) = 1. 사용 안함(0) 2. 사용 안함(0)
    }

    public class ArrowTable // 화살
    {
        public int ArrowID { get; set; }
        public string Name { get; set; }
        public float Damage { get; set; } // 피해량
        public int AbnormalID { get; set; }  // 상태이상 ID
        public int Range { get; set; } // 범위
    }

    public class NPCTable // NPC(훈련장용)
    {
        public int NPCID { get; set; } // NPC 아이디
        public float MaxHP { get; set; } // 체력
        public string NPCPath { get; set; } // 리소스
    }

    public class NPCPosTable // NPC 생성 위치(훈련장용)
    {
        public int GameRuleID { get; set; } // 게임 규칙 ID
        public int NPCID { get; set; } // NPC 아이디
        public float Position_x { get; set; }
        public float Position_y { get; set; }
        public float Position_z { get; set; }
        public float Rotation_x { get; set; }
        public float Rotation_y { get; set; }
        public float Rotation_z { get; set; }
    }

    public class SpawnGroupTable // 아이템 생성 그룹
    {
        public int GameRuleID { get; set; } // 게임 규칙 ID
        public int SpawnGroupID { get; set; } // 소환 그룹 ID
        public string Name { get; set; }
        public int SpawnType { get; set; } // 아이템 소환 타입
        public int SpawnCount { get; set; } // 아이템 소환 개수
    }

    public class SpawnGroupItemTable // 생성 아이템 그룹
    {
        public int GameRuleID { get; set; } // 게임 규칙 ID
        public int SpawnGroupID { get; set; } // 소환 그룹 ID
        public string Name { get; set; }
        public int ItemID { get; set; } // 소환 아이템 ID
        public int Count { get; set; } // 소환 아이템 개수
    }

    public class SpawnGroupPositionTable // 아이템 소환 위치
    {
        public int GameRuleID { get; set; } // 게임 규칙 ID
        public int SpawnGroupID { get; set; } // 소환 그룹 ID
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class StartPositionTable // 캐릭터 시작 위치
    {
        public int GameRuleID { get; set; } // 게임 규칙 ID
        public int PositionType { get; set; } // 위치 타입 1. 시작 위치 2. 부활 위치
        public int positionindex { get; set; } // 위치 아이디
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }

}