using System.Collections;

public class MinMaxManager
{
    public int count;
    public int maxcount;

    public int GetCount() { return count; }
    public void SetCount(int value) { count = value; }
    public int GetMaxCount() { return maxcount; }
    public void SetMaxCount(int value)
    {
        maxcount = value;
        if (count > maxcount)
            count = maxcount;
    }

    public MinMaxManager()
    {
        count = 0;
        maxcount = 0;
    }

    public bool addMaxCount(int addValue = 1)
    {
        maxcount += addValue;
        return true;
    }

    public bool subMaxCount(int subValue = 1)
    {
        if (maxcount - subValue >= 0)
            maxcount -= subValue;
        else
            maxcount = 0;
        return true;
    }

    public bool addCount(int addValue = 1)
    {
        if (maxcount >= count + addValue)
        {
            count += addValue;
        }
        else
            count = maxcount;
        return true;
    }

    public bool subCount(int subValue = 1)
    {
        if (0 <= count - subValue)
        {
            count -= subValue;
        }
        else
            count = 0;
        return true;

    }

    public string toString()
    {
        return count.ToString() + "/" + maxcount.ToString();
    }

}
