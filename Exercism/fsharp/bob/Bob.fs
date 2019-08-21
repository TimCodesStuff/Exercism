module Bob

open System

let IsSilence (input: string): bool =
    input.Length = 0 ||
    input
    |> Seq.exists (fun c -> not (Char.IsWhiteSpace c))
    |> not

let IsYell (input: string): bool =
    if (Seq.isEmpty (Seq.filter (Char.IsLetter) input)) then
        false
    else
         input
            |> Seq.filter (Char.IsLetter)
            |> Seq.exists (Char.IsLower) 
            |> not

let IsQuestion (input: string): bool =
    Seq.item (input.Length-1) input = '?'

let IsYelledQuestion (input: string): bool =
    IsYell input && IsQuestion input

let response (input: string): string = 
    match input.TrimEnd() with
    | str when IsSilence str-> "Fine. Be that way!"
    | str when IsYelledQuestion str -> "Calm down, I know what I'm doing!"
    | str when IsQuestion str -> "Sure."
    | str when IsYell str -> "Whoa, chill out!"
    | _ -> "Whatever."