module Grains

let gnarGnarPowPow (n: int) = 
    (uint64 (pown 2I (n-1)))

let square (n: int): Result<uint64,string> =
    if n<1 || n>64 then 
        Result.Error "square must be between 1 and 64"
    else    
        Result.Ok (gnarGnarPowPow n)

let total: Result<uint64,string> = 
    let sum = 
        [1 .. 64]
        |> List.sumBy (fun x -> (gnarGnarPowPow x))
    Result.Ok sum
   
