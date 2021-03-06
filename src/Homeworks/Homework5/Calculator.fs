module Homework5.Calculator

let tryCalculate (val1: decimal) operation (val2:decimal) =
        match operation with
        |Plus -> Ok (val1 + val2)
        |Minus -> Ok (val1 - val2)
        |Multiply-> Ok (val1 * val2)
        |Divide -> match val2 with
                        | 0m -> Error 3
                        | _ -> Ok (val1 / val2)