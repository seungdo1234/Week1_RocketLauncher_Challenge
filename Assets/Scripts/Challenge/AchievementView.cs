using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementView : MonoBehaviour
{
    [SerializeField] private GameObject achievementSlotPrefab;  // 업적 슬롯 프리팹
    private Dictionary<int, AchievementSlot> achievementSlots = new();

    public void CreateAchievementSlots(AchievementSO[] achievements)
    {
        for (int i = 0; i < achievements.Length; i++)
        {
            AchievementSlot slot = Instantiate(achievementSlotPrefab, transform).GetComponent<AchievementSlot>();
            slot.Init(achievements[i]);
            achievementSlots[i] = slot;
        }
    }

    public void UnlockAchievement(int currentAchieveLevel)
    {
        // UI 반영 로직
        achievementSlots[currentAchieveLevel].MarkAsChecked();
    }
}