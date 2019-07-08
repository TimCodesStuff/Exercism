module LargestSeriesProduct

open System

let largestProduct (input : string) seriesLength : int option = 
    if not (Seq.forall Char.IsDigit input)
            || seriesLength < 0 
            || input.Length < seriesLength then
         None
    elif seriesLength = 0 then
        Some 1
    else
        input
        |> Seq.map (fun x -> x.ToString() |> int)
        |> Seq.windowed seriesLength
        |> Seq.map (fun subSet -> Seq.reduce (*) subSet)
        |> Seq.max
        |> Some