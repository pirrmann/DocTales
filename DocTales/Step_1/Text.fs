[<AutoOpen>]
module Step1.Core

type Emphasis = | Regular | Medium | Strong
type TextPart = { Text:string; Emphasis:Emphasis }
