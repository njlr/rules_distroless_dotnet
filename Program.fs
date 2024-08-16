open System.Diagnostics

[<EntryPoint>]
let main _ =
  let psi = ProcessStartInfo()

  psi.FileName <- "/bin/bash"

  let args =
    [
      "-c"
      "git --version"
    ]

  for arg in args do
    psi.ArgumentList.Add(arg)

  use p = new Process()

  p.StartInfo <- psi

  p.Start() |> ignore
  p.WaitForExit()

  p.ExitCode
