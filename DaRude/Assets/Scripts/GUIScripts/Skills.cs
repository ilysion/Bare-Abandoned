using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{
    public Text CraftingLevelText;
    public Text CraftingExpText;
    public Text AgilityLevelText;
    public Text AgilityExpText;
    public Text AccuracyLevelText;
    public Text AccuracyExpText;
    public Text GatheringLevelText;
    public Text GatheringExpText;
    public Text MetabolismLevelText;
    public Text MetabolismExpText;
    private int CraftingLevel;
    private int CraftingExp;
    private int AgilityLevel;
    private int AgilityExp;
    private int AccuracyLevel;
    private int AccuracyExp;
    private int GatheringLevel;
    private int GatheringExp;
    private int MetabolismLevel;
    private int MetabolismExp;

    private int MaxLevel;
    // Use this for initialization
    void Start ()
    {
        MaxLevel = 9;
        setCraftingLevel(0);
        setCraftingExp(0);
        setAgilityLevel(0);
        setAgilityExp(0);
        setAccuracyLevel(0);
        setAccuracyExp(0);
        setGatheringLevel(0);
        setGatheringExp(0);
        setMetabolismLevel(0);
        setMetabolismExp(0);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private int NextLevelExp(int level)
    {
        //TODO: create a better formula
        if (level == -1) return 25;
        else return (int)Mathf.Pow(level, 3) * 25 + 25;
        /*
        if (level == 1) return 25;
        if (level == 2) return 100;
        if (level == 3) return 250;
        if (level == 4) return 1000;
        if (level == 5) return 2000;
        if (level == 6) return 5000;
        if (level == 7) return 10000;
        if (level == 8) return 50000;
        */
    }

    private bool isMaxed(int level)
    {
        if (level == MaxLevel) return true;
        else return false;
    }

    public int getCraftingLevel()
    {
        return CraftingLevel;
    }
    public void setCraftingLevel(int level)
    {
        CraftingLevel = level;
        CraftingLevelText.text = CraftingLevel.ToString();
    }
    public int getCraftingExp()
    {
        return CraftingExp;
    }
    public void setCraftingExp(int exp)
    {
        CraftingExp = exp;
        if(CraftingExp >= NextLevelExp(CraftingLevel))
        {
            setCraftingLevel(CraftingLevel + 1);
        }
        CraftingExpText.text = CraftingExp + "/" + NextLevelExp(CraftingLevel);
    }

    public int getAgilityLevel()
    {
        return AgilityLevel;
    }
    public void setAgilityLevel(int level)
    {
        AgilityLevel = level;
        AgilityLevelText.text = AgilityLevel.ToString();
    }
    public int getAgilityExp()
    {
        return AgilityExp;
    }
    public void setAgilityExp(int exp)
    {
        AgilityExp = exp;
        if (AgilityExp >= NextLevelExp(AgilityLevel))
        {
            setAgilityLevel(AgilityLevel + 1);
        }
        AgilityExpText.text = AgilityExp + "/" + NextLevelExp(AgilityLevel);
    }

    public int getAccuracyLevel()
    {
        return AccuracyLevel;
    }
    public void setAccuracyLevel(int level)
    {
        AccuracyLevel = level;
        AccuracyLevelText.text = AccuracyLevel.ToString();
    }
    public int getAccuracyExp()
    {
        return AccuracyExp;
    }
    public void setAccuracyExp(int exp)
    {
        AccuracyExp = exp;
        if (AccuracyExp >= NextLevelExp(AccuracyLevel))
        {
            setAccuracyLevel(AccuracyLevel + 1);
        }
        AccuracyExpText.text = AccuracyExp + "/" + NextLevelExp(AccuracyLevel);
    }

    public int getGatheringLevel()
    {
        return GatheringLevel;
    }
    public void setGatheringLevel(int level)
    {
        GatheringLevel = level;
        GatheringLevelText.text = GatheringLevel.ToString();
    }
    public int getGatheringExp()
    {
        return GatheringExp;
    }
    public void setGatheringExp(int exp)
    {
        GatheringExp = exp;
        if (GatheringExp >= NextLevelExp(GatheringLevel))
        {
            setGatheringLevel(GatheringLevel + 1);
        }
        GatheringExpText.text = GatheringExp + "/" + NextLevelExp(GatheringLevel);
    }

    public int getMetabolismLevel()
    {
        return MetabolismLevel;
    }
    public void setMetabolismLevel(int level)
    {
        MetabolismLevel = level;
        MetabolismLevelText.text = MetabolismLevel.ToString();
    }
    public int getMetabolismExp()
    {
        return MetabolismExp;
    }
    public void setMetabolismExp(int exp)
    {
        MetabolismExp = exp;
        if (MetabolismExp >= NextLevelExp(MetabolismLevel))
        {
            setMetabolismLevel(MetabolismLevel + 1);
            MetabolismExpText.text = MetabolismExp - NextLevelExp(MetabolismLevel-1) + "/" + NextLevelExp(MetabolismLevel);
        }
        MetabolismExpText.text = MetabolismExp + "/" + NextLevelExp(MetabolismLevel);
    }
}
