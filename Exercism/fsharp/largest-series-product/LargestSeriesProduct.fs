module LargestSeriesProduct

open System.Text.RegularExpressions

let largestProduct (input : string) seriesLength : int option = 
    let rec findLargestProductOfLengthX x largest (input : int list) = 
        if input.Length >= x then
            let localProd = input |> Seq.take x |> Seq.reduce (*)
            let newLargsest = if largest > localProd then largest else localProd
            findLargestProductOfLengthX x newLargsest input.Tail
        else
            largest   

    if seriesLength = 0 then
        Some 1
    elif not ((new Regex(@"^[0-9]+$")).IsMatch input) 
            || seriesLength < 0 
            || input.Length < seriesLength then
        None
    else
        input
        |> List.ofSeq
        |> List.map (fun x -> x.ToString() |> int)
        |> findLargestProductOfLengthX seriesLength 0
        |> Some