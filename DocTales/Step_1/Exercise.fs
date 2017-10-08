module Step1.Exercise

(*
//If you want to execute part of this file in the REPL, you must first load the following files:
#load "../Blank.fs"
#load "../Output.fs"
#load "Text.fs"
#load "HtmlRenderer.fs"

#r "../../packages/NUnit/lib/nunit.framework.dll"
#load "../../paket-files/forki/FsUnit/FsUnit.fs"
*)

type Test = NUnit.Framework.TestAttribute
open FsUnit

// You can write tests and/or work with the REPL
let [<Test>] ``Rendering a simple text part produces the text`` () =
    { Text = "text"; Emphasis=Regular } |> HtmlRenderer.toHtml |> String.concat |> shouldEqual "text"

// this run function is called in Program.fs if you execute the application
let run () =
    [
        { Text = "Hello "; Emphasis=Regular }
        { Text = "World"; Emphasis=Strong }
    ] |> Output.writeFile HtmlRenderer.toHtml true
