module LargestSeriesProduct

open System.Text.RegularExpressions

let largestProduct (input : string) seriesLength : int option = 
    let rec findLargestProductOfLengthX x largest (input : int list) = 
        if input.Length >= x then
            let firstX = input |> Seq.take x
            let localProd = firstX |> Seq.fold (fun acc a -> acc * a) 1
            let newLargsest = if largest > localProd then largest else localProd
            findLargestProductOfLengthX x newLargsest input.Tail
        else
            largest

    if seriesLength = 0 then
        Some 1
    else if not ((new Regex(@"^[0-9]+$")).IsMatch input) then
        None
    else if seriesLength < 0 || input.Length < seriesLength then
        None
    else
        input
        |> List.ofSeq
        |> List.map (fun x -> x.ToString())
        |> List.map (fun x -> x |> int)
        |> findLargestProductOfLengthX seriesLength 0
        |> Some
