using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Util
{
    // ����
    public static int IncreaseValue(int n)
    {
        if (n == 0)
        {
            return 0;
        }
        else if (n == 1)
        {
            return 1;
        }
        return IncreaseValue(n - 1) + IncreaseValue(n - 2);
    }
}
