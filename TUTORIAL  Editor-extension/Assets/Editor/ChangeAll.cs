using UnityEditor; //引用Unity编辑器命名空间
using UnityEngine; //引用Unity引擎命名空间


/// <summary>
/// 改变所有敌人脚本
/// </summary>
public class ChangeAll : ScriptableWizard
{
    public int AddHp = 10; //每次增加血量值
    public int Num   = 0;  //一个数字为了测试 isValue


    /// <summary>
    /// 菜单栏 我的工具 中，创建一个按钮
    /// </summary>
    [MenuItem("我的工具/修改所有敌人属性")]
    static void 修改所有敌人属性()
    {
        //显示器向导 <所管控的类>（ 窗口的名字，窗口中按钮的名字,第二个按钮的名字 ）；
        DisplayWizard<ChangeAll>("修改所有敌人血量", "确认修改血量", "第二个按钮");
    }


    /// <summary>
    /// 固定函数名:窗口开始时执行
    /// </summary>
    void OnEnable()
    {
        AddHp = EditorPrefs.GetInt("ChangeAll_health", AddHp); //取值，默认为初始值   并赋值给AddHp
    }


    /// <summary>
    /// 固定函数名：对应现实向导中的第一个按钮 —— 确认修改血量
    /// </summary>
    void OnWizardCreate()
    {
        EditorUtility.DisplayProgressBar("修改进度", "0/" + Selection.gameObjects.Length + "完成修改", 1); //进度条
        int count = 0;                                                                             //计数
        foreach (var gameObject in Selection.gameObjects)                                          //遍历选中的物体
        {
            CompleteProject.EnemyHealth health = gameObject.GetComponent<CompleteProject.EnemyHealth>();                                         //获取其身上脚本组件
            Undo.RecordObject(health, "Change health");                                                                                          //记录变量 health 之后做的更改
            health.startingHealth += AddHp;                                                                                                      //自增 设置的值   //需要修改其他属性，自己往下写
            count++;                                                                                                                             //计数自增1
            EditorUtility.DisplayProgressBar("修改进度", count + "/" + Selection.gameObjects.Length + "完成修改", count / Selection.gameObjects.Length); //进度条
        }

        EditorUtility.ClearProgressBar(); //清除进度条(只有调用此方法，进度条才会删除)
    }


    /// <summary>
    /// 固定函数名：对应现实向导中的第二按钮 —— 第二个按钮
    /// </summary>
    void OnWizardOtherButton()
    {
        //弹出通知(新建一个 GUI内容组件（被选中物体的个数）+“字符” )
        ShowNotification(new GUIContent(Selection.gameObjects.Length + "个元素被选中"));
    }


    /// <summary>
    /// 当属性值被修改时，每帧调用。 /  当界面开启时，会调用一次
    /// </summary>
    void OnWizardUpdate()
    {
        helpString  = null; //每次调用就归零一次，否则会出现字体不消除的情况
        errorString = null;

        if (Selection.gameObjects.Length > 0)
        {
            helpString = "当前选择了" + Selection.gameObjects.Length + "个敌人"; //及时更新选择的数量
        }
        else
        {
            errorString = "最少选择一个啊"; //错误提示
        }

        EditorPrefs.SetInt("ChangeAll_health", AddHp); //修改后存入一个值，就是记录一下。
    }


    /// <summary>
    /// 当选择发生改变，调用此函数
    /// </summary>
    void OnSelectionChange()
    {
        OnWizardUpdate();
    }
}