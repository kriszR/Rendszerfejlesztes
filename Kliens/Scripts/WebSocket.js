class WSocket {
    constructor() {
        this.socket = new WebSocket("wss://localhost:7089/Szerver/ws");
        this.socket.onopen = (event) => {
            console.log("WebSocket connection established.");
        };
        this.socket.onmessage = (event) => {
            alert(event.data);
        };
        this.socket.onclose = (event) => {
            if (event.wasClean) {
                console.log(`WebSocket connection closed cleanly, code=${event.code}, reason=${event.reason}`);
            } else {
                console.error(`WebSocket connection died`);
            }
        };
    }
    sendMessage(message) {
        this.socket.send(message);
    }
}

export const webSocket = new WSocket();







