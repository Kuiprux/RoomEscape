param(
    [string]$searchString
)

if (-not $searchString) {
    Write-Host "Please provide a search string."
    exit
}

Get-ChildItem | ForEach-Object {
    if ($_ -is [System.IO.FileInfo]) {
        $fileContent = Get-Content $_.FullName -Raw
        if ($fileContent -match $searchString) {
            Write-Host "File: $($_.FullName)"
            $fileContent | Select-String $searchString -AllMatches | ForEach-Object {
                $_.Line
            }
        }
    }
}
