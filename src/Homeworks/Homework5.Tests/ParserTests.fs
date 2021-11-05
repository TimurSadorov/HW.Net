module Tests.Parser

open Homework5
open Xunit

let CorrectArguments = [|
    [|[|"10"; "+"; "2"|]|]
    [|[|"2"; "-"; "10"|]|]
    [|[|"20"; "*"; "10.23"|]|]
    [|[|"4.12231"; "/"; "4"|]|]
    [|[|"50.124435"; ":"; "2.21"|]|]
|]

[<Theory>]
[<MemberData(nameof(CorrectArguments))>]
let TryParseArguments_CorrectArguments_ReturnOk args =
    let actual = Parser.tryParseArguments args
    match actual with
    | Ok r -> Assert.Equal((args.[0] |> decimal,args.[2] |> decimal), r)
    | Error e -> Assert.True(false)
    
let InvalidArguments = [|
    [|[|"x"; "-"; "2"|]|]
    [|[|"5.19"; "+"; "="|]|]
    [|[|"p"; "+"; "x"|]|]
|]

[<Theory>]
[<MemberData(nameof(InvalidArguments))>]
let TryParseArguments_InvalidArguments_ReturnError args =
    let actual = Parser.tryParseArguments args
    match actual with
    | Ok r -> Assert.True(false)
    | Error e -> Assert.Equal(1, e)
    
let InvalidOperations = [|
    [|[|"10"; "<"; "2"|]|]
    [|[|"5"; "\\"; "5"|]|]
    [|[|"10"; "%"; "6"|]|]
|]

[<Theory>]
[<MemberData(nameof(InvalidOperations))>]
let TryParseOperation_InvalidOperation_ReturnError args =
    let actual = Parser.tryParseOperation args
    match actual with
    | Ok r -> Assert.True(false)
    | Error e -> Assert.Equal(2, e)

let CorrectOperations : obj[][] = [|
    [|[|"10"; "+"; "2"|]; Plus|]
    [|[|"2"; "-"; "10"|]; Minus|]
    [|[|"20"; "*"; "10"|]; Multiply|]
    [|[|"4"; "/"; "4"|]; Divide|]
    [|[|"50"; ":"; "2"|]; Divide|]
|]

[<Theory>]
[<MemberData(nameof(CorrectOperations))>]
let tryParseOperation_CorrectOperations_ReturnOk args exp =
    let actual = Parser.tryParseOperation args
    match actual with
    | Ok o -> Assert.Equal(exp, o)
    | Error e -> Assert.True(false)