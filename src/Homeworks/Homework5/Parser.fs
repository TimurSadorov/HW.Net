module Homework5.Parser

let tryParseArguments (args: string[]) =
    try Ok (args.[0] |> decimal , args.[2] |> decimal)
    with
    | e -> Error 1

let tryParseOperation (args:string[]) =
    match args.[1] with
    | "+" -> Ok Plus
    | "-" -> Ok Minus
    | "*" -> Ok Multiply
    | "/" -> Ok Divide
    | ":" -> Ok Divide
    | _ ->   Error  2
 
    