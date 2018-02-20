using UnityEditor; //引用Unity编辑器命名空间
using UnityEngine; //引用Unity引擎命名空间


/// <summary>
/// 玩家脚本上的工具 —— 测试脚本
/// </summary>
public class PlayerTools
{
    /// <summary>
    /// 给玩家脚本组件上添加按钮：初始化人物
    /// </summary>
    /// //[菜单项函数(“环境(组件：想要给组件上加必须要用这个来表示路径)/所需控制组件（脚本名）/需要执行的方法名（就是按钮名）”)]
    [MenuItem("CONTEXT/PlayerHealth/初始化人物")]
    static void 初始化人物(MenuCommand command) //MenuCommand 正在操作的组件对象类
    {
        CompleteProject.PlayerHealth player = (CompleteProject.PlayerHealth) command.context; //声明一个PlayerHealt对象 th  —— 正在操作的组件，需要强转为 PlayerHealth类型
        Undo.RecordObject(player, "PlayerTools_player");                                      //记录对象 player 之后的数据变化,用于回退 —— 记录对象（对象，键）；//键的名字随意，不能重复
        player.startingHealth = 100;                                                          //血量初始化到100
    }


    /// <summary>
    /// 给系统组件 Rigidbody 上添加按钮：取消重力
    /// </summary>
    /// <param name="command"></param>
    [MenuItem("CONTEXT/Rigidbody/取消重力")]
    static void 取消重力(MenuCommand command)
    {
        Rigidbody rig = (Rigidbody) command.context; //context是一个 (正操作/鼠标下) 的组件：返回值为Object —— 强转为需要的类型
        Undo.RecordObject(rig, "PlayerTools_rig");   //记录 rig 之后的数据变化，用于回退 —— 记录对象（对象，键）；//键的名字随意，不能重复//没有这句话，是不能回退，因为系统没记录
        rig.mass       = 0;                          //质量为0
        rig.useGravity = false;                      //关闭重力
    }
}