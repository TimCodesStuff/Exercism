module PhoneNumber

open System

let clean (input: string) =   
    let allowedPunctuation = Set.ofList [' '; '-'; '('; ')'; '+'; '.']
    
    match input |> Seq.filter(fun x -> not (allowedPunctuation.Contains x)) with
    | phoneNumber when phoneNumber |> Seq.exists(fun x -> Char.IsLetter(x)) ->  Error "alphanumerics not permitted"
    | phoneNumber when phoneNumber |> Seq.exists(fun x -> not (Char.IsLetterOrDigit(x))) ->  Error "punctuations not permitted"
    | phoneNumber -> 
        phoneNumber
        |> Seq.filter (fun x -> Char.IsDigit(x))
        |> String.Concat
        |> fun cleanedInput ->    
            match (cleanedInput.Length, cleanedInput.[0]) with
            | 11, '1' -> match cleanedInput.[1] with
                         | '0' -> Error "area code cannot start with zero"
                         | '1' -> Error "area code cannot start with one"
                         | _ -> match cleanedInput.[4] with
                                | '0' -> Error "exchange code cannot start with zero"
                                | '1' -> Error "exchange code cannot start with one"
                                | _ -> Ok (uint64(cleanedInput.Substring(1)))
            | 11, _ -> Error "11 digits must start with 1"
            | 10, '0' -> Error "area code cannot start with zero"
            | 10, '1' -> Error "area code cannot start with one"
            | 10, _ -> match cleanedInput.[3] with
                       | '0' -> Error "exchange code cannot start with zero"
                       | '1' -> Error "exchange code cannot start with one"
                       | _ -> Ok (uint64(cleanedInput))
            | x, _ when x > 11 -> Error "more than 11 digits"
            | _, _ -> Error "incorrect number of digits"
           