// F# の詳細については、http://fsharp.net を参照してください
// 詳細については、'F# チュートリアル' プロジェクトを参照してください。

[<EntryPoint>]
let main argv = 
    for i in 1 .. 100 do
        if i % 15 = 0 then
            printfn "FizzBuzz"
        elif i % 3 = 0 then
            printfn "Fizz"
        elif i % 5 = 0 then
            printfn "Buzz"
        else
            printfn "%d" i
    0 
