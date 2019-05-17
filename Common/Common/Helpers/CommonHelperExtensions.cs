using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scaffolding.Common.Helpers
{
    public static class CommonHelperExtensions
    {
        /// <summary>
        /// Creates an instance of type, invokes the given action on it and returns it.
        /// </summary>
        /// <typeparam name="T">The type of action argument. Must be a reference type and have
        /// a public default constructor.</typeparam>
        /// <param name="action">The action to invoke.</param>
        /// <returns>The created instance of <paramref name="T"/>.</returns>
        public static T CreateTargetAndInvoke<T>(this Action<T> action)
            where T : new()
        {
            T target = new T();

            action.Invoke(target);

            return target;
        }

        public static T CreateTargetAndInvoke<T, TImpl>(this Action<T> action)
            where TImpl : T, new()
        {
            T target = new TImpl();

            action.Invoke(target);

            return target;
        }

        public static TOutput CreateTargetAndInvoke<T, TInput, TOutput>(this Func<T, TOutput> func)
            where TInput : T, new()
        {
            T target = new TInput();

            return func.Invoke(target);
        }

        public static Type GetFirstGenericArgumentType(this Object obj)
        {
            return obj.GetType().GetGenericArguments().First();
        }

        public static Boolean IsNegative(this TimeSpan timeSpan)
        {
            return timeSpan.TotalMilliseconds < 0;
        }

        public static Boolean IsPositive(this TimeSpan timeSpan)
        {
            return timeSpan.TotalMilliseconds > 0;
        }

        public static T Build<T, TBuilder, TBuilderImpl>(this Action<TBuilder> builderAction)
            where TBuilder : class
            where TBuilderImpl : class, TBuilder, IBuilder<T>, new()
        {
            return builderAction.CreateTargetAndInvoke<TBuilderImpl>().Build();
        }

        public static T BuildEx<T, TBuilder, TBuilderImpl>(this Action<TBuilder> builderAction, IServiceProvider serviceProvider)
            where TBuilder : class
            where TBuilderImpl : class, TBuilder, IBuilderEx<T>, new()
        {
            return builderAction.CreateTargetAndInvoke<TBuilderImpl>().Build(serviceProvider);
        }

        public static byte[] Combine(this byte[] a, byte[] b)
        {
            byte[] result = new byte[a.Length + b.Length];
            System.Array.Copy(a, 0, result, 0, a.Length);
            System.Array.Copy(b, 0, result, a.Length, b.Length);

            return result;
        }
    }
}
