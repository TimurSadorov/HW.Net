using System;
using System.Linq;

namespace Homework7
{
    public static class BuiltInTypes
    {
        public static readonly Type[] IntegerTypes =
        {
            typeof(int), typeof(long)
        };

        public static readonly Type[] RealTypes =
        {
            typeof(double), typeof(decimal)
        };
        
        public static readonly Type[] NullableIntegerTypes =
        {
            typeof(int?), typeof(long?)
        };
        
        public static readonly Type[] NullableRealTypes =
        {
            typeof(double?), typeof(decimal?)
        };

        public static readonly Type[] NullableNumericTypes = NullableIntegerTypes
            .Concat(NullableRealTypes).ToArray();
        
        public static readonly Type[] NumericTypes = IntegerTypes
            .Concat(RealTypes).ToArray();
        
        public static readonly Type[] AllNumericTypes = NumericTypes
            .Concat(NullableNumericTypes).ToArray();
    }
}