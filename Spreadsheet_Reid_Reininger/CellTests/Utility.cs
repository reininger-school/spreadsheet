namespace CellTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    /// <summary>
    /// Functions used across testing suites.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Returns PropertyInfo of given type and property.
        /// </summary>
        /// <typeparam name="T">Class containing property to get.</typeparam>
        /// <param name="property">Property to be retrieved.</param>
        /// <returns>Property info.</returns>
        public static PropertyInfo GetProperty<T>(string property)
        {
            if (string.IsNullOrWhiteSpace(property))
            {
                Assert.Fail("Property cannot be null or whitespace");
            }

            var propertyInfo = typeof(T).GetProperty(property, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            if (propertyInfo == null)
            {
                Assert.Fail($"Could not find property {property}");
            }

            return propertyInfo;
        }

        /// <summary>
        /// Return MethodInfo for given method.
        /// </summary>
        /// <typeparam name="T">Class containg method.</typeparam>
        /// <param name="method">Name of method to get MethodInfo for.</param>
        /// <returns>MethodInfo of method in class T.</returns>
        public static MethodInfo GetMethod<T>(string method)
        {
            if (string.IsNullOrWhiteSpace(method))
            {
                Assert.Fail("Method cannot be null or whitespace");
            }

            var methodInfo = typeof(T).GetMethod(method, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            if (methodInfo == null)
            {
                Assert.Fail($"Could not find method {method}");
            }

            return methodInfo;
        }
    }
}
