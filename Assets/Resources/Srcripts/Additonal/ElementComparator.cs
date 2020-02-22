using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ElementComparator { 
   public static Element[,] effectiveTo={{Element.WATER,Element.FIRE}
    ,{ Element.FIRE,Element.WIND} };

    public static bool isEffactive(Element a,Element b)
    {
        for (int i = 0; i < effectiveTo.GetLength(0) ; i++)
        {
            if (a == effectiveTo[i,0] && b == effectiveTo[i,1]) return true;
        }
        return false;

    }
}
