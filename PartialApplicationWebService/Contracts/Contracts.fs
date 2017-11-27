namespace FSharpWcfService.Contracts

open System.Runtime.Serialization
open System.ServiceModel

// Note: When running serialization code in partial trust, you may need to convert 
//       this to a class with a default constructor.
//[<DataContract>]
//type CompositeType =
//    { [<DataMember>] mutable BoolValue : bool 
//      [<DataMember>] mutable StringValue : string }

// Not sure about mutable keyword, seems its the only way of F#
// providing property getters and setters which WCF needs

// Record type
[<DataContract>]
type SetupPaymentRequest = {
    [<DataMember>] mutable Amount : decimal 
    [<DataMember>] mutable TradingAccountCode : string 
    [<DataMember>] mutable RequestSource : int     
    [<DataMember>] mutable Username : string
    [<DataMember>] mutable LegalPartyId : int
}

[<DataContract>]
type MakePaymentRequest = {
    [<DataMember>] mutable ServiceProviderReference : string 
}

[<DataContract>]
type Request = 
    | SetupPaymentRequest
    | MakePaymentRequest

[<DataContract>]
type SetupPaymentResponse = {
    [<DataMember>] mutable Code : int
    [<DataMember>] mutable Description : string
}

[<DataContract>]
type MakePaymentResponse = {
    [<DataMember>] mutable Code : int
    [<DataMember>] mutable Description : string
}

[<ServiceContract()>]
type IFundingService =
    [<OperationContract>]
    abstract member SetupPayment : SetupPaymentRequest -> SetupPaymentResponse
    [<OperationContract>]
    abstract member MakePayment : MakePaymentRequest -> MakePaymentResponse