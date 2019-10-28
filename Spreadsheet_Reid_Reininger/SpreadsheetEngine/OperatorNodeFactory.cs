// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Cpts321;

    /// <summary>
    /// Creates OperatorNode instances.
    /// </summary>
    internal class OperatorNodeFactory
    {
        /// <summary>
        /// Dictionary of operator-type pairs.
        /// </summary>
        private Dictionary<string, Type> operators = new Dictionary<string, Type>();

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNodeFactory"/> class.
        /// </summary>
        internal OperatorNodeFactory()
        {
            this.TraverseAvailableOperators((op, type) => this.operators.Add(op, type));
        }

        private delegate void OnOperator(string op, Type type);

        /// <summary>
        /// Gets list of operator symbols.
        /// </summary>
        internal Dictionary<string, Type>.KeyCollection Operators
        {
            get => this.operators.Keys;
        }

        /// <summary>
        /// Create new instance of OperatorNode.
        /// </summary>
        /// <param name="op">Op string.</param>
        /// <returns>New instance of desired operator node.</returns>
        internal OperatorNode CreateOperatorNode(string op)
        {
            var constructorInfo = this.operators[op].GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static, null, new Type[] { }, null);
            return (OperatorNode)constructorInfo.Invoke(new object[] { });
        }

        private void TraverseAvailableOperators(OnOperator onOperator)
        {
            // get the type declaration of OperatorNode
            Type operatorNodeType = typeof(OperatorNode);

            // Iterate over all loaded assemblies
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                // Get all types that inherit from OperatorNode class
                IEnumerable<Type> operatorTypes =
                    assembly.GetTypes().Where(type => type.IsSubclassOf(operatorNodeType));

                // iterate over those subclasses of OperatorNode
                foreach (var type in operatorTypes)
                {
                    // for each subclass, retrieve the operator property
                    PropertyInfo operatorField = type.GetProperty("Operator", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
                    if (operatorField != null)
                    {
                        var constructorInfo = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static, null, new Type[] { }, null);
                        if (constructorInfo != null)
                        {
                            var mockInstance = constructorInfo.Invoke(new object[] { });

                            // get the string of the operator
                            object value = operatorField.GetValue(mockInstance);
                            if (value is string)
                            {
                                string operatorSymbol = (string)value;
                                onOperator(operatorSymbol, type);
                            }
                        }
                    }
                }
            }
        }
    }
}
