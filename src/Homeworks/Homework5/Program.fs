module Homework5.Program

let maybe = MaybeBuilder()

[<EntryPoint>]
let main args =
    let res = maybe {
        let! val1, val2 = Parser.tryParseArguments args
        let! operation = Parser.tryParseOperation args
        let! result = Calculator.tryCalculate val1 operation val2
        return result
    }
    match res with
    | Ok x ->
        printf $"{args.[0]}{args.[1]}{args.[2]}={x}"
        0
    | Error e ->
        match e with
        | 1 -> printf $"{args.[0]}{args.[1]}{args.[2]} is not a valid calculate syntax"
        | 2 ->  printf $"{args.[0]}{args.[1]}{args.[2]} is not a valid calculate syntax \n Supported operations are + - * / :"
        | 3 -> printf "Division by zero is not possible"
        e