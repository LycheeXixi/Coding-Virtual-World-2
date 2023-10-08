using UnityEngine;
public class TransformHelper
{/// <summary>
 /// 在层级未知的情况下查找子物体
 /// </summary>
 /// <param name="parentTF">父物体变换组件</param>
 /// <param name="children">子物体名称</param>
    public static Transform GetChild(Transform parentTF, string childName)
    {
        //在子物体中查找
        Transform childTF = parentTF.Find(childName);
        if (childTF != null) return childTF;
        //将问题交给子物体
        for (int i = 0; i < parentTF.childCount; i++)
        {
            childTF = GetChild(parentTF.GetChild(i), childName);
            if (childTF != null) return childTF;
        }
        return null;

    }
}