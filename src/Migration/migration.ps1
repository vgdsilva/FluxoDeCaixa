Write-Host -ForegroundColor Yellow "   __  ____               __  _                "
Write-Host -ForegroundColor Yellow "  /  |/  (_)__ ________ _/ /_(_)__  ___  ___   "
Write-Host -ForegroundColor Yellow " / /|_/ / / _ ``/ __/ _ ``/ __/ / _ \/ _ \(_-< "
Write-Host -ForegroundColor Yellow "/_/  /_/_/\_, /_/  \_,_/\__/_/\___/_//_/___/   "
Write-Host -ForegroundColor Yellow "         /___/                                 "
Write-Host
Write-Host


function ConvertToReadableTime {
    param (
        [int]$milliseconds
    )

    $totalSeconds = [math]::Floor($milliseconds / 1000)
    $minutes = [math]::Floor($totalSeconds / 60)
    $seconds = $totalSeconds % 60
    $remainingMilliseconds = $milliseconds % 1000

    $timeParts = @()

    if ($minutes -gt 0) {
        $timeParts += "${minutes}m"
    }

    if ($seconds -gt 0) {
		$timeParts += "${seconds}s"
    }

    if ($remainingMilliseconds -gt 0) {
        $timeParts += "${remainingMilliseconds}ms"
    }

    return $timeParts -join " "
}

function LimparArquivosDoProjeto {
    Write-Host
    Write-Host -NoNewline -ForegroundColor White "[ 1] Limpando arquivos do projeto...: "
    Get-ChildItem * -Include bin -Recurse | Remove-Item -Force -Recurse -ErrorAction SilentlyContinue
    Get-ChildItem * -Include obj -Recurse | Remove-Item -Force -Recurse -ErrorAction SilentlyContinue
	$sw = [Diagnostics.Stopwatch]::StartNew()
	dotnet clean .\FluxoDeCaixaMigration.sln
    if (!$?) {
        Write-Host -ForegroundColor Red "ERRO!"
        Write-Host -ForegroundColor Red $_
        Exit $LASTEXITCODE
    }
	$sw.Stop()
    Write-Host -NoNewLine -ForegroundColor Green "OK!"
	$tempo = ConvertToReadableTime -milliseconds $sw.ElapsedMilliseconds
	Write-Host -ForegroundColor Darkgray " (em ${tempo})"
}

LimparArquivosDoProjeto
