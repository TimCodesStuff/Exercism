module NthPrime

let prime nth : int option =
    let isprime n =
        let rec check i =
            i > n/2 || (n % i <> 0 && check (i + 1))
        check 2

    if nth < 1 then 
        None
    else
        let cieling = if nth < 6 then 13 else (nth * nth)
        Some (Seq.item nth (seq {for n in 1..cieling do if isprime n then yield n}))