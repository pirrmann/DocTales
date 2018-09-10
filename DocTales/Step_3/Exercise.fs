module Step3.Exercise

(*
//If you want to execute part of this file in the REPL, you must first load the following files:
#load "../Blank.fs"
#load "../String.fs"
#load "../Output.fs"
#load "Document.fs"
#load "HtmlRenderer.fs"

open Step3
*)

open Expecto

let shouldEqual expected actual =
  Expect.equal actual expected "Values should be equal"

// You can write tests and/or work with the REPL
// However, I don't write the tests myself anymore, that's up to you

// this run function is called in Program.fs if you execute the application
let run () =
    [
        Text.Block "We are now able to have text blocks and lists with styles:"
        List [
            Text.Regular "regular"
            Text.Medium "medium"
            Text.Strong "strong"
        ]
        Text.Block "We also have shortcuts to make it easier to generate simple"
        Text.List ["lists"; "of"; "values"]
    ] |> Output.writeFile HtmlRenderer.toHtml
