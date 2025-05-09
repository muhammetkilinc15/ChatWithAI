var hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7118/ai-hub", {
        withCredentials: true
    })
    .build();

hubConnection.start()
    .then(() =>
        document.getElementById("connectionId").innerHTML = `(${hubConnection.connectionId})`
    )
    .catch(err =>
        console.error(err.toString())
    );

hubConnection.on("ReceiveMessage", responseMessage => {
    const aiMessage = `${responseMessage}`;
    chatBox.innerHTML += aiMessage;
    chatBox.scrollTop = chatBox.scrollHeight;
});

const input = document.getElementById("user-input");
const chatBox = document.getElementById("chat-box");

function sendPrompt() {
    if (input.value.trim() === "") return;

    const userMessage = `<div><strong>Sen:</strong> ${input.value}</div>`;
    chatBox.innerHTML += userMessage;
    chatBox.scrollTop = chatBox.scrollHeight;

    const messageData = {
        message: input.value,
        connectionId: hubConnection.connectionId
    };

    $.ajax({
        url: '/Chat/SendMessage',  // Controller'daki metodu çaðýrýyoruz
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(messageData),
        success: function (response) {
            // Burada baþarýlý yanýtý iþleyebilirsiniz
            console.log('Success:', response);
        },
        error: function (error) {
            // Hata durumunda iþlemler
            console.error('Error:', error);
        }
    });

    input.value = ""; // Mesajý temizle
}

// Enter tuþuna basýldýðýnda sendPrompt fonksiyonunu çaðýr
input.addEventListener("keydown", function (event) {
    if (event.key === "Enter") {
        sendPrompt();
    }
});