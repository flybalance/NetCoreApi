using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Common.Utils
{
    public class SingletonUtil<T> where T : new()
    {
        /// <summary>
        /// 延迟加载
        /// </summary>
        private static Lazy<T> instance;

        private static readonly object sync = new object();

        private SingletonUtil()
        {
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        public static T GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (sync)
                    {
                        if (instance == null)
                        {
                            instance = new Lazy<T>();
                        }
                    }
                }

                return instance.Value;
            }
        }
    }
}
