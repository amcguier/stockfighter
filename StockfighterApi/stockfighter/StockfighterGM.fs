module StockFighterGM 
    open StockfigherCommon
    open HttpClient
    
    let private url_base = "https://www.stockfighter.io/gm/"

    type GMApi(apiKey : string) = 
      member this.startLevelAsync level = 
        let url = url_base + "levels/" + level
        async  {
            let! body = post url () apiKey 
                        |> HttpClient.getResponseBodyAsync
            return GM(body)
            }

      member this.startLevel level =
        this.startLevelAsync level |> Async.RunSynchronously

      member this.getLevelsAsync ()  =
          let url = url_base + "levels"
          async {
              let request = get url apiKey
              let! body =  request |> HttpClient.getResponseBodyAsync
              return body
              }
     
      member this.restartInstanceAsync (instance : int64) =
          let url = sprintf "%s/instances/%i/restart" url_base instance
          async {
              let request = post url () apiKey
              let! body =  request |> getResponseBodyAsync
              return GM(body)
              }

      member this.restartInstance (instance : int64) =
          this.restartInstanceAsync instance |> Async.RunSynchronously
      
      member this.stopInstanceAsync (instance : int64) =
          let url = sprintf "%s/instances/%i/restart" url_base instance
          async {
              let request = post url () apiKey
              let! body = request |> getResponseBodyAsync
              return GM(body)
              }

      member this.stopInstance (instance : int64) =
          this.stopInstanceAsync instance |> Async.RunSynchronously
          
      member this.resumeInstanceAsync (instance : int64) =
          let url = sprintf "%s/instances/%i/resume" url_base instance
          async {
              let request = post url () apiKey
              let! body = request |> getResponseBodyAsync
              return GM(body)
              }
          
      member this.resumeInstance (instance : int64) =
          this.resumeInstanceAsync instance |> Async.RunSynchronously

      member this.getInstanceAsync (instance : int64) =
          let url = sprintf "%s/instances/%i" url_base instance
          async {
              let request = get url apiKey
              let! body = request |> getResponseBodyAsync
              return GM(body)
              }

      member this.getInstance (instance : int64) =
          this.getInstanceAsync instance |> Async.RunSynchronously
