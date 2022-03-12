open System
open System.IO

let lines =
    File.ReadLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/data.txt"))
    |> Seq.cast<string>
    |> Seq.map Int32.Parse

let partOne =
    lines
    |> Seq.windowed 2
    |> Seq.map (fun x -> x[0] < x[1])
    |> Seq.filter id
    |> Seq.length
    
printfn $"{partOne}"

let partTwo =
    lines
    |> Seq.windowed 3
    |> Seq.map Seq.sum
    |> Seq.windowed 2
    |> Seq.map (fun x -> x[0] < x[1])
    |> Seq.filter id
    |> Seq.length

printfn $"{partTwo}"
