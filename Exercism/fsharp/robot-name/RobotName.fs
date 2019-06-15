module RobotName

open System

let rand = Random()
type Robot = { mutable name: string }

let genRandCharAsString () = 
    rand.Next(65, 91) |> char |> string

let genRandNumAsString () =
    rand.Next(0, 10).ToString()

let createRobotName () =
    genRandCharAsString() + genRandCharAsString() + genRandNumAsString() + genRandNumAsString() + genRandNumAsString()

let mkRobot() =
    { name = createRobotName() }

let name (robot : Robot) = 
    robot.name

let reset (robot : Robot) = 
    robot.name <- createRobotName()
    robot