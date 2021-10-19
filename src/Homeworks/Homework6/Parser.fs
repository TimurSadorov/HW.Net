module Homework6.Parser

let tryParseOperation operation =
    match operation with
    | "plus" -> Ok Plus
    | "minus" -> Ok Minus
    | "mult" -> Ok Multiply
    | "divide" -> Ok Divide
    | _ ->   Error  $"Valid operation, supported operations are plus mines mult divide"
 
    