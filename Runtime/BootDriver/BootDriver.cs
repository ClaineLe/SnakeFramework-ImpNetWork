using UnityEngine;

namespace com.snake.framework
{
    namespace runtime
    {
        public class BootDriver : MonoBehaviour
        {
            public const string CUSTOM_NAMESPACE = "com.snake.framework.custom.runtime";
            public string CustomAppFacadeClassName = "AppFacadeCostom";
            public IAppFacadeCostom mAppFacadeCostom { get; private set; }
            private void Awake()
            {
                mAppFacadeCostom = _CreateCostomAppFacade();
            }

            private void Start()
            {
                Singleton<AppFacade>.GetInstance().StartUp(this);
            }

            private IAppFacadeCostom _CreateCostomAppFacade() 
            {
                System.Type type = default;
                var s_Assemblies = Utility.Assembly.GetAssemblies();
                foreach (var a in s_Assemblies)
                {
                    if (a.FullName.StartsWith(CUSTOM_NAMESPACE))
                    {
                        type = a.GetType(CUSTOM_NAMESPACE + "." + CustomAppFacadeClassName);
                    }
                }

                if (type == null)
                    throw new System.Exception("û���ҵ�Ӧ���Ż����Զ���ʵ������(IAppFacadeCostom)��");

                object appFacadeCostomObj = System.Activator.CreateInstance(type);
                if (appFacadeCostomObj == null)
                    throw new System.Exception("û���ҵ�Ӧ���Ż����Զ���ʵ�ֶ���(IAppFacadeCostom)��");
                return appFacadeCostomObj as IAppFacadeCostom;
            }
        }
    }
}