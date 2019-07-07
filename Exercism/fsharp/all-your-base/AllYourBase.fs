module AllYourBase

let rec convertToBaseTen (index : int) (bas : int) (digits: int list) =
    if(digits.IsEmpty) then
        0
    else
        ((pown bas index) * digits.Head) + convertToBaseTen (index+1) bas digits.Tail


let convertBaseTenToBaseX (bas : int) (baseTenNumber : int) = 
    let rec convertToBaseX (bas : int) (baseTenNumber : int) (baseXNumber : int list) =
        if baseTenNumber = 0 then
            baseXNumber
        else
            let number = baseTenNumber / bas
            let newList = List.append [baseTenNumber % bas] baseXNumber
            convertToBaseX bas number newList
    convertToBaseX bas baseTenNumber []
    
let rebase (digits : int list) inputBase outputBase =
    if outputBase <= 1 || inputBase <=1 then
        None // Invalid base inputs
    else if not ((List.tryFind (fun x -> x < 0) digits) = None) then
        None // Negative digits found
    else if not ((List.tryFind (fun x -> x >= inputBase ) digits) = None) then
        None // Invalid input digit
    else 
        match convertToBaseTen 0 inputBase (List.rev(digits)) with
        | 0 -> Some [0]
        | numBaseTen -> Some (convertBaseTenToBaseX outputBase numBaseTen)
    