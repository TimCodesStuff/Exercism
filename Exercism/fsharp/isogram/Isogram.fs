module Isogram

let isIsogram (str: string) = 
    
    str.ToLowerInvariant()
    |> Seq.filter (fun char -> char <> '-' && char <> ' ')
    |> Seq.sort
    |> Seq.pairwise
    |> Seq.map (fun (x,y) -> x=y)
    |> Seq.contains true
    |> not