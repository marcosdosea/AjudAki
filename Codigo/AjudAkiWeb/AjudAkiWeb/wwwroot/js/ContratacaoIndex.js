document.addEventListener("DOMContentLoaded", function () {
    const contratacaoCards = document.querySelectorAll(".contratacao-card");

    contratacaoCards.forEach(card => {
        const status = card.getAttribute("data-status");
        const statusMessage = card.querySelector(".status-mensagem");
        switch (status) {
            case "Aceito":
                statusMessage.innerHTML = 'Status: <strong style="color: green;">Serviço aceito</strong>';
                break;
            case "Recusado":
                statusMessage.innerHTML = 'Status: <strong style="color: red;">Serviço recusado</strong>';
                break;
            default:
                statusMessage.innerHTML = 'Status: <strong style="color: #ff9900;">Aguardando a confirmação da visita</strong>';
        }
    });
});
