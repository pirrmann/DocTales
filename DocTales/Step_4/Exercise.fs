module Step4.Exercise

(*
//If you want to execute part of this file in the REPL, you must first load the following files:
#load "../Blank.fs"
#load "../Output.fs"
#load "Document.fs"
#load "HtmlRenderer.fs"

#r "../../packages/NUnit/lib/nunit.framework.dll"
#load "../../paket-files/forki/FsUnit/FsUnit.fs"
*)

type Test = NUnit.Framework.TestAttribute
open FsUnit
open Step4

// this run function is called in Program.fs if you execute the application
let run () =
    [
        Text.Block "We are now able to have text blocks and lists with styles:"
        List [
            Text.Regular "regular"
            Text.Medium "medium"
            Text.Strong "strong"
            Text [{ TextPart.Regular "with an horrible flashy style" with Style = Some "flashy" }]
        ]
        Text.Block "We also have shortcuts to make it easier to generate simple"
        Text.List ["lists"; "of"; "values"]
    ] |> Output.writeFile HtmlRenderer.toHtml true
