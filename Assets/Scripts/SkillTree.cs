using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    //Tutorial: https://www.youtube.com/watch?v=fE0R6WLpmrE
    public static SkillTree skillTree;
    private void Awake() => skillTree = this;

    public int[] SkillLevels;
    public int[] SkillCaps;
    public string[] SkillNames;
    public string[] SkillDescriptions;

    public List<Skill> SkillList;
    public GameObject SkillHolder;

    public List<GameObject> ConnectorList;
    public GameObject ConnectorHolder;

    public int SkillPoint;

    private void Start()
    {
        SkillPoint = 20;
        SkillLevels = new int[6];
        SkillCaps = new[] { 1, 5, 5, 2, 10, 10 };

        SkillNames = new[] { "Upgrade 1", "Upgrade 2", "Upgrade 3", "Upgrade 4", "Booster 5", "Booster 6" };

        SkillDescriptions = new[]
        {
            "Does a thing",
            "Does a cool thing",
            "Does a really cool thing",
            "Does an awesome thing",
            "Does this math thing",
            "Does this compounding thing",
        };

        foreach (var skill in SkillHolder.GetComponentsInChildren<Skill>())SkillList.Add(skill);
        foreach (var connector in ConnectorHolder.GetComponentsInChildren<RectTransform>()) ConnectorList.Add(connector.gameObject);
        
        for (var i = 0; i < SkillList.Count; i++) SkillList[i].id = i *1;
        
        SkillList[0].ConnectedSkills = new[] { 1, 2};
        SkillList[1].ConnectedSkills = new[] { 4 };
        SkillList[2].ConnectedSkills = new[] { 3 };
        SkillList[3].ConnectedSkills = new[] { 5 };
        SkillList[4].ConnectedSkills = new[] { 5 };
        UpdateAllSkillUI();
    }
    public void UpdateAllSkillUI()
    {
        foreach(var skill in SkillList) skill.UpdateUI();

    }
}
