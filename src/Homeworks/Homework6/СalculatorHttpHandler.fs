module Homework6.СalculatorHttpHandler

open Giraffe

let maybe = MaybeBuilder()

let checkOnCorrectExpression expression =
    match expression with
    | Ok x -> Ok x
    | Error _ -> Error $"Invalid syntax"

let calculatorHttpHandler:HttpHandler =
    fun next ctx ->
        let expression = ctx.TryBindQueryString<Expression>()
        let res = maybe{
               let! checkedExpression = checkOnCorrectExpression expression
               let! operation = Parser.tryParseOperation checkedExpression.Operation
               let! result = Calculator.tryCalculate checkedExpression.V1 operation checkedExpression.V2
               return result
        }
        match res with
        | Ok v ->
            (setStatusCode 200 >=> json v) next ctx
        | Error v ->
            (setStatusCode 400 >=> json v) next ctx