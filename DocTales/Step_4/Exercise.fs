module Step4.Exercise

(*
//If you want to execute part of this file in the REPL, you must first load the following files:
#load "../Blank.fs"
#load "../String.fs"
#load "../Output.fs"
#load "Document.fs"
#load "HtmlRenderer.fs"

open Step4
*)

open Expecto

let shouldEqual expected actual =
  Expect.equal actual expected "Values should be equal"

// You can write tests and/or work with the REPL
// However, I don't write the tests myself anymore, that's up to you

// this run function is called in Program.fs if you execute the application
let run () =
    [
        Text.Block "We are now able to have text blocks and lists with CUSTOM styles:"
        List [
            Text.Regular "regular"
            Text.Medium "medium"
            Text.Strong "strong"
            Text [{ TextPart.Regular "with an horrible flashy style" with Style = Some "flashy" }]
        ]
    ] |> Output.writeFile HtmlRenderer.toHtml
