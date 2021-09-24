.assembly Homework2.IL
{
  .ver 4:0:0:0
}

.class public abstract auto ansi beforefieldinit Homework2.IL.Calculator
extends [CORE_ASSEMBLY]System.Object
{
.method public static int32 Calculate(
int32 val1, string operation, int32 val2) cil managed
{
.maxstack 2

ldarg.1
ldstr "+"
call bool [System.Runtime] System.String::Equals(string, string)
brtrue Plus

ldarg.1
ldstr "-"
call bool [System.Runtime] System.String::Equals(string, string)
brtrue Minus

ldarg.1
ldstr "*"
call bool [System.Runtime] System.String::Equals(string, string)
brtrue Multiply

ldarg.1
ldstr ":"
call bool [System.Runtime] System.String::Equals(string, string)
brtrue Divide

ldarg.1
ldstr "/"
call bool [System.Runtime] System.String::Equals(string, string)
brtrue Divide

br.s Default

Plus:
ldarg.0
ldarg.2
add
ret

Minus:
ldarg.0
ldarg.2
sub
ret

Multiply:
ldarg.0
ldarg.2
mul
ret

Divide:
ldarg.0
ldarg.2
div
ret

Default:
ldc.i4.0
ret
}

}