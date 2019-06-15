module Leap

let isDivisibleByFour (num : int) = 
    num % 4 = 0

let isDivisibleByOneHundred (num : int) =
    num % 100 = 0

let isDivisibleByFourHundred (num : int) =
    num % 400 = 0

let leapYear (year: int): bool =
    isDivisibleByFour year && (isDivisibleByFourHundred year || (not (isDivisibleByOneHundred year)))
