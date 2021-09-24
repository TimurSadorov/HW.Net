.assembly Homework2.IL
{
  .ver 4:0:0:0
}

.class public abstract auto ansi beforefieldinit Homework2.IL.Parser
extends [CORE_ASSEMBLY]System.Object
{
    .field private static initonly string[] SupportedOperations
    
    .method private hidebysig static specialname rtspecialname void
    .cctor() cil managed
    {
        .maxstack 4
        ldc.i4.5
        newarr       [System.Runtime]System.String
        dup
        ldc.i4.0
        ldstr "+"
        stelem.ref
        dup
        ldc.i4.1
        ldstr "-"
        stelem.ref
        dup
        ldc.i4.2
        ldstr "*"
        stelem.ref
        dup
        ldc.i4.3
        ldstr "/"
        stelem.ref
        dup
        ldc.i4.4
        ldstr ":"
        stelem.ref
        stsfld string[] Homework2.IL.Parser::SupportedOperations
        ret
    }
    .method public hidebysig specialname rtspecialname instance void
    .ctor() cil managed
  {
    .maxstack 8

    ldarg.0   
    call instance void [System.Runtime]System.Object::.ctor()
    ret

  }
    
    .method public static int32 TryParseArguments(
    string[] args, [out] int32& val1, [out] string& operation, [out] int32& val2)
    cil managed
    {
        .maxstack 8
         ldarg.2
         ldarg.0
         ldc.i4.1
         ldelem.ref
         stind.ref
    
        ldarg.0
        ldc.i4.0
        ldelem.ref
        ldarg.1
        call  bool [System.Runtime]System.Int32::TryParse(string, int32&)
        brfalse InvalidValues
        
        ldarg.0
        ldc.i4.2
        ldelem.ref
        ldarg.3
        call  bool [System.Runtime]System.Int32::TryParse(string, int32&)
        brfalse InvalidValues
        
        ldsfld  string[] Homework2.IL.Parser::SupportedOperations
        ldarg.2
        ldind.ref
        call bool [System.Linq]System.Linq.Enumerable::Contains<string>(class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!0>, !!0)
        brfalse InvalidOperation
        ldc.i4.0
        ret
        
        InvalidValues:
        ldc.i4.1
        br.s InvalidSyntax
        
        InvalidOperation:
        ldc.i4.2
        br.s InvalidSyntax
        
        InvalidSyntax:
        ldstr "{0}{1}{2} is not a valid calculate syntax"
        
        ldarg.0
        ldc.i4.0
        ldelem.ref
        
        ldarg.0
        ldc.i4.1
        ldelem.ref
        
        ldarg.0
        ldc.i4.2
        ldelem.ref
        
        call void [System.Console]System.Console::WriteLine(string, object, object, object)
        ret
    }
}