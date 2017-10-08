[<AutoOpen>]
module Step2.Core

type Emphasis = | Regular | Medium | Strong
type TextPart = { Text:string; Emphasis:Emphasis }

type Text = Text of TextPart list

and DocPart =
    | Block of Text
