module Bob

open System
  
let (|Silence|_|) input =
    input
    |> Seq.filter (fun c -> not (Char.IsWhiteSpace c))
    |> Seq.isEmpty
    |> function
       | true -> Some ()
       | false -> None

let (|Yell|_|) input =
    if (Seq.isEmpty (Seq.filter (Char.IsLetter) input)) then
        None
    else
         input
            |> Seq.filter (Char.IsLetter)
            |> Seq.exists (Char.IsLower) 
            |> function
               | false -> Some ()
               | true -> None

let (|Question|_|) (input: string) = 
    if Seq.item (input.Length-1) input = '?' then Some () else None

let response (input: string): string = 
    match input.TrimEnd() with
    | Silence -> "Fine. Be that way!"
    | Yell & Question -> "Calm down, I know what I'm doing!"
    | Question -> "Sure."
    | Yell -> "Whoa, chill out!"
    | _ -> "Whatever."