module Step6.Exercise

(*
//If you want to execute part of this file in the REPL, you must first load the following files:
#load "../Blank.fs"
#load "../String.fs"
#load "../Output.fs"
#load "Document.fs"
#load "HtmlRenderer.fs"

open Step6

#r "../../packages/NUnit/lib/nunit.framework.dll"
#load "../../paket-files/forki/FsUnit/FsUnit.fs"
*)

type Test = NUnit.Framework.TestAttribute
open FsUnit
open Step6

// this run function is called in Program.fs if you execute the application
let run () =
    // Now I don't even do that.
    // You're in charge from now on.
    [
        // Here I'd like a nice syntax in order to represent tabular data...
        // While you're at it you may as well add support for RowSpan & ColSpan
    ] |> Output.writeFile HtmlRenderer.toHtml true
