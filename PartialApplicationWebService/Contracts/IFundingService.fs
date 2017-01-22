namespace FSharpWcfService.Contracts

open System.Runtime.Serialization
open System.ServiceModel

[<ServiceContract>]
type public IFundingService =
    [<OperationContract>]
    abstract member SetupPayment: request:SetupPaymentRequest -> SetupPaymentResponse
