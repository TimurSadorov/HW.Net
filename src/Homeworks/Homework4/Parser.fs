module Homework4.Parser

open System

let SupportedOperations = [|"+"; "-"; "*"; "/"; ":"|]

let TryParseArguments (args: string[]) (val1: byref<int>) (operation: outref<string>) (val2: outref<int>) =
    let isVal1Int = Int32.TryParse(args.[0], &val1)
    let isVal2Int = Int32.TryParse(args.[2], &val2)
    operation <- args.[1]
    if (isVal1Int && isVal2Int) = false then
        printf $"{args.[0]}{args.[1]}{args.[2]} is not a valid calculate syntax"
        1
    else if Array.contains operation SupportedOperations = false then
        printf $"{args.[0]}{args.[1]}{args.[2]} is not a valid calculate syntax \n Supported operations are + - * / :"
        2
    else 0
   
 
    