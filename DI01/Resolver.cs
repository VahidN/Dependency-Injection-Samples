using System;
using System.Collections.Generic;
using System.Linq;

namespace DI01
{
    public class Resolver
    {
        //كار ذخيره سازي و نگاشت از يك نوع به نوعي ديگر در اينجا توسط اين ديكشنري انجام خواهد شد
        private readonly Dictionary<Type, Type> _dependencyMap = new Dictionary<Type, Type>();

        /// <summary>
        /// يك نوع خاص از آن درخواست شده و سپس بر اساس تنظيمات برنامه كار وهله سازي
        /// نمونه معادل آن صورت خواهد گرفت
        /// </summary>
        public T Resolve<T>()
        {
            return (T)resolve(typeof(T));
        }

        private object resolve(Type typeToResolve)
        {
            Type resolvedType;

            // ابتدا بررسي مي‌شود كه آيا در تنظيمات برنامه نگاشت متناظري براي نوع درخواستي وجود دارد؟
            if (!_dependencyMap.TryGetValue(typeToResolve, out resolvedType))
            {
                //اگر خير، كار متوقف خواهد شد
                throw new Exception(string.Format("Could not resolve type {0}", typeToResolve.FullName));
            }

            var firstConstructor = resolvedType.GetConstructors().First();
            var constructorParameters = firstConstructor.GetParameters();
            // در ادامه اگر اين نوع، داراي سازنده‌ي بدون پارامتري است
            // بلافاصله وهله سازي خواهد شد
            if (!constructorParameters.Any())
                return Activator.CreateInstance(resolvedType);


            var parameters = new List<object>();
            foreach (var parameterToResolve in constructorParameters)
            {
                // در اينجا يك فراخواني بازگشتي صورت گرفته است براي وهله سازي
                // خودكار پارامترهاي مختلف سازنده يك كلاس
                parameters.Add(resolve(parameterToResolve.ParameterType));
            }
            return firstConstructor.Invoke(parameters.ToArray());
        }

        public void Register<TFrom, TTo>()
        {
            _dependencyMap.Add(typeof(TFrom), typeof(TTo));
        }
    }
}