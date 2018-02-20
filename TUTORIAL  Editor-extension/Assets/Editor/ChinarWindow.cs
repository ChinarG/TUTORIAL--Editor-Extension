using UnityEditor; //引用Unity编辑器命名空间
using UnityEngine; //引用Unity引擎命名空间


/// <summary>
/// 创建一个窗口类
/// </summary>
public class ChinarWindow : EditorWindow //继承自 EditorWindow
{
    string      CustomName = "CustomName"; //自定义名字
    private int ChinarNum  = 0;            //空物体数量


    /// <summary>
    /// 创建一个菜单项
    /// </summary>
    [MenuItem("我的工具/显示新窗口")]
    static void 显示新窗口()
    {
        ChinarWindow chinar = GetWindow<ChinarWindow>(false, "Chinar窗口"); //获取到一个窗口，赋值给当前编辑器类的对象
        chinar.Show();                                                    //显示对象的窗口
    }


    /// <summary>
    /// 此函数中实现编辑器界面的定义/绘制
    /// </summary>
    void OnGUI()
    {
        GUILayout.Label("这是Chianr窗口");                                     //标题
        CustomName = GUILayout.TextField(CustomName);                      //文本框
        ChinarNum  = int.Parse(GUILayout.TextField(ChinarNum.ToString())); //数字框

        //可以直接判断按钮的点击
        if (GUILayout.Button("修改所有物体名字"))
        {
            for (int i = 0; i < Selection.transforms.Length; i++) //遍历选中的元素
            {
                Undo.RecordObjects(Selection.gameObjects as GameObject[], "ChinarWindow_GameObject[]"); //Selection.gameObjects 返回一个GameObject[] ,并记录键（用于回退）
                Selection.transforms[i].SetSiblingIndex(i);                                             //为选择的物体设置下标
                Selection.transforms[i].name = CustomName + i;                                          //设置名字+i
            }
        }

        //判断按钮的点击
        if (GUILayout.Button("创建多个空物体"))
        {
            if (ChinarNum <= 0) //如果数字 小于等于 0
            {
                ShowNotification(new GUIContent("请写入创建空物体数量")); //提示 输入
            }
            else //不为0
            {
                for (int i = 0; i < ChinarNum; i++) //遍历个数
                {
                    Undo.RegisterCreatedObjectUndo(new GameObject(CustomName), "Chinar Create gameobject"); //创建一个名为 CustomName 的空物体
                }
            }
        }
    }
}