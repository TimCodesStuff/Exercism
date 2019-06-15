module Pangram

// Using sets
let isPangram (input: string): bool =
    let alphaSet = Set.ofSeq ['a' .. 'z']
    input.ToLowerInvariant()
    |> Set.ofSeq
    |> Set.isSubset alphaSet
    
// Without sets
let isPangramOrig (input: string): bool = 
    input.ToLowerInvariant()
    |> Seq.filter (fun char -> char >= 'a' && char <= 'z')
    |> Seq.distinct
    |> Seq.sort
    |> fun chars -> System.String.Concat(chars) = "abcdefghijklmnopqrstuvwxyz"