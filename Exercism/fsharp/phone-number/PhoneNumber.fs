module PhoneNumber

open Result
open System 

// Ensures no letter.
let private CleanLetters (input : seq<char>) =
    input 
    |> Seq.exists(Char.IsLetter) 
    |> function
        | true -> Error "letters not permitted"
        | false -> Ok (input |> Seq.filter(Char.IsDigit))

// Removes the first char if it's a plus sign.
let private CleanBeginningPlus (input : seq<char>) =
    if (Seq.head input) = '+' then Seq.tail input else input

// Removes allowed punctuation, then ensures no punctuation left.
let private CleanPunctuation (input : seq<char>) =
    let allowedPunctuation = Set.ofList [' '; '-'; '('; ')'; '.']
    let cleaned = 
        input 
        |> CleanBeginningPlus
        |> Seq.filter(fun c -> not (allowedPunctuation.Contains c))
    
    cleaned
    |> Seq.exists(Char.IsPunctuation)
    |> function
       | true -> Error "punctuations not permitted"
       | false -> Ok cleaned
       
// Ensures that a ten digit number begins correctly.
let private ValidateTenDigitNumber (input : seq<char>) =
    match Seq.head input with
    | '0' -> Error "area code cannot start with zero"
    | '1' -> Error "area code cannot start with one"
    | _ -> Ok input

// Ensures that an eleven digit number is structures correctly.
let private ValidateElevenDigitNumber (input : seq<char>) =
    if Seq.head input = '1' then 
        ValidateTenDigitNumber (Seq.tail input)
        else Error "11 digits must start with 1" 

// Ensures a 10 or 11 digit number is structured correctly.
let private ValidateNumber (input : seq<char>) =
    match Seq.length input with
    | 11 -> ValidateElevenDigitNumber input
    | 10 -> ValidateTenDigitNumber input
    | x when x > 11 -> Error "more than 11 digits"
    | _ -> Error "incorrect number of digits"

// Ensures a 10 digit code is structured correctly.
let private ValidateExchangeCodeOnTenDigitNumber (input : seq<char>) =
    let phoneNumber = String.Concat(input)
    match phoneNumber.[3] with
    | '0' -> Error "exchange code cannot start with zero"
    | '1' -> Error "exchange code cannot start with one"
    | _ -> Ok (uint64(phoneNumber))

let clean (input: string) =
    result { 
        let! noPunctNumber = CleanPunctuation input
        let! cleanPhoneNumber = CleanLetters noPunctNumber 
        let! cleanTenDigitNumber = ValidateNumber cleanPhoneNumber
        return! ValidateExchangeCodeOnTenDigitNumber cleanTenDigitNumber
        }  