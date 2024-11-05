// Defina todas as funções e objetos no escopo global
let localConnection;
let dataChannel;
let messageQueue = [];
let messageContainer;

function initialize() {
    messageContainer = document.getElementById('messages');
    localConnection = new RTCPeerConnection(); // Inicializa localConnection aqui
}

function createConnection() {
    console.log("Creating connection...");

    dataChannel = localConnection.createDataChannel("chat");

    dataChannel.onopen = () => {
        console.log("Data channel opened.");
        flushMessageQueue();
    };

    dataChannel.onmessage = (event) => {
        console.log("Message received: " + event.data);
        appendMessage(event.data);
    };

    localConnection.createOffer()
        .then(offer => {
            return localConnection.setLocalDescription(offer);
        })
        .then(() => {
            console.log("Offer created:", localConnection.localDescription);
            // Aqui você deve implementar a lógica para enviar a oferta para a outra parte
        });

    // Sending ICE candidates
    localConnection.onicecandidate = event => {
        if (event.candidate) {
            console.log("Sending ICE candidate:", event.candidate);
            // Aqui você deve implementar a lógica para enviar os candidatos ICE para a outra parte
        }
    };
}

function joinConnection(offer) {
    console.log("Joining connection...");

    localConnection.setRemoteDescription(new RTCSessionDescription(offer))
        .then(() => {
            console.log("Offer set as remote description.");
            return localConnection.createAnswer();
        })
        .then(answer => {
            return localConnection.setLocalDescription(answer);
        })
        .then(() => {
            console.log("Answer created:", localConnection.localDescription);
            // Aqui você deve implementar a lógica para enviar a resposta para a outra parte
        });

    // Sending ICE candidates
    localConnection.onicecandidate = event => {
        if (event.candidate) {
            console.log("Sending ICE candidate:", event.candidate);
            // Aqui você deve implementar a lógica para enviar os candidatos ICE para a outra parte
        }
    };
}

function sendMessage(message) {
    if (dataChannel && dataChannel.readyState === "open") {
        dataChannel.send(message);
        console.log("Message sent: " + message);
    } else {
        messageQueue.push(message);
    }
}

function flushMessageQueue() {
    while (messageQueue.length > 0) {
        const message = messageQueue.shift();
        dataChannel.send(message);
        console.log("Message sent: " + message);
    }
}

function appendMessage(message) {
    const messageDiv = document.createElement("div");
    messageDiv.textContent = message;
    messageContainer.appendChild(messageDiv);
}

function hasRemoteDescription() {
    // Você pode armazenar a oferta de forma global ou gerenciá-la de outra forma
    return false; // Atualize esta lógica conforme necessário
}

// Exponha as funções como um objeto global
window.webrtc = {
    initialize,
    createConnection,
    joinConnection,
    sendMessage,
    hasRemoteDescription
};
