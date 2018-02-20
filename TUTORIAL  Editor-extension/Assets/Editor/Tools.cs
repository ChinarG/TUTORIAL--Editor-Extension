using UnityEditor; //引用Unity编辑器命名空间
using UnityEngine; //引用Unity引擎命名空间


/// <summary>
/// 创建一个脚本工具类
/// </summary>
public class Tools : MonoBehaviour
{
    /// <summary>
    /// 创建新的菜单项
    /// </summary>
    [MenuItem("我的工具/一级选项")] //菜单项（“菜单栏名称/子类名称”）—— 经过测试可为中文
    static void Tessss()      //必须设置成静态方法 —— 经过测试，亦可为中文
    {
        Debug.Log(111);
    }


    /// <summary>
    /// 创建二级菜单项
    /// </summary>
    /// //在菜单栏中创建一个 我的工具 菜单项目，并生成一个 “二级选项” 的按钮：需要对应一个静态方法（名字需和按钮名保持一致），方法体自由定义
    [MenuItem("我的工具/一级选项/二级选项")] //菜单项（“菜单栏名称/子类名称”）—— 经过测试可为中文
    static void Tesssssss()           //必须设置成静态方法 —— 经过测试，亦可为中文
    {
        Debug.Log(222);
    }


    /// <summary>
    /// 在系统默认的菜单项中，创建子按钮
    /// </summary>
    /// //在系统默认菜单项 Edit 中创建按钮：方法名需要与按钮名保持一致
    [MenuItem("Edit/一级选项/二级选项2")]
    static void 二级选项2()
    {
        Debug.Log(333);
    }


    #region 菜单分组

    /// <summary>
    /// 菜单分组 —— 层级10
    /// </summary>
    /// //每个菜单栏的 priority 优先级默认为1000。相差 11 可以分为另一个组。也就是大于10就另建一组
    [MenuItem("按钮/功能1", false, 10)]
    static void 功能1()
    {
        Debug.Log("功能1");
    }


    /// <summary>
    /// 菜单分组 —— 层级：如果不填，系统默认为1000
    /// </summary>
    [MenuItem("按钮/功能2")]
    static void 功能2()
    {
        Debug.Log("功能2");
    }


    /// <summary>
    /// 菜单分组 —— 层级：21
    /// </summary>
    [MenuItem("按钮/功能3", false, 21)]
    static void 功能3()
    {
        Debug.Log("功能3");
    }

    #endregion


    /// <summary>
    /// 验证“删除物体”按钮的 显示/隐藏
    /// </summary>
    [MenuItem("GameObject/删除物体", true, -1)]
    static bool 删除物体Alternative()
    {
        if (Selection.objects.Length > 0) //如果选择了物体
        {
            return true; //就返回真：按钮可用
        }
        else //否则
        {
            return false; //返回假：按钮不可用
        }
    }


    /// <summary>
    /// 在系统默认的菜单项 GameObject 中，创建 删除物体 按钮，优先级第一个
    /// </summary>
    [MenuItem("GameObject/删除物体", false, -1)]
    static void 删除物体()
    {
        //Selection.objects 返回值是一个 Object数组，就是选中的所有物体
        foreach (var o in Selection.objects) //遍历选中的所有物体
        {
            //GameObject.DestroyImmediate(o);//直接删除，但是无法撤销
            Undo.DestroyObjectImmediate(o); //直接删除，但是可以撤销（用Ctrl+z）//Immediate：直接的，立即的
        }
    }


    /// <summary>
    /// 快捷键测试
    /// </summary>
    [MenuItem("我的工具/快捷键测试 _o")] //_o 是指定快捷键 O ，并不区分大小写 （名字和快捷键中间必须要有空格）
    static void 选中物体个数()
    {
        Debug.Log("快捷键" + Selection.objects.Length); //打印选中物体的个数
    }


    /// <summary>
    /// 在系统默认的菜单项中，创建子按钮
    /// </summary>
    /// % : Ctrl
    /// # : Shift
    /// & : Alt
    [MenuItem("我的工具/组合键测试 %l")] //%l 是指定组合键：Ctrl+L，并不区分大小写 （名字和快捷键中间必须要有空格）
    static void 快捷键测试()
    {
        Debug.Log("组合键" + Selection.activeGameObject.name); //打印物体名/—— 默认打印第一个选中的物体，无论选中了几个
    }
}