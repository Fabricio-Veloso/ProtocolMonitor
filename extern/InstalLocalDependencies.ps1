#Importante colocar no tutorial que o usuário antes de executar o script 
#permita a execução de scripts powershell
#remoto assinados e locais com o comando: Set-ExecutionPolicy RemoteSigned
 
# Verificando se o Node.js esta instalado
$nodePath = (Get-Command node -ErrorAction SilentlyContinue).Path
if (-not $nodePath) {
    Write-Host "Node.js nao esta instalado. Instalando Node.js..."
    # Instalando Node.js via winget
    winget install -e --id OpenJS.NodeJS
    if ($LASTEXITCODE -ne 0) {
        Write-Host "Falha ao instalar Node.js. Saindo..."
        exit 1
    }
    
}
else {
    Write-Host "Node.js ja esta instalado."
}

# Verificando se o Puppeteer esta instalado globalmente
$puppeteerInstalled = npm list -g --depth=0 | Select-String -Pattern "puppeteer"
if (-not $puppeteerInstalled) {
    Write-Host "Puppeteer nao esta instalado globalmente. Instalando Puppeteer..."
    npm install -g puppeteer
    if ($LASTEXITCODE -ne 0) {
        Write-Host "Falha ao instalar Puppeteer. Saindo..."
        exit 1
    }
}
else {
    Write-Host "Puppeteer ja esta instalado globalmente."
}

Write-Host "Todas as instalacoes foram concluidas com sucesso."

# Adiciona uma pausa para que a janela do PowerShell aguarde a entrada do usuario antes de fechar
Write-Host "Pressione Enter para encerrar o processo de instalação..."
Read-Host
