open System
open System.IO

let lines =
    File.ReadLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/data.txt"))
    |> Seq.cast<string>
    |> Seq.map (fun x -> x.Split(' '))
    |> Seq.map (fun x -> x[0], Int32.Parse(x[1]))

let horizontal =
    lines
    |> Seq.filter (fun (direction, _) -> direction = "up" || direction = "down")
    |> Seq.fold
        (fun acc (direction, units) ->
            if direction = "down" then
                acc + units
            else
                acc - units)
        0

let vertical =
    lines
    |> Seq.filter (fun (direction, _) -> direction = "forward")
    |> Seq.map snd
    |> Seq.sum

printfn $"Part 1: {vertical} * {horizontal} = {vertical * horizontal}"

let part_two =
    lines
    |> Seq.fold
        (fun (x, y, aim) (direction, units) ->
            match direction with
                | "up" -> x, y, aim - units
                | "down" -> x, y, aim + units
                | "forward" -> x + units, y + (units * aim), aim
                | _ -> x, y, aim)
        (0, 0, 0)
        
let x, y, _ = part_two

printfn $"Part 2: {x} * {y} = {x * y}"
