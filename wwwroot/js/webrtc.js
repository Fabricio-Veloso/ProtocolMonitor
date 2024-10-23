let localConnection;
let remoteConnection;
let dataChannel;

// Função para criar a conexão e o data channel
function createConnection() {
    // Cria uma nova conexão RTC
    localConnection = new RTCPeerConnection({
        iceServers: [
            {
                urls: 'turn:relay1.expressturn.com:3478',
                username: 'efQ2MSRQZK5ZHGIQLX',
                credential: 'rFKu0X7kDf5qfmiw'
            }
        ]
    });

    // Cria o canal de dados na conexão local
    dataChannel = localConnection.createDataChannel("dataChannel");

    // Acompanha o estado do canal de dados
    dataChannel.onopen = () => {
        console.log("DataChannel is open");
        // Agora o canal de dados está aberto e pronto para enviar mensagens
    };

    dataChannel.onclose = () => {
        console.log("DataChannel is closed");
    };

    dataChannel.onmessage = (event) => {
        console.log("Message received:", event.data);
        DotNet.invokeMethodAsync('MyBlazorPwa', 'ReceiveMessage', event.data);
    };

    // Configuração de ICE candidates
    localConnection.onicecandidate = (event) => {
        if (event.candidate) {
            console.log("Sending ICE candidate:", event.candidate);
            remoteConnection.addIceCandidate(event.candidate);
        }
    };

    // Criação da oferta e sinalização
    localConnection.createOffer().then(offer => {
        localConnection.setLocalDescription(offer);
        console.log("Offer created: ", offer);

        // Cria a conexão remota simulando a outra ponta
        remoteConnection = new RTCPeerConnection({
            iceServers: [
                {
                    urls: 'turn:relay1.expressturn.com:3478',
                    username: 'efQ2MSRQZK5ZHGIQLX',
                    credential: 'rFKu0X7kDf5qfmiw'
                }
            ]
        });

        // Adiciona ICE candidates recebidos na conexão remota
        remoteConnection.onicecandidate = (event) => {
            if (event.candidate) {
                console.log("Remote sending ICE candidate:", event.candidate);
                localConnection.addIceCandidate(event.candidate);
            }
        };

        // Evento de conexão estabelecida com canal de dados remoto
        remoteConnection.ondatachannel = (event) => {
            let receiveChannel = event.channel;
            receiveChannel.onopen = () => {
                console.log("Remote DataChannel is open");
            };
            receiveChannel.onmessage = (event) => {
                console.log("Remote message received:", event.data);
                DotNet.invokeMethodAsync('MyBlazorPwa', 'ReceiveMessage', event.data);
            };
        };

        remoteConnection.setRemoteDescription(offer);
        remoteConnection.createAnswer().then(answer => {
            remoteConnection.setLocalDescription(answer);
            localConnection.setRemoteDescription(answer);
            console.log("Answer created: ", answer);
        });
    });
}

// Função para enviar mensagem
function sendMessage(message) {
    if (dataChannel && dataChannel.readyState === "open") {
        dataChannel.send(message);
        console.log("Message sent:", message);
    } else {
        console.log("DataChannel is not open");
    }
}
