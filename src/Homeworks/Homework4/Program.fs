module Homework4.Program

[<EntryPoint>]
let main args =
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operation = ""
    
    let parseResult = Parser.TryParseArguments args &val1 &operation &val2
    if parseResult <> 0 then
        parseResult
    else
        let result = Calculator.calculate val1 operation val2
        printf $"{val1}{operation}{val2}={result}"
        0