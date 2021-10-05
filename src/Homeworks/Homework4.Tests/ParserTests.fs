module Tests.Parser

open Homework4
open Xunit

let checkParsingOperation args expected =
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operation = ""
    let actual = Parser.TryParseArguments args &val1 &operation &val2
    Assert.Equal(expected, actual)

let CorrectArguments = [|
    [|[|"10"; "+"; "2"|]|]
    [|[|"2"; "-"; "10"|]|]
    [|[|"20"; "*"; "10"|]|]
    [|[|"4"; "/"; "4"|]|]
    [|[|"50"; ":"; "2"|]|]
|]

[<Theory>]
[<MemberData(nameof(CorrectArguments))>]
let ``TryParseArgments_CorrectExpression_ReturnZero`` (args) =
    checkParsingOperation args 0

let InvalidArguments = [|
    [|[|"x"; "-"; "2"|]|]
    [|[|"5"; "+"; "="|]|]
    [|[|"p"; "+"; "x"|]|]
|]

[<Theory>]
[<MemberData(nameof(InvalidArguments))>]
let ``TryParseArguments_InvalidArguments_ReturnOne`` (args) =
    checkParsingOperation args 1

let InvalidOperations = [|
    [|[|"10"; "<"; "2"|]|]
    [|[|"5"; "\\"; "5"|]|]
    [|[|"10"; "%"; "6"|]|]
|]

[<Theory>]
[<MemberData(nameof(InvalidOperations))>]
let ``TryParseArguments_InvalidOperation_ReturnTwo`` (args) =
    checkParsingOperation args 2