module Tests.ProgramTests

open Xunit
open Homework5

let checkResultProgram args exp =
    let actual = Program.main args
    Assert.Equal(exp, actual)
    
let CorrectExpression = [|
    [|[|"10"; "+"; "2"|]|]
    [|[|"4.5"; ":"; "0.2"|]|]
|]

[<Theory>]
[<MemberData(nameof(CorrectExpression))>]
let Main_CorrectExpression_ReturnZero args =
    checkResultProgram args 0

let InvalidArguments = [|
    [|[|"x"; "+"; "2.3"|]|]
    [|[|"p"; "/"; "y"|]|]
|]

[<Theory>]
[<MemberData(nameof(InvalidArguments))>]
let Main_InvalidArguments_ReturnOne args =
    checkResultProgram args 1
    
let InvalidOperations = [|
    [|[|"11"; "^"; "231.12"|]|]
    [|[|"23.67"; "&"; "10"|]|]
|]

[<Theory>]
[<MemberData(nameof(InvalidOperations))>]
let Main_InvalidOperations_ReturnTwo args =
    checkResultProgram args 2
    
let DivisionZero = [|
    [|[|"13"; ":"; "0"|]|]
    [|[|"0"; "/"; "0"|]|]
|]

[<Theory>]
[<MemberData(nameof(DivisionZero))>]
let Main_DivisionZero_ReturnThree args =
    checkResultProgram args 3