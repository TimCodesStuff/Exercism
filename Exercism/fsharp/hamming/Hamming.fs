module Hamming

let distance (strand1: string) (strand2: string): int option =
    if strand1.Length = strand2.Length then
        let diff = fun a b -> if a = b then 0 else 1
        Seq.map2 diff strand1 strand2
        |> Seq.sum
        |> Option.Some
    else
        None