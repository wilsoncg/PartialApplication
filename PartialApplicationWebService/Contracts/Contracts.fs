namespace FSharpWcfService.Contracts

open System.Runtime.Serialization
open System.ServiceModel

// Note: When running serialization code in partial trust, you may need to convert 
//       this to a class with a default constructor.
//[<DataContract>]
//type CompositeType =
//    { [<DataMember>] mutable BoolValue : bool 
//      [<DataMember>] mutable StringValue : string }

// Record type
[<DataContract>]
type SetupPaymentRequest = {
    Amount : int 
    TradingAccountCode : string 
    RequestSource : int 
}

[<DataContract>]
type SetupPaymentResponse = {
    Code : int
    Description : string
}

// f# discriminated union type
//
// Adding a Result type
// https://blogs.msdn.microsoft.com/dotnet/2016/07/25/a-peek-into-f-4-1/
// https://github.com/fsharp/fslang-design/issues/49
//
type Result<'a,'error> = 
    | Success of 'a
    | Failure of 'error
