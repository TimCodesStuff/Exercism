module File1
open RobotName
open System

[<EntryPoint>]
let main (args : string []) =
    let randString = String.init 1000 (fun _ -> genRandNumAsString())
    let lel = 
        randString
        |> List.ofSeq
        |> List.distinct
        |> List.sort
        |> Array.ofList
        |> String.Concat
    
    Console.WriteLine(lel)
    Console.Read() |> ignore
    0