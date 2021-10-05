module ProgramTests

open Homework4
open Xunit

let checkProgram args expected =
    let actual = Program.main args
    Assert.Equal(expected, actual)

[<Fact>]
let ``Main_CorrectExpression_ReturnZero`` () =
    checkProgram [|"1"; "+"; "2"|] 0

let  Expressions: obj[][] = [|
    [|[|"11"; "^"; "231"|]; 2|]
    [|[|"s"; "+"; "2"|]; 1|]
|]

[<Theory>]
[<MemberData(nameof(Expressions))>]
let ``Main_IncorrectExpression_ReturnNotZero`` (args, expected) =
    checkProgram args expected
    