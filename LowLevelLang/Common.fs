namespace FSharpWcfService.LowLevelLang

// f# discriminated union type
//
// Adding a Result type
// https://blogs.msdn.microsoft.com/dotnet/2016/07/25/a-peek-into-f-4-1/
// https://github.com/fsharp/fslang-design/issues/49
//
type Result<'TSuccess,'TError> = 
    | Success of 'TSuccess
    | Failure of 'TError

module Common =
    let switch f x =
        f x |> Success

    let bind switchFunction twoTrackInput = 
        match twoTrackInput with
        | Success s -> switchFunction s
        | Failure f -> Failure f

    let (>>==) twoTrackInput switchFunction =
        bind switchFunction twoTrackInput

    let (>=>) switch1 switch2 = 
        switch1 >> (bind switch2)
