module Tests.Calculator

open Homework5
open Xunit
open Xunit

let checkCorrectOperation firstNum secondNum operation expected =
    let actual = Calculator.tryCalculate firstNum operation secondNum
    match actual with
    | Ok o -> Assert.Equal(expected, o, 10)
    | Error e -> Assert.True(false)


let Sum: obj[][] = [|
    [|1; 2; Plus; 3|]
    [|-2; 3; Plus; 1|]
    [|10.32; 2.3; Plus; 12.62|]
    [|-23.256; 3.128; Plus; -20.128|]
|]

[<Theory>]
[<MemberData(nameof(Sum))>]
let Calculate_Sum_ReturnOk firstNum secondNum operation expected =
    checkCorrectOperation firstNum secondNum operation expected

let Subtraction: obj[][] = [|
    [|5; 2; Minus; 3|]
    [|2; -6; Minus; 8|]
    [|-3.34; 4.10; Minus; -7.44|]
    [|10.34; 3.233; Minus; 7.107|]
|]

[<Theory>]
[<MemberData(nameof(Subtraction))>]
let Calculate_Subtraction_ReturnOk firstNum secondNum operation expected =
    checkCorrectOperation firstNum secondNum operation expected
    
let Multiplication: obj[][] = [|
    [|5; 2; Multiply; 10|]
    [|10; -2; Multiply; -20|]
    [|2.3; 4.5; Multiply; 10.35|]
    [|-12.345; 10; Multiply; -123.45|]
|]

[<Theory>]
[<MemberData(nameof(Multiplication))>]
let Calculate_Multiplication_ReturnOk firstNum secondNum operation expected =
    checkCorrectOperation firstNum secondNum operation expected
    
let Division: obj[][] = [|
    [|10; 5; Divide; 2|]
    [|12; 5; Divide; 2.4|]
    [|2.4; -1.2; Divide; -2|]
    [|-13; 4; Divide; -3.25|]
|]

[<Theory>]
[<MemberData(nameof(Division))>]
let Calculate_Division_ReturnOk firstNum secondNum operation expected =
    checkCorrectOperation firstNum secondNum operation expected
    
let DivisionError: obj[][] = [|
    [|10; 0; Divide|]
    [|-12.12; 0; Divide|]
|]

[<Theory>]
[<MemberData(nameof(DivisionError))>]
let Calculate_DivisionZero_ReturnError firstNum secondNum operation =
    let actual = Calculator.tryCalculate firstNum operation secondNum
    match actual with
    | Ok o -> Assert.True(false)
    | Error e -> Assert.Equal(3, e)
    