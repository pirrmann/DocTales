module Output

let writeFile<'a> (toHtml: 'a -> string seq) (openInBrowser: bool) (document: seq<'a>) =
    let htmlContent = document |> Seq.collect toHtml |> String.concat
    let htmlTemplate = System.IO.File.ReadAllText(__SOURCE_DIRECTORY__ + "/html-template.html")
    let outputFile = __SOURCE_DIRECTORY__ + "/output.html"
    System.IO.File.WriteAllText(outputFile, htmlTemplate.Replace("{content}", htmlContent))
    if openInBrowser then
        System.Diagnostics.Process.Start(outputFile) |> ignore
