module Homework6.App

open Microsoft.Extensions.Hosting

[<EntryPoint>]
let main args =
    Startup.Startup
        .CreateHostBuilder(args)
        .Build()
        .Run()
    0