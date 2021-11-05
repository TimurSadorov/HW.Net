module Tests.Calculator

open Homework4
open Xunit

let checkOperation firstNum secondNum operation expected =
    let actual = Calculator.calculate firstNum operation secondNum
    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData(1, 2, "+", 3)>]
[<InlineData(-2, 3, "+", 1)>]
[<InlineData(2, -4, "+", -2)>]
[<InlineData(-3, -4, "+", -7)>]
let Calculate_Sum_ReturnSumNumbers (firstNum, secondNum, operation, expected) =
    checkOperation firstNum secondNum operation expected
    
[<Theory>]
[<InlineData(5, 2, "-", 3)>]
[<InlineData(2, -6, "-", 8)>]
[<InlineData(-3, 4, "-", -7)>]
[<InlineData(-8, -2, "-", -6)>]
let Calculate_Subtraction_ReturnDifferenceNumbers (firstNum, secondNum, operation, expected) =
    checkOperation firstNum secondNum operation expected
    
[<Theory>]
[<InlineData(0, 0, "*", 0)>]
[<InlineData(0, -6, "*", 0)>]
[<InlineData(4, 0, "*", 0)>]
[<InlineData(1, 20, "*", 20)>]
[<InlineData(3, -2, "*", -6)>]
[<InlineData(-5, -3, "*", 15)>]
let Calculate_Multiplication_ReturnProductNumbers (firstNum, secondNum, operation, expected) =
    checkOperation firstNum secondNum operation expected
    
[<Theory>]
[<InlineData(0, 2, "/", 0)>]
[<InlineData(0, -10, "/", 0)>]
[<InlineData(20, 2, "/", 10)>]
[<InlineData(10, -5, "/", -2)>]
[<InlineData(-9, -9, "/", 1)>]
[<InlineData(20, 2, ":", 10)>]
[<InlineData(10, -5, ":", -2)>]
[<InlineData(-9, -9, ":", 1)>]
let Calculate_Division_ReturnQuotient (firstNum, secondNum, operation, expected) =
    checkOperation firstNum secondNum operation expected
    
[<Theory>]
[<InlineData(20, 2, ">")>]
[<InlineData(10, -5, "?")>]
[<InlineData(-9, -9, "%")>]
let Calculate_UnknownOperations_ReturnZero (firstNum, secondNum, operation) =
    checkOperation firstNum secondNum operation 0