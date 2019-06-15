module TwelveDays

let recite start stop = 
    let preface = "On the {num} day of Christmas my true love gave to me: "
    let days = [|"first"; "second"; "third"; "fourth"; "fifth"; "sixth"; "seventh"; "eighth"; "ninth"; "tenth"; "eleventh"; "twelfth"|]
    let gifts = [|"a Partridge in a Pear Tree."; "two Turtle Doves, and ";"three French Hens, "; "four Calling Birds, "; "five Gold Rings, "; "six Geese-a-Laying, ";
                  "seven Swans-a-Swimming, "; "eight Maids-a-Milking, "; "nine Ladies Dancing, "; "ten Lords-a-Leaping, "; "eleven Pipers Piping, "; "twelve Drummers Drumming, "|]

    let rec printAllgifts (day: int) =
        if (day = 0) then "" else gifts.[day-1] + (printAllgifts (day-1)) 

    let printDay (day: int) = 
        preface.Replace("{num}", (days.[day-1])) + (printAllgifts day)

    let rec printAllDays (day: int) =
        if((day-1) = stop) then [] else List.append [printDay day] (printAllDays (day+1))

    printAllDays start
                    

        