open System
open System.IO

let lines =
    File.ReadLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/data.txt"))
    |> Seq.cast<string>
    |> Seq.map
        (fun x ->
            x
            |> Seq.toList
            |> Seq.map (fun x -> if x = '1' then 1 else 0))

let lineCount = lines |> Seq.length

let sums =
    [ 0 .. (lines |> Seq.head |> Seq.length) - 1 ]
    |> Seq.map
        (fun index ->
            lines
            |> Seq.map
                (fun line ->
                    line
                    |> Seq.mapi (fun i v -> v, i)
                    |> Seq.find (fun (_, i) -> i = index)
                    |> fst)
            |> Seq.sum)

let sigma =
    Convert.ToInt32(
        sums
        |> Seq.map (fun x -> if (lineCount / 2) > x then "1" else "0")
        |> String.concat "",
        2
    )

let epsilon =
    Convert.ToInt32(
        sums
        |> Seq.map (fun x -> if (lineCount / 2) < x then "1" else "0")
        |> String.concat "",
        2
    )

printfn $"Part 1: {sigma * epsilon}"
